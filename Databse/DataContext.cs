using CoWorkSpace.Model.CoworkSpace;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoWorkSpace.Model.Persistence;

namespace CoWorkSpace.Databse
{
#nullable disable
    public class DataContext : IdentityDbContext<Appuser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }




        public DbSet<CoworkGeoLocation> cowork_Geo_Location { get; set; }
        public DbSet<CoworkSpace> coworkSpaces { get; set; }

        public DbSet<RerverationsModel> Reservers { get; set; }

        public DbSet<BlockedModel> BlockedUsers { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<Verfication> Verifications {get;set;}



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Appuser>().HasMany(u => u.coWorkSpaces).WithOne(u => u.owner).OnDelete(DeleteBehavior.Cascade);;
            builder.Entity<CoworkSpace>().HasMany(u => u.ReservedUsers).WithOne(x => x.Cowork).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CoworkSpace>().HasMany(u => u.Images).WithOne(x => x.coworkSpaceId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CoworkSpace>().HasMany(u => u.BlockedUsers).WithOne(x => x.CoworkId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<BlockedModel>().HasOne(u => u.CoworkId).WithMany(x => x.BlockedUsers);

        }
    }
}