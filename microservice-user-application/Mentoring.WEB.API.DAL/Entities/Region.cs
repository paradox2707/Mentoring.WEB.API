using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Entities
{
    public class Region: BaseEntity
    {
        public Region()
        {
            UserApplications = new List<UserApplication>();
        }

        public string Name { get; set; }

        public ICollection<UserApplication> UserApplications { get; set; }
    }
}
