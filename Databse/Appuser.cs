using System.ComponentModel.DataAnnotations;
using CoWorkSpace.Model.CoworkSpace;
using Microsoft.AspNetCore.Identity;

namespace CoWorkSpace.Databse
{
#nullable disable
    public class Appuser : IdentityUser
    {
        public List<CoworkSpace> coWorkSpaces = new List<CoworkSpace>();
        public string City { get; set; }
        public string FullName { get; set; }

        public Image image { get; set; }
        public string Phone { get; set; }

    










    }
}