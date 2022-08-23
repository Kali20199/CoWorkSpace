using CoWorkSpace.Model.CoworkSpace;
using Microsoft.AspNetCore.Mvc;

namespace CoWorkSpace.Model.OwnerModel.OwnerModel
{
#nullable disable
    public class Create_Cowork_Model
    {

        public string City { get; set; }
        public CoworkGeoLocation location { get; set; }
        public DateTime TimeOpen { get; set; }
        public DateTime TimeClosed { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public int Tables { get; set; }
        public int PrivateRooms { get; set; }
        public int PricePerTable { get; set; }
        public int PrivateRoomPerHour { get; set; }
     
        public IFormFile file { get; set; }

    }
}