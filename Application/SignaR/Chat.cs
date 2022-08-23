using CoWorkSpace.Databse;
using CoWorkSpace.Interfaces;
using CoWorkSpace.Model;
using CoWorkSpace.Model.CoworkSpace;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using  CoWorkSpace.Model.SignalRModels;
namespace CoWorkSpace.Application.ChatHub
{
    [AllowAnonymous]
#nullable disable
    public class ChatHub : Hub
    {
        private readonly IHubContext<Hub> _signalhub;

        private readonly ICoworKSpaceRepo _coworKSpaceService;
             private readonly DataContext _context;

        public ChatHub(IHubContext<Hub> signalhub ,ICoworKSpaceRepo  coworKSpaceService ,DataContext context)
        {
            this._signalhub = signalhub;
            this._coworKSpaceService = coworKSpaceService;
            this._context = context;
            
        }




        public async Task AcceptReservation(AcceptReservation model){

            // Owner will InvokThis Method
           await  Clients.Groups(model.email).SendAsync("AcceptReservation",model);
        
        }





        public async Task Reservations(ReserveModel model)
        {
            
          //  await Clients.Group(model.CoworkSpaceid).SendAsync("Reservations",model);

    
          await Clients.Groups(model.CoworkSpaceid).SendAsync("Reservations",model);
          //  await Clients.All.SendAsync("Reservations",model);
            

        }


        public async Task joinGroup(CoworkGroup goupName)
        {
            
           await Groups.AddToGroupAsync(this.Context.ConnectionId, goupName.CoworkId);
           var SpaceName = _context.coworkSpaces.FirstOrDefault(x=>x.CoworkSpaceId.ToString() == goupName.CoworkId).name;
      //   var spaceName =  _coworKSpaceService.GetSpaceById(new Guid( goupName.CoworkId));
           Console.WriteLine("Space : "+SpaceName+" Started Connection");
            

        }

            public async Task joinGroupAcceptence(AcceptReservation model)
        {
            
           await Groups.AddToGroupAsync(this.Context.ConnectionId, model.email);
        
            

        }










        public async Task onConnected()
        {

            await Clients.Caller.SendAsync("Live","True");

        }





        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();

            await Clients.Caller.SendAsync("Reservations","Hello Client");
            if (httpContext.Request.Query.Keys.Contains("Reservations"))
            {
                 await Groups.AddToGroupAsync(this.Context.ConnectionId,"All");
            //    Console.WriteLine(httpContext.Request.QueryString);
            }


        }




    }
}