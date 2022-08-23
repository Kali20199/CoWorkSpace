using CoWorkSpace.Model;



namespace CoWorkSpace.Interfaces
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadResult> AddPhoto(IFormFile formfile);
        Task<string> DeletePhoto(string publicid);

    }
}