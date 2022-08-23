using AutoMapper;
using CoWorkSpace.Databse;
using CoWorkSpace.Interfaces;

namespace CoWorkSpace.Application
{
    public class UserService : IUserServiceRepo
    {

        private IMapper _mapper;
        private readonly DataContext _context;
        private readonly IPhotoAccessor _photoAccessor;
        public UserService(DataContext context,IMapper mapper,IPhotoAccessor photoAccessor){

            _mapper = mapper;
            _context = context;
            _photoAccessor = photoAccessor;

        }


        public async Task SetProfPic(IFormFile file)
        {
            var Photo = _photoAccessor.AddPhoto(file);
           
        }


    }
}