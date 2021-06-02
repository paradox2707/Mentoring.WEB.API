using AutoMapper;
using Mentoring.WEB.API.BLL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;
using System.Linq;
using System;
using Mentoring.WEB.API.Common.FilterModels;
using System.Linq.Expressions;
using System.Reflection;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class UniversityService : IUniversityService
    {
        readonly IUnitOfWork _uow;
        readonly IUniversityRepository _universityRepo;
        readonly IMapper _mapper;

        public UniversityService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _universityRepo = uow.UniversityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UniversityModel>> GetAllAsync()
        {
            var daos = await _universityRepo.GetAllAsync();

            return _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);
        }

        public async Task<IEnumerable<UniversityModel>> GetAllByFilterAsync(UniversityFilter filter)
        {
            var filterExpression = CreateFilterExpressionForUniversity(filter);
            var daos = await _universityRepo.GetAllByAsync(filterExpression);
            return _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);
        }

        public async Task<IEnumerable<UniversityModel>> GetAllWithSpecialitiesAsync()
        {
            var daos = await _universityRepo.GetAllWithSpecialiesAsync();

            return _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);
        }

        private Expression<Func<University, bool>> CreateFilterExpressionForUniversity(UniversityFilter filter)
        {
            // univer =>
            ParameterExpression inputEntity = Expression.Parameter(typeof(University), "univer");
            Expression predicateBody = Expression.Empty();
            var conditionsList = new List<Expression>();

            // univer.ToLower().Contains(filter.SearchText.ToLower())
            if (!string.IsNullOrWhiteSpace(filter.SearchText))
            {
                Expression leftProp = Expression.Property(inputEntity, typeof(University).GetProperty("Name"));
                Expression leftCall = Expression.Call(leftProp, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
                Expression right = Expression.Constant(filter.SearchText.ToLower());

                MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                var exp = Expression.Call(leftCall, method, right);
                conditionsList.Add(exp);
            }

            // univer.Region.Name.ToLower() == filter.Region.ToLower()
            if (!string.IsNullOrWhiteSpace(filter.Region) && filter.Region != "Вся Україна")
            {
                Expression leftProp = Expression.Property(inputEntity, typeof(University).GetProperty("Region"));
                Expression leftPropValue = Expression.Property(leftProp, typeof(Region).GetProperty("Name"));
                Expression leftCall = Expression.Call(leftPropValue, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
                Expression right = Expression.Constant(filter.Region.ToLower());
                Expression exp = Expression.Equal(leftCall, right);
                conditionsList.Add(exp);
            }

            // univer.IsGoverment == true
            if (filter.IsGoverment.GetValueOrDefault())
            {
                Expression leftProp = Expression.Property(inputEntity, typeof(University).GetProperty("IsGoverment"));
                Expression right = Expression.Constant(true);
                Expression exp = Expression.Equal(leftProp, right);
                conditionsList.Add(exp);
            }

            if (!conditionsList.Any())
                predicateBody = Expression.Constant(true);

            foreach (var conditionItem in conditionsList)
            {
                if (conditionsList.First() == conditionItem)
                {
                    predicateBody = conditionItem;
                    continue;
                }
                predicateBody = Expression.AndAlso(predicateBody, conditionItem);
            }

            return Expression.Lambda<Func<University, bool>>(predicateBody, new ParameterExpression[] { inputEntity });
        }
    }
}
