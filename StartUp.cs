using System.Text;
using CoWorkSpace.Application;
using CoWorkSpace.Auth;
using CoWorkSpace.Databse;
using CoWorkSpace.Interfaces;
using CoWorkSpace.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using CoWorkSpace.Application.ChatHub;
using CoWorkSpace.CloudService;
using CoWorkSpace.Helper;

namespace CoWorkSpace
{
    public class Startup
    {

        public IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            var emailConfig = configuration.GetSection("EmailConfigration").Get<EmailConfigration>();
            services.AddAuthorization();
            services.AddTransient<IUserAccessor, UserAccessor>();
            services.AddScoped<ICoworKSpaceRepo, CoworKSpaceService>();
            services.AddScoped<IUserServiceRepo, UserService>();
            services.AddScoped<IPhotoAccessor, PhotosManger>();
            services.AddTransient<IAuthService, AuthService>();
            services.Configure<JWT>(configuration.GetSection("JWT"));
            services.AddIdentity<Appuser, IdentityRole>().AddEntityFrameworkStores<DataContext>();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.Configure<CloudinarySetting>(configuration.GetSection("Cloudinary"));
            services.AddAutoMapper(typeof(Mapper).Assembly);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "CoWorkSpace", Version = "v1" });
            });
            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt=>{
            //   opt.TokenValidationParameters = new TokenValidationParameters{
            //       ValidateIssuerSigningKey = true,
            //       ValidateIssuer = false,
            //        ValidateAudience = false,
            //          IssuerSigningKey = key,
            //   };
            //       opt.Events = new JwtBearerEvents{
            //          OnMessageReceived = context => {
            //              var  accessToken = context.Request.Query["access_token"];
            //              var path = context.HttpContext.Request.Path;
            //              if(!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/ReservationHub"))){
            //                  context.Token = accessToken;
            //              }
            //             return Task.CompletedTask;
            //          }
            //      }; 
            // });

            services.AddCors(opt => opt.AddPolicy("CorsPolicy",
              policy =>
              {
                  policy.AllowAnyMethod().AllowAnyHeader().AllowCredentials().AllowAnyMethod().
                  WithOrigins("https://localhost:3000", "http://localhost:3000", "http://localhost:3001", "http://62.114.101.3");

              }));


            // JWT Service Register
           
            services.AddAuthentication(options =>
      {
          options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(o =>
      {
          o.RequireHttpsMetadata = false;
          o.SaveToken = false;
          o.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuerSigningKey = true,
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidIssuer = configuration["JWT:Issuser"],
              ValidAudience = configuration["JWT:Audience"],
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
          };
      });

            services.AddSignalR();

        }
        //"https://192.168.1.30:19000", "http://192.168.1.30:19002/","http://192.168.1.30:19002"




        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoWorkSpace v1"));
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chat");
            });
        }



    }
}