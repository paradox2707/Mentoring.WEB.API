using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.Common.DTO
{
    public class AbiturientApplicationModel
    {
        public long Id { get; set; }

        public int AverageMark { get; set; }

        public IEnumerable<string> Regions { get; set; }
    }
}
