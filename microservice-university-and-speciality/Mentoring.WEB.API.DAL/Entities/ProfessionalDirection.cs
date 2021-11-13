using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Entities
{
    public class ProfessionalDirection : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Speciality> Specialities { get; set; }
    }
}
