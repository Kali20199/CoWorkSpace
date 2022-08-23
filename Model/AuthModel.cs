namespace CoWorkSpace.Auth
{
    public class AuthModel
    {
        public string? Messagge { get; set; }
        public bool isAuthenticated { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }

        public List<string>? Roles { get; set; }
        public string? Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}