using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.Common.FilterModels
{
    public class UniversityFilter
    {
        public string SearchText { get; set; }

        public string Region { get; set; }

        public bool? IsGoverment { get; set; }

        public bool IsValid => SearchText != null || Region != null || IsGoverment != null;
    }
}
