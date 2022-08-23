using System.Security.Claims;
using CoWorkSpace.Interfaces;

#nullable disable
namespace CoWorkSpace.Auth
{
    #nullable disable
    public class UserAccessor : IUserAccessor
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
       
            this._httpContextAccessor = httpContextAccessor;
        }

        public string GetUserName()
        {
            var name= ClaimTypes.Name;
            var user = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
                  
            return user;
        }
    }
}