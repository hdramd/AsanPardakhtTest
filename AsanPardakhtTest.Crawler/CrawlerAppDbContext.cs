using Microsoft.EntityFrameworkCore;

namespace AsanPardakhtTest.Crawler
{
    public class CrawlerAppDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQL2019;Database=CrawlerDb;User Id=sa;Password=123;");
        }
    }
}
