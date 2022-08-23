using System.ComponentModel.DataAnnotations.Schema;
using CoWorkSpace.Databse;
using CoWorkSpace.Model.CoworkSpace;

namespace CoWorkSpace.Model.CoworkSpace
{
#nullable disable
    public class CoworkSpace
    {
        [NotMapped]
        public Appuser owner { get; set; }
        public Guid CoworkSpaceId { get; set; }

        public ICollection<BlockedModel> BlockedUsers = new List<BlockedModel>();
        public string name { get; set; }
        public string City { get; set; }
        public CoworkGeoLocation location ;
        public ICollection<Image> Images = new List<Image>();
        public ICollection<RerverationsModel> ReservedUsers = new List<RerverationsModel>();
        public DateTime TimeOpen { get; set; }
        public DateTime TimeClosed { get; set; }
        public int Phone { get; set; }
        public int Tables { get; set; }
        public int PrivateRooms { get; set; }
        public int PricePerTable { get; set; }
        public int PrivateRoomPerHour { get; set; }


    }
}