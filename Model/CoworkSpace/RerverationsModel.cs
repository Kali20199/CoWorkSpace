using System.ComponentModel.DataAnnotations;
using CoWorkSpace.Databse;

#nullable disable
namespace CoWorkSpace.Model.CoworkSpace
{
    public class RerverationsModel
    {

        [Key]
        public string Email { get; set; }
        public Appuser user { get; set; }
        public CoworkSpace Cowork { get; set; }
        public string UserName { get; set; }
        public DateTime TimeReservd { get; set; }

        public bool Confirmed { get; set; } = false;

    }
}