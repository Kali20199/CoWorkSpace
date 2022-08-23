using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CoWorkSpace.Model.CoworkSpace
{
#nullable disable
    public class CoworkGeoLocation
    {

        [Key]
        public Guid Cowork_Geo_LocationId { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string accuraccy { get; set; }

        [JsonIgnore]
        public CoworkSpace CoWork { get; set; }
        public string LightSpaceId { get; set; }
        public string SpaceName { get; set; }

    }
}