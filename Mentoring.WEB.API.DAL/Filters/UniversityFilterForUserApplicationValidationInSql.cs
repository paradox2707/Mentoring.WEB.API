using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Filters
{
    public class UniversityFilterForUserApplicationValidationInSql
    {
        public List<string> Regions { get; set; }

        public List<string> ProfessionalDirections { get; set; }

        public string[] GetParametersForSql()
        {
            var list = new List<string>(Regions);
            list.AddRange(ProfessionalDirections);
            return list.ToArray();
        }

        public string FormatNumbersForRegionsForSqlQuery => 
            !string.IsNullOrWhiteSpace(ConstructFormatNumberForSqlQuery(0, Regions)) 
                ? ConstructFormatNumberForSqlQuery(0, Regions)
                : @"''";

        public string FormatNumbersForProfessionalDirectionsForSqlQuery =>
            !string.IsNullOrWhiteSpace(ConstructFormatNumberForSqlQuery(Regions.Count, ProfessionalDirections))
                ? ConstructFormatNumberForSqlQuery(Regions.Count, ProfessionalDirections)
                : @"''";

        private string ConstructFormatNumberForSqlQuery(int startAt, List<string> list)
        {
            var builder = new StringBuilder();
            int end = list.Count + startAt;
            for (int i = startAt; i < end; i++)
            {
                builder.Append($"{{{i}}} ");
                if (i != end - 1) builder.Append($", ");
            }
            return builder.ToString();
        }
    }
}
