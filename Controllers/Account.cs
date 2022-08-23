using AutoMapper;
using CoWorkSpace.Application;
using CoWorkSpace.Application.Dtos;
using CoWorkSpace.Auth;
using CoWorkSpace.Databse;
using CoWorkSpace.Interfaces;
using CoWorkSpace.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace CoWorkSpace.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]

#nullable disable
    public class AccountController : ControllerBase
    {
        private readonly IAuthService service;
        public UserManager<Appuser> UserManager { get; }
        public SignInManager<Appuser> SignInManager { get; }
        private readonly IMapper _mapper;
        private readonly IUserServiceRepo _userServiceRepo;


        private readonly IConfiguration _config;

        private readonly ICoworKSpaceRepo _coworKSpaceRepo;

        private readonly HttpClient _htttpClient;

        public AccountController(IAuthService service, UserManager<Appuser> userManager, SignInManager<Appuser> signInManager,
         IMapper mapper, IUserServiceRepo user, ICoworKSpaceRepo coworKSpaceRepo, IConfiguration config)
        {
            this.service = service;
            this._mapper = mapper;
            this.SignInManager = signInManager;
            this.UserManager = userManager;
            this._userServiceRepo = user;
            this._coworKSpaceRepo = coworKSpaceRepo;
            this._config = config;
            this._htttpClient = new HttpClient
            {
                BaseAddress = new System.Uri("https://graph.facebook.com/")
            };

        }

        public class FIleUploadAPI
        {
        public FIleUploadAPI(IFormFile files) 
        {
            this.files = files;
               
        }
                    public IFormFile files { get; set; }
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var userDto = await service.Login(login);
            return Ok(userDto);
        }


        [HttpPost("FbLogin")]
        public async Task<IActionResult> FbLogin(FaceBookUserModel fbuser)
        {
             var userDto = await service.FBlogin(fbuser);
          

            return Ok(userDto);
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel register)
        {

            await service.Register(register);
            return Ok("Verification Code Sended on " + register.Email + " Please Confirm It");
        }




        [HttpPost("ConfirmAccount")]
        public async Task<IActionResult> ConfirmAccount(VerificationModel verify)
        {
            await service.ConfirmSendEmailVerification(int.Parse(verify.Code), verify.email);


            return Ok("");
        }



        [HttpGet("CheckAuth")]
        public async Task<IActionResult> CheckAuth()
        {

            return Ok("Auth 200");
        }
        private UserDtos GetUserDto(Appuser user, AuthModel model)
        {



            return new UserDtos
            {
                Id = user.Id,
                Email = user.Email,
                Token = model.Token

            };



        }

        [HttpPost("SetProfPic")]
        public async Task<IActionResult> SetProfPic(IFormFile file)
        {

            //  await _userServiceRepo.SetProfPic(file);


            return Ok("");
        }









    }
}




