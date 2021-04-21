using System.Collections.Generic;

namespace Mentoring.WEB.API.DAL.Entities
{
    public class Speciality: BaseEntity
    {
        public string Name { get; set; }

        public string ExternalId { get; set; }

        public ICollection<University> Universities { get; set; }
    }
}
