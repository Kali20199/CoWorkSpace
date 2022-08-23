using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CoWorkSpace.Interfaces;
using CoWorkSpace.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CoWorkSpace.Databse;
using Microsoft.EntityFrameworkCore;

namespace CoWorkSpace.CloudService
{
#nullable disable
    public class PhotosManger : IPhotoAccessor
    {
        private readonly DataContext _context;
        private readonly Cloudinary cloudinary;
        public PhotosManger(IOptions<CloudinarySetting> config,DataContext context)
        {
            _context = context;
            var account = new Account(
                config.Value.CloudName,
               config.Value.ApiKey,
               config.Value.ApiSecret
            );
            cloudinary = new Cloudinary(account);
        }


        public async Task<PhotoUploadResult> AddPhoto(IFormFile formfile)
        {
            if (formfile.Length > 0)
            {
                await using var stream = formfile.OpenReadStream();
                var uploadParam = new ImageUploadParams
                {
                    // Upload Option
                    File = new FileDescription(formfile.FileName, stream),
                    // Optional
                    // Make Standard Size For Images
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill"),

                };
                // Start Upload To Server Cloudinary
                var uploadResult = await cloudinary.UploadAsync(uploadParam);
                if (uploadResult.Error != null)
                {
                    throw new Exception(uploadResult.Error.Message);
                }
                return new PhotoUploadResult
                {
                    PublicId = uploadResult.PublicId,
                    Url = uploadResult.SecureUrl.ToString()
                };



            }
            return null;
        }

        public async Task<string> DeletePhoto(string publicid)
        {
            var Deleteparams = new DeletionParams(publicid);
            var result = await cloudinary.DestroyAsync(Deleteparams);
            var imageId = (await _context.Images.FirstOrDefaultAsync(x => x.PublicId == publicid));
    
           _context.Images.Remove(imageId);
          var saved = await  _context.SaveChangesAsync() > 0;
        
           return "Ok";
        
        }


        public async Task<ActionResult> Base64ToImage(string ImageText)
        {

         return null;
        }
    }
}