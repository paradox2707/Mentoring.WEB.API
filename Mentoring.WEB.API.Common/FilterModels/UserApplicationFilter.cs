using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.Common.FilterModels
{
    public class UserApplicationFilter
    {
        public string SearchText { get; set; }

        public string Region { get; set; }

        public string ProfessionalDirection { get; set; }

        public bool Active => SearchText != null || Region != null || ProfessionalDirection != null;
    }
}
