using System.Net.Mail;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoWorkSpace.Application.Dtos;
using CoWorkSpace.Auth;
using CoWorkSpace.Databse;
using CoWorkSpace.Interfaces;
using CoWorkSpace.Model;
using CoWorkSpace.Model.CoworkSpace;

using CoWorkSpace.Model.OwnerModel.OwnerModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CoWorkSpace.Application
{
#nullable enable
    public class CoworKSpaceService : ICoworKSpaceRepo
    {
        private readonly UserManager<Appuser> _userManager;
        private readonly IMapper _mapepr;
        private readonly DataContext _context;
        private readonly IUserAccessor userAccessor;
        private readonly IPhotoAccessor _photoAccessor;

        public CoworKSpaceService(UserManager<Appuser> userManager, IMapper mapepr, DataContext context, IUserAccessor userAccessor
, IPhotoAccessor photoAccessor)
        {
            this._context = context;
            this.userAccessor = userAccessor;
            this._mapepr = mapepr;
            this._userManager = userManager;
            this._photoAccessor = photoAccessor;


        }

        public async Task DeleteWorkSpace(Guid CoworkSpaceId)
        {
            var GeLocation = await _context.cowork_Geo_Location.FirstOrDefaultAsync(x => x.LightSpaceId == CoworkSpaceId.ToString());
            _context.cowork_Geo_Location.Remove(GeLocation);
            var result1 = await _context.SaveChangesAsync() > 0;
            var CoworkSpace = await _context.coworkSpaces.FirstOrDefaultAsync(x => x.CoworkSpaceId == CoworkSpaceId);
            _context.coworkSpaces.Remove(CoworkSpace);
            var result = await _context.SaveChangesAsync() > 0;


            return;
        }

        public Task EditWorkSpace(Guid CoworkSpaceId, CoworkSpace model)
        {
            throw new NotImplementedException();
        }

        public Task GetMySpace(GetMySpaceModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CoworkSpace>> GetRegionWorkSpace()
        {
            throw new NotImplementedException();
        }

        public async Task<CoworkSpaceDto> GetSpaceById(Guid Id)
        {


            var Space = await _context.coworkSpaces.Where(x => x.CoworkSpaceId == Id)
                         .ProjectTo<CoworkSpaceDto>(_mapepr.ConfigurationProvider).FirstOrDefaultAsync();
            return Space;
        }

        public async Task<JsonResult> GetAllSpace()
        {
            var email = userAccessor.GetUserName();
            if (email == null) return null;
            var user = await _userManager.FindByEmailAsync(userAccessor.GetUserName());
            if (user == null) return null;

            var projection = await _context.coworkSpaces.Where(x => x.owner == user)
              .ProjectTo<CoworkSpaceDto>(_mapepr.ConfigurationProvider).ToListAsync();
            // var res = await _context.coworkSpaces.Include(x => x.location).Include(x => x.ReservedUsers).Where(id => id.owner == user).ToListAsync();
            // var Spaces = await _context.coworkSpaces.Include(o => o.Images).Include(u => u.location).Where(x => x.owner == user).ProjectTo<CoworkSpaceDto>(_mapepr.ConfigurationProvider).ToListAsync();
            // var Spaces2 = await _context.Images.ToListAsync();

            // var settings = new JsonSerializerSettings
            // {
            //     PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            //     ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            // };
            // var serialized = JsonConvert.SerializeObject(Spaces, settings);
            //    var Spaces2 = await _context.coworkSpaces.Where(u=>);
            // var SELECTED_COWORK  = from Cow in _context.coworkSpaces
            // join Location in _context.cowork_Geo_Location
            // on Cow.CoworkSpaceId equals Location.CoWork.CoworkSpaceId
            // where Cow.owner == user
            // select Cow;

            return new JsonResult(projection);
        }

        public async Task<IEnumerable<CoworkGeoLocation>> GetSpaceAound()
        {
            var email = userAccessor.GetUserName();
            if (email == null) return null;
            var user = await _userManager.FindByEmailAsync(userAccessor.GetUserName());
            if (user == null) return null;

            var locationsAround = await _context.cowork_Geo_Location.ToListAsync();



            return locationsAround;
        }



        public async Task<CoworkSpace> RegisterWorkSpace(Create_Cowork_Model model)
        {
            var email = userAccessor.GetUserName();
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return null;
            Guid workSpaceID = Guid.NewGuid();
            model.location.SpaceName = model.Name;
            model.location.LightSpaceId = workSpaceID.ToString();

            var workSpace = new CoworkSpace()
            {
                CoworkSpaceId = workSpaceID,
                owner = user,
                name = model.Name,
                City = model.City,
                TimeClosed = model.TimeClosed,
                TimeOpen = model.TimeOpen,
                Phone = model.Phone,
                Tables = model.Tables,
                PrivateRooms = model.PrivateRoomPerHour,
                location = model.location,


            };

            var result = await _context.coworkSpaces.AddAsync(workSpace);
            var Result = await _context.SaveChangesAsync() > 0;
            var AddgeLocation = await _context.cowork_Geo_Location.AddAsync(new CoworkGeoLocation
            {
                latitude = model.location.latitude,
                longitude = model.location.longitude,
                accuraccy = model.location.accuraccy,

                CoWork = workSpace,
                LightSpaceId = workSpaceID.ToString(),
                SpaceName = model.Name


            });

            var AddGeLoacationResult = await _context.SaveChangesAsync() > 0;


            return workSpace;
        }
        public Task<JsonResult> GetAllSpace(Guid CoworkSpaceId)
        {
            throw new NotImplementedException();
        }


        public async Task<VerificationModel> SendEmailVerification(string email)
        {
            SmtpClient smtptClient = new SmtpClient(email, 25);
            smtptClient.Credentials = new System.Net.NetworkCredential();
            smtptClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtptClient.EnableSsl = true;
            MailMessage mail = new MailMessage();
            Random rnd = new Random(4);
            int number = rnd.Next(1, 99999);
            mail.From = new MailAddress("LightSpace@gmail.com", "MyWeb Site");
            mail.To.Add(new MailAddress(email));
            mail.Subject = "Light Space VerificationCode";
            mail.CC.Add(new MailAddress(number.ToString()));

            mail.Body = number.ToString();

            try
            {

                smtptClient.Send(mail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return new VerificationModel
            {

            };
        }

        void SendEmailVerification(string email, string userName, string password)
        {
            SmtpClient smtptClient = new SmtpClient(email, 25);
            smtptClient.Credentials = new System.Net.NetworkCredential(userName, password);
            smtptClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtptClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("info@MyWebsiteDomainName", "MyWeb Site");
            mail.Body = "Write yor Verification Code";
            mail.To.Add(new MailAddress("info@MyWebsiteDomainName"));
            mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));

            try
            {
                smtptClient.Send(mail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task<IEnumerable<SpaceCardModel>> getSpaceCard()
        {

            var Spaces = await _context.coworkSpaces.ProjectTo<SpaceCardModel>(_mapepr.ConfigurationProvider).ToListAsync(); ;


            return Spaces;
        }

        public async Task<CoworkSpaceDto> GetWorkSpaceByIdUser(Guid id)
        {
            var Space = await _context.coworkSpaces.Where(x => x.CoworkSpaceId == id)
                         .ProjectTo<CoworkSpaceDto>(_mapepr.ConfigurationProvider).FirstOrDefaultAsync();

            return Space;
        }


        public async Task<MainPhoto> AddPhotos(IFormFile file, string isMain)
        {
            var coworkId = file.FileName.Split("/")[0];


            var email = userAccessor.GetUserName();
            var user = await _userManager.FindByEmailAsync(userAccessor.GetUserName());

            var CoId = Guid.NewGuid();
            if (isMain == "true")
            {
                CoId = new Guid(coworkId);
            }
            var Space = await _context.coworkSpaces.FirstOrDefaultAsync(elment =>
            elment.CoworkSpaceId.ToString() == coworkId);
            var result = (await _photoAccessor.AddPhoto(file));
            //  var url = "";

            var WorkSpaceImage = new Image
            {
                coworkSpaceId = Space,
                Id = CoId.ToString(),
                IsMain = isMain == "true" ? true : false,
                PublicId = result.PublicId,
                Url = result.Url,
            };

            return new MainPhoto
            {
                WorkSpaceIamge = WorkSpaceImage,
                url = WorkSpaceImage.Url,
                PublicId = result.PublicId
            };



        }

        public async Task<MainPhoto> AddMainPhoto(IFormFile file)
        {
            var isMain = file.FileName.Split("/")[2];
            var coworkId = file.FileName.Split("/")[0];
            var Space = await AddPhotos(file, isMain);

            if (isMain != "true")
            {
                await _context.Images.AddAsync(Space.WorkSpaceIamge);
                var result = await _context.SaveChangesAsync();
            }
            else
            {


                try
                {

                    // If Cannot Update Then it is Not Exist
                    _context.Images.Update(Space.WorkSpaceIamge);
                    var result = await _context.SaveChangesAsync();
                    //   await _context.Images.AddAsync(Space.WorkSpaceIamge);
                }
                catch (Exception e)
                {
                    var x = e;
                    try
                    {
                        await _context.Images.AddAsync(Space.WorkSpaceIamge);
                        var result = await _context.SaveChangesAsync();
                    }
                    catch (Exception EX)
                    {
                        var Z = EX;
                    }
                }

            }

            return Space;
        }

        public async Task DeletePhoto(string id)
        {

            await _photoAccessor.DeletePhoto(id);
        }


        public async Task BlockingUser(BlockingDto Blockeduser)
        {
            var email = userAccessor.GetUserName();
            var user = await _userManager.FindByEmailAsync(userAccessor.GetUserName());
            var Space = await _context.coworkSpaces.FirstOrDefaultAsync(x => x.CoworkSpaceId == Blockeduser.CoworkId);

            // Authorization Policy Later on That Grantee that only owner of cowork Space with JWT Has Access
            // to Blocked user from his Own Space


            // Check if User Already Exist in Blocked
            if (!await _context.BlockedUsers.AnyAsync(x => x.CoworkId.CoworkSpaceId == Blockeduser.CoworkId)
               && !await _context.BlockedUsers.AnyAsync(x => x.user.Email == Blockeduser.email)
            )
            {
                return;
            }

            _context.BlockedUsers.Add(new BlockedModel
            {
                user = user,
                CoworkId = Space,
            });


            var result = await _context.SaveChangesAsync();

        }

        public class MainPhoto
        {
            public Image WorkSpaceIamge { get; set; }
            public string url { get; set; }

            public string PublicId { get; set; }
        }

    }
}