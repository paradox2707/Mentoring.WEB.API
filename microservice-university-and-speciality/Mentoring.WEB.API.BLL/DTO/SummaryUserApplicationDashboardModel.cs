using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.DTO
{
    public class SummaryUserApplicationDashboardModel
    {
        public int TotalAmount { get; set; }

        public int AvarageMark { get; set; }

        public int MinMark { get; set; }

        public int MaxMark { get; set; }
    }
}
