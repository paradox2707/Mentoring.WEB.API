using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Filters
{
    public class UniversityFilterInSql
    {
        public string SearchText { get; set; }

        public string Region { get; set; }

        public string Conjunction { get; set; }

        public bool? IsGoverment { get; set; }

        public string Where => string.IsNullOrEmpty(SearchText) || IsGoverment.HasValue ? "WHERE" : String.Empty;

        public bool ComplexQuery => !string.IsNullOrEmpty(Region) && Conjunction.ToLower() == "or";

        public string ConjunctionForQuery => $" {Conjunction} ";

        public string SelectedFieldsForSql =>
            @"[Universities].[Id] as Id
            , [Universities].[ExternalId] as ExternalId
            , [Universities].[IsGoverment] as IsGoverment
            , [Universities].[Name] as Name
            , [Universities].[RegionId] as RegionId
            , [Universities].[ShortName] as ShortName FROM Universities ";

        public string RegionConditionForSqlInnerJoinApproach =>
            @$"INNER JOIN (SELECT * FROM Regions 
            WHERE [Name] = {{[RegionNumberForParameter]}}) as RegionTbl 
            ON RegionTbl.Id = Universities.RegionId";

        public string SearchTextConditionForSql => $"Universities.[Name] Like CONCAT(CONCAT('%', {{[SearchTextNumberForParameter]}} ),'%')";

        public string GovermentConditionForSql => $"{(SearchText != null ? Conjunction : string.Empty)} Universities.[IsGoverment] = {{[IsGovermentNumberForParameter]}} ";

        public IDictionary<string, string> GetParametersSequence()
        {
            var result = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(SearchText)) result.Add("[SearchTextNumberForParameter]", SearchText);
            if (!string.IsNullOrWhiteSpace(Region)) result.Add("[RegionNumberForParameter]", Region);
            if (IsGoverment != null) result.Add("[IsGovermentNumberForParameter]", IsGoverment.ToString());

            return result;
        }
    }
}
