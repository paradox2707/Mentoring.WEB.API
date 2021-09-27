using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.FilterModels
{
    public class UniversityFilterForUserApplication
    {
        public List<string> Regions { get; set; }

        public int AverageMark { get; set; }
    }
}
