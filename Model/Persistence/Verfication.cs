namespace CoWorkSpace.Model.Persistence
{
    #nullable disable
    public class Verfication
    {
        public Guid Id { get; set; }
        public string email { get; set; }

        public int Code { get; set; }

        public int FailedTry {get;set;} =0;
    }
}