using CoWorkSpace.Helper;
using CoWorkSpace.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoWorkSpace.Controllers
{   
    
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class WorkSpaceController : ControllerBase
    {

    

        public WorkSpaceController()
        {
       

        }


      [HttpPost("uploadImage")]
      public async Task<IActionResult> uploadImage([FromForm] MultiForms file)
      {
          var الملف = Request.Form.Files;

          return Ok("File Uploaded");
      }  


        [HttpGet("test")]
      public async Task<IActionResult> test()
      {

          return Ok("test worked");
      }  

    }
}