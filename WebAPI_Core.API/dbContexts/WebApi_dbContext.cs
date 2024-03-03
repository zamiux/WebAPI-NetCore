using Microsoft.EntityFrameworkCore;
using WebAPI_Core.API.Entites;

namespace WebAPI_Core.API.dbContexts
{
    public class WebApi_dbContext:DbContext
    {
        public WebApi_dbContext(DbContextOptions<WebApi_dbContext> options):base(options)
        {
             
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite();
        //    base.OnConfiguring(optionsBuilder);
        //}

        #region Entites Dbset
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointOfInterests { get; set; }
        #endregion

        #region Seed Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Entity Insert Data
            modelBuilder.Entity<City>()
                .HasData(
                    new City()
                    {
                        Id = 1,
                        Name = "Tehran",
                        Description = "Tehran is Description"
                    },
                    new City()
                    {
                        Id = 2,
                        Name = "Shiraz",
                        Description = "Shiraz is Description"
                    },
                    new City()
                    {
                        Id = 3,
                        Name = "Esfahan",
                        Description = "Esfahan is Description"
                    },
                    new City()
                    {
                        Id = 4,
                        Name = "Kish",
                        Description = "Kish is Description"
                    }
                );
            #endregion

            #region Entity Insert Data
            modelBuilder.Entity<PointOfInterest>()
                .HasData(
                new PointOfInterest()
                {
                    Id = 1,
                    CityId = 1,
                    Name = "TehranPars"
                },
                new PointOfInterest()
                {
                    Id = 2,
                    CityId = 1,
                    Name = "Jeyhoon"
                }
                );
            #endregion
        }
        #endregion
    }
}
