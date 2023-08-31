using Microsoft.EntityFrameworkCore;
using praticeAPI.Models.Domain;

namespace praticeAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Image> Images { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // seed data from difficuties

            var difficutly = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id= Guid.Parse("8527976b-94ed-4bc8-96f1-e9ade2386882"),
                    Name="Easy"
                },
                new Difficulty()
                {
                    Id= Guid.Parse("40c7c352-af79-42b6-85aa-cfdf1e4034ac"),
                    Name="Medium"
                },
                new Difficulty()
                {
                    Id= Guid.Parse("d73209ae-079a-4191-9227-973fd1d398ab"),
                    Name="Hard"
                }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficutly);

            // seed data from region

            var region = new List<Region>()
            {
                new Region()
                {
                    Id=Guid.Parse("ca8ded17-e6a9-475c-9feb-f7792ea7ce83"),
                    Name="India",
                    Code="IND",
                    ImageURL="https://facts.net/wp-content/uploads/2023/06/49-facts-about-india-1688115169.jpeg"
                },
                new Region()
                {
                    Id=Guid.Parse("47f10a09-ca9d-49b9-bb75-26e730e5eb5b"),
                    Name="United States of America",
                    Code="USA",
                    ImageURL="https://d.newsweek.com/en/full/1865970/statue-liberty.jpg"
                },
                new Region()
                {
                    Id=Guid.Parse("72d75104-5c01-4284-83ef-f7e8e78e258c"),
                    Name="United KingDom",
                    Code="UK",
                    ImageURL="https://fullsuitcase.com/wp-content/uploads/2021/01/Tower-Bridge-in-London-UK.jpg.webp"
                },
                new Region()
                {
                    Id=Guid.Parse("3902bdb6-732a-4272-8d1c-562ebf6ae914"),
                    Name="Japan",
                    Code="JP",
                    ImageURL="https://www.exoticca.com/us/blog/wp-content/uploads/2021/08/Japan-sightseeing-BLOG-header-930x360.png"
                },
                new Region()
                {
                    Id=Guid.Parse("1a5b973d-5222-4d5a-8936-9aa8999d1336"),
                    Name="China",
                    Code="CN",
                    ImageURL="https://www.planetware.com/photos-large/CHN/china-great-wall-and-mountain.jpg"
                },
                new Region()
                {
                    Id=Guid.Parse("0ca97531-1fb7-431b-9b11-c13d6b04b8c8"),
                    Name="Pakistan",
                    Code="PAK",
                    ImageURL="https://c.tribune.com.pk/2015/12/final-6.jpg"
                },
            };

            modelBuilder.Entity<Region>().HasData(region);
        }
    }
}
