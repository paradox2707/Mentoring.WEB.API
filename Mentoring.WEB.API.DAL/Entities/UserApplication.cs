using System.Collections.Generic;

namespace Mentoring.WEB.API.DAL.Entities
{
    public class UserApplication: BaseEntity
    {
        public UserApplication()
        {
            Regions = new List<Region>();
        }

        public int AverageMark { get; set; }

        public ICollection<Region> Regions { get; set; }
    }
}