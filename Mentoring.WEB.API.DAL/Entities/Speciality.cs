using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Entities
{
    public class Speciality: BaseEntity
    {
        public string Name { get; set; }

        public string ExternalId { get; set; }

        public List<University> Universities { get; set; }
    }
}
