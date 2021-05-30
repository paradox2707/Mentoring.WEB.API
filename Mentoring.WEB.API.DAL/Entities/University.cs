using System.Collections.Generic;

namespace Mentoring.WEB.API.DAL.Entities
{
    public class University : BaseEntity
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string ExternalId { get; set; }

        public bool IsGoverment { get; set; }

        public ICollection<Speciality> Specialities { get; set; }

        public long RegionId { get; set; }

        public Region Region { get; set; }
    }
}