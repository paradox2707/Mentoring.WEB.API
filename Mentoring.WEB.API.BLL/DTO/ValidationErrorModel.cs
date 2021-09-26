using System.Text.Json.Serialization;

namespace Mentoring.WEB.API.Common.DTO
{
    public class ValidationErrorModel
    {
        [JsonPropertyName("errors")]
        public ValidationError Errors { get; set; }
    }
}
