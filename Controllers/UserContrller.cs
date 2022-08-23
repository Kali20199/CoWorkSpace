using CoWorkSpace.Application;
using CoWorkSpace.Application.Dtos;
using CoWorkSpace.Interfaces;
using CoWorkSpace.Model;
using CoWorkSpace.Model.CoworkSpace;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoWorkSpace.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly ICoworKSpaceRepo _coworKSpaceService;
        private readonly IUserServiceRepo _userService;

        public UserController(ICoworKSpaceRepo coworKSpaceService , IUserServiceRepo userService)
        {
            this._coworKSpaceService = coworKSpaceService;
            _userService = userService;



        }
        [AllowAnonymous]
        [HttpGet("hello")]
        public async Task<IActionResult> hello() {


            return Ok("Hello ");
        }


        [HttpGet("GetSpaceAound")]
        public async Task<IEnumerable<CoworkGeoLocation>> GetSpaceAound()
        {
            var result = await _coworKSpaceService.GetSpaceAound();
            return result;
        }
     
        [HttpPost("GetSpaceById")]
        public async Task<CoworkSpaceDto> GetSpaceById(SpaceByIdModel model)
        {
            var space = await _coworKSpaceService.GetWorkSpaceByIdUser(model.id);
            return space;

        }

     
        [HttpGet("getSpacesList")]
        public async Task<IEnumerable<SpaceCardModel>> getSpaceCard()
        {

            var spaces = await _coworKSpaceService.getSpaceCard();
            return spaces;
        }



        [HttpPost("SetProfPic")]
        public async Task<IActionResult> SetProfPic(IFormFile file)
        {

           


            return Ok("");
        }



    }
}