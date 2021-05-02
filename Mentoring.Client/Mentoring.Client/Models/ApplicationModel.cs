using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.Client.Models
{
    public class ApplicationModel
    {
        public int AverageMark { get; set; }

        public IEnumerable<string> Regions { get; set; }
    }
}
