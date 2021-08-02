using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.Common.DTO
{
    public class ValidationErrorModel
    {
        [JsonPropertyName("errors")]
        public ValidationError Errors { get; set; }
    }
}
