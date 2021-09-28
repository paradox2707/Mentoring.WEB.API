using System.Collections.Generic;

namespace Mentoring.WEB.API.DAL.Entities
{
    public class UserApplication: BaseEntity
    {
        public UserApplication()
        {
            Regions = new List<Region>();

            ProfessionalDirections = new List<ProfessionalDirection>();
        }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public int PhoneNumber { get; set; }

        public int AverageMark { get; set; }

        public ICollection<Region> Regions { get; set; }

        public ICollection<ProfessionalDirection> ProfessionalDirections { get; set; }
    }
}