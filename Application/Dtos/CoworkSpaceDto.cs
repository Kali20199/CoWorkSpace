using CoWorkSpace.Model.CoworkSpace;

namespace CoWorkSpace.Application.Dtos
{
#nullable disable
    public class CoworkSpaceDto
    {



        public Guid CoworkSpaceId { get; set; }
        public string name { get; set; }

        public string City { get; set; }
        public CoworkGeoLocation location { get; set; }
        public ICollection<Image> Images { get; set; }
        public DateTime TimeOpen { get; set; }
        public DateTime TimeClosed { get; set; }
        public int Phone { get; set; }
        public int Tables { get; set; }
        public int PrivateRooms { get; set; }
        public int PricePerTable { get; set; }
        public int PrivateRoomPerHour { get; set; }




    }
}