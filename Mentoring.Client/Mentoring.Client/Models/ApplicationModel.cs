using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mentoring.Client.Models
{
    public class ApplicationModel
    {
        public ApplicationModel()
        {
            Regions = new List<RegionModel>();
        }

        [JsonPropertyName("averageMark")]
        public int AverageMark { get; set; }

        [JsonPropertyName("regions")]
        public List<RegionModel> Regions { get; set; }
    }
}
