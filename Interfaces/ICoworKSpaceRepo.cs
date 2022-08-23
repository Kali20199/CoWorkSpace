using CoWorkSpace.Application.Dtos;
using CoWorkSpace.Model;
using CoWorkSpace.Model.CoworkSpace;
using CoWorkSpace.Model.OwnerModel.OwnerModel;
using Microsoft.AspNetCore.Mvc;
using static CoWorkSpace.Application.CoworKSpaceService;

namespace CoWorkSpace.Interfaces
{
    public interface ICoworKSpaceRepo
    {
        
         Task<CoworkSpace> RegisterWorkSpace(Create_Cowork_Model model);
         Task EditWorkSpace(Guid CoworkSpaceId,CoworkSpace model);
         Task DeleteWorkSpace(Guid CoworkSpaceId);

         Task<IEnumerable<CoworkSpace>> GetRegionWorkSpace();
         Task<CoworkSpaceDto> GetWorkSpaceByIdUser(Guid CoworkSpaceId);

         Task<CoworkSpaceDto> GetSpaceById(Guid Id);

         Task<JsonResult> GetAllSpace();

         Task<IEnumerable<CoworkGeoLocation>> GetSpaceAound();

         Task<IEnumerable< SpaceCardModel>> getSpaceCard();

         Task<MainPhoto> AddMainPhoto(IFormFile file);

         Task DeletePhoto(string id);

         Task BlockingUser(BlockingDto Blockeduser);

         Task<VerificationModel> SendEmailVerification(string email);

       

     

        

    }
}