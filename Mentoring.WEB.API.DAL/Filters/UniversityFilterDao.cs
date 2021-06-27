using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Filters
{
    public class UniversityFilterDao
    {
        public string SearchText { get; set; }

        public string Region { get; set; }

        public bool? IsGoverment { get; set; }

        public bool NeededConditionce => Region != null || IsGoverment.HasValue;
    }
}
