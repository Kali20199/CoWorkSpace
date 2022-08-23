using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CoWorkSpace.Model.CoworkSpace
{
#nullable disable
    public class Image
    {
        [NotMapped]
        [JsonIgnore]
        public CoworkSpace coworkSpaceId { get; set; }
        public string Id { get; set; }

        public string PublicId {get;set;}
        public string Url { get; set; }
        public bool IsMain { get; set; }
    }
}