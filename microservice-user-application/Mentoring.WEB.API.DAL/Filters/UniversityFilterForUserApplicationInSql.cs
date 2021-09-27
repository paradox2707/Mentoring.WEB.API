using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Filters
{
    public class UniversityFilterForUserApplicationInSql
    {
        public List<string> Regions { get; set; }

        public int AverageMark { get; set; }

        public int ParameterNumberForAvarageMark => Regions.Count;

        public string[] GetParametersForSql()
        {
            var list = new List<string>(Regions);
            list.Add(AverageMark.ToString());
            return list.ToArray();
        }

        public string GetFormatNumbersForSqlQuery()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < Regions.Count; i++)
            {
                builder.Append($"{{{i}}} ");
                if(i != Regions.Count - 1) builder.Append($", ");
            }

            return builder.ToString();
        }
    }
}
