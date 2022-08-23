using System.ComponentModel.DataAnnotations.Schema;
using CoWorkSpace.Application.Dtos;
using CoWorkSpace.Interfaces;
using CoWorkSpace.Model.CoworkSpace;
using CoWorkSpace.Model.OwnerModel;
using CoWorkSpace.Model.OwnerModel.OwnerModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#nullable disable
namespace CoWorkSpace.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly ICoworKSpaceRepo _coworKSpaceService;
        private readonly IPhotoAccessor _photoAccessor;
        public OwnerController(ICoworKSpaceRepo coworKSpaceService, IPhotoAccessor photoAccessor)
        {
            this._coworKSpaceService = coworKSpaceService;
            this._photoAccessor = photoAccessor;

        }

        public class SPaceWithImage
        {
            public Create_Cowork_Model model { get; set; }
            public IFormFile file { get; set; }
        }


        [HttpPost("Create_Work")]
        public async Task<IActionResult> Register_WorkSpace(Create_Cowork_Model model)
        {

            var workSpace = await _coworKSpaceService.RegisterWorkSpace(model);


            return null;
        }


        [HttpPost("Delete_WorkSpace")]
        public async Task<IActionResult> GetMySpace(GetMySpaceModel space)
        {


            await _coworKSpaceService.DeleteWorkSpace(new Guid(space.Id));


            return Ok("Deleted");
        }


        [HttpGet("GetAllMySpace")]
        public async Task<IActionResult> GetAllSpace()
        {


            var Space = await _coworKSpaceService.GetAllSpace();


            return Ok(Space);
        }



        [HttpGet("UnAuth")]
        public IActionResult UnAuth()
        {
            return Unauthorized();
        }

        public class FIleUploadAPI
        {


        }



        [HttpPut("BlockingUser")]
        public async Task<IActionResult> BlockingUser(BlockingDto Blockeduser)
        {
            await _coworKSpaceService.BlockingUser(Blockeduser);
            return Ok("User Blocked");
        }



        [HttpPost("AddPhoto")]
        public async Task<IActionResult> AddMainPhoto(IFormFile file)
        {
            var data = await _coworKSpaceService.AddMainPhoto(file);
            return Ok(data);
        }

        [HttpPost("DeletePhoto")]
        public async Task<IActionResult> DeletePhoto(SpaceByIdModelOwner model)
        {

            await _coworKSpaceService.DeletePhoto(model.Id);
            return Ok("Deleted");
        }




    }
}


