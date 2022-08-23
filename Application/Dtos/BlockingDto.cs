namespace CoWorkSpace.Application.Dtos
{
    #nullable disable
    public class BlockingDto
    {
        public string email { get; set; }
        public Guid CoworkId { get; set; }

        public string ImageUrl { get; set; } = "None";
    }
}