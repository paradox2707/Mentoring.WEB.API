﻿using AutoMapper;
using Mentoring.WEB.API.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mentoring.WEB.API.DAL.Entities;

namespace Mentoring.WEB.API.Common
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<University, UniversityModel>();
            CreateMap<Speciality, SpecialityModel>();
            CreateMap<EdboUniversityModel, University>()
                .ForMember(dest => dest.Specialities, opt => opt.AllowNull());
            CreateMap<EdboSpecialityModel, Speciality>()
                .ForMember(dest => dest.Universities, opt => opt.Ignore());
        }
    }
}
