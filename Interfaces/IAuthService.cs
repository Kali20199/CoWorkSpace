using System.IdentityModel.Tokens.Jwt;
using CoWorkSpace.Auth;
using CoWorkSpace.Application.Dtos;
using CoWorkSpace.Model;
using CoWorkSpace.Databse;
namespace CoWorkSpace.Interfaces
{
    public interface IAuthService
    {
       Task<UserDtos> Login(LoginModel model);

       Task Register(RegisterModel model);

       Task<AuthModel> GetUser(LoginModel model);

       Task<AuthModel> GetTokenAsync(Appuser user);
       Task SendEmailVerification(string email);

       Task<UserDtos> ConfirmSendEmailVerification(int Code,string email);

       Task<UserDtos> FBlogin(FaceBookUserModel fbuser);
    }
}