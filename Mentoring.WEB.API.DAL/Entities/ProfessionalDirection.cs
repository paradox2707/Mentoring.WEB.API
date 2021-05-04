using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Entities
{
    public class ProfessionalDirection : BaseEntity
    {
        public ProfessionalDirection()
        {
            UserApplications = new List<UserApplication>();
        }

        public string Name { get; set; }

        public ICollection<UserApplication> UserApplications { get; set; }
    }
}
