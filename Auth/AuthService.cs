using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using CoWorkSpace.Databse;
using CoWorkSpace.Interfaces;
using CoWorkSpace.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CoWorkSpace.Application.Dtos;
using MailKit.Net.Smtp;
using CoWorkSpace.Model.Persistence;
using MimeKit;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
namespace CoWorkSpace.Auth
{
#nullable disable
    public class AuthService : IAuthService
    {
        private readonly UserManager<Appuser> UserManager;
        private readonly IMapper mapper;
        private readonly JWT _jWT;
        private readonly SignInManager<Appuser> signInManager;
        private readonly IUserAccessor _userAccessor;
        private readonly DataContext context;

        private readonly IConfiguration _config;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly HttpClient _htttpClient;

        public AuthService(UserManager<Appuser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IOptions<JWT> jwt, SignInManager<Appuser> signInManager,
        DataContext context, IUserAccessor userAccessor, IConfiguration config)
        {
            this.roleManager = roleManager;
            this.context = context;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.UserManager = userManager;
            this._jWT = jwt.Value;
            this._userAccessor = userAccessor;
            this._config = config;
            this._htttpClient = new HttpClient
            {
                BaseAddress = new System.Uri("https://graph.facebook.com/")
            };

        }
        public Task<AuthModel> GetUser(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDtos> Login(LoginModel model)
        {
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null) return null;
            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!user.EmailConfirmed) return null;
            if (!result.Succeeded) return null;
            var Verifytoekn = await CreateToken(user);
            var UserRoles = await UserManager.GetRolesAsync(user);
            var token = await GetTokenAsync(user);
            
            var userDto = GetUserDto(user, token);
            return userDto;
        }

        public async Task<UserDtos> FBlogin(FaceBookUserModel fbuser)
        {
            
            var fbveifyKey = _config["Facebook:AppId"] + "|" + _config["Facebook:AppSecret"];
            var AppToken = _config["Facebook:AppId"];
            var verifyToken = await _htttpClient.GetAsync($"debug_token?input_token={fbuser.token}&access_token={fbveifyKey}");
            if (!verifyToken.IsSuccessStatusCode) return null;
            var fburl = $"me?access_token={fbuser.token}&fields=name,email";
            var response = await _htttpClient.GetAsync(fburl);
            if (!response.IsSuccessStatusCode) return null;
            var fbInfo = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
            var userName = (string)fbInfo.name;
            var email = (string)fbInfo.email;


            // Check if Exist on Database 

            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                var NewFbUser = new Appuser
                {
                    UserName = Regex.Replace(userName, @"\s+", ""),
                    Email = email,
                    EmailConfirmed = true

                };
                Random rnd = new Random();
                string Password = rnd.Next(100000000, 999999999).ToString();
                Password = "Av$" + Password;
                var result = await UserManager.CreateAsync(NewFbUser, Password);

                user = NewFbUser;
                if (!result.Succeeded) return null;


            }



            var token = await GetTokenAsync(user);
            var userDto = GetUserDto(user, token);
            return userDto;

        }

        public async Task Register(RegisterModel model)
        {

            var user = mapper.Map<Appuser>(model);
            if (user == null) return;
            var result = await UserManager.CreateAsync(user, model.Password.ToString());
            if (!result.Succeeded) return;
            //  var token = await GetTokenAsync(Model);
            //   var userDto = GetUserDto(user, token);
            await SendEmailVerification(model.Email);
        }



        public async Task SendEmailVerification(string email)
        {

            Random rnd = new Random();
            int number = rnd.Next(10000, 999999);

            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("LightSpace", "mostafaihab2019@gmail.com"));
                message.To.Add(new MailboxAddress("New User", email));
                message.Subject = "LighSpace Verification";
                message.Body = new TextPart("plain")
                {
                    Text = "Veify The Code of 5 digit : " + number
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("mostafaihab2019@gmail.com", "mostafaihab25");
                    client.Send(message);
                    client.Disconnect(true);
                };



                await context.Verifications.AddAsync(new Verfication
                {
                    email = email,
                    Code = number
                });

                var result = await context.SaveChangesAsync() > 0;

                if (!result)
                {
                    throw new Exception("Cannot Save Verification Code Yo Database");
                }
            }
            catch (Exception e)
            {
                var x = e;
            }





            return;
        }

        public async Task<AuthModel> GetTokenAsync(Appuser user)
        {

            var Verifytoekn = await CreateToken(user);
            var UserRoles = await UserManager.GetRolesAsync(user);
            return new AuthModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(Verifytoekn),
                Email = user.Email,
                UserName = user.UserName,
                ExpireDate = Verifytoekn.ValidFrom,
                Roles = UserRoles.ToList()

            };
        }



        public async Task<JwtSecurityToken> CreateToken(Appuser user)
        {
            var userClaims = await UserManager.GetClaimsAsync(user);
            var roles = await UserManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {  // roles must be LowerCase in Order To Be recogonized by Authorize Attribute 
                roleClaims.Add(new Claim("roles", role));

            }
            // Step1 Add Calims 
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,user.Id),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id),
            }.Union(userClaims).Union(roleClaims);
            // Step 2 Encrypt Using Key In Development
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWT.Key));
            var singningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            // Step 3 Use JWT Configration using Dependncy Injection      
            var JwtSecurityToken = new JwtSecurityToken(issuer: _jWT.Issuser, audience: _jWT.Audience, claims: claims, expires: DateTime.Now.AddDays(_jWT.DurationDays), signingCredentials: singningCredentials);
            Console.WriteLine("Created JWT Token");
            return JwtSecurityToken;
        }







        public UserDtos GetUserDto(Appuser user, AuthModel model)
        {

            return new UserDtos
            {
                Id = user.Id,
                Email = user.Email,
                Token = model.Token

            };
        }

        public async Task<UserDtos> ConfirmSendEmailVerification(int Code, string email)
        {

            var user = await UserManager.FindByEmailAsync(email);
            var verfication = (await context.Verifications.FirstOrDefaultAsync(x => x.email == email));
            if (verfication.FailedTry <= 3 || verfication == null)
            {
                if (Code == verfication.Code)
                {
                    var ConfirmedUser = await context.Users.FirstOrDefaultAsync(x => x.Email == email);
                    ConfirmedUser.EmailConfirmed = true;
                    var token = await GetTokenAsync(user);

                    var userDto = GetUserDto(user, token);
                    var result = await context.SaveChangesAsync() > 0;
                    context.Verifications.Remove(verfication);
                    await context.SaveChangesAsync();

                    return userDto;

                }
                verfication.FailedTry += 1;
                return null;
            }
            else
            {
                // Delete Token and Resend it Again
                return null;
            }
        }
    }
}