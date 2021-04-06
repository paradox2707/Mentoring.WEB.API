
using System.Collections.Generic;

namespace Mentoring.WEB.API.DAL.Entities
{
    public class University : BaseEntity
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public int ExternalId { get; set; }

        public List<Speciality> Specialities { get; set; }
    }
}