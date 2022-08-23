using System.ComponentModel.DataAnnotations;
using CoWorkSpace.Databse;

namespace CoWorkSpace.Model.CoworkSpace
{
#nullable disable
    public class BlockedModel
    {
        [Key]
        public Guid BlockedUserId { get; set; }


        public Appuser user { get; set; }


        public CoworkSpace CoworkId { get; set; }
    }
}