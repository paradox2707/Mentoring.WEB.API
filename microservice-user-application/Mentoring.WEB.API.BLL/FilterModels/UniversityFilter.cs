using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.FilterModels
{
    public class UniversityFilter
    {
        public string SearchText { get; set; }

        public string Region { get; set; }

        public string Conjunction { get; set; }

        public bool? IsGoverment { get; set; }

        public bool Active => (SearchText != null || Region != null || IsGoverment != null) && (Conjunction == "AND" || Conjunction == "OR");
    }
}
