using Microsoft.EntityFrameworkCore;

namespace OnRepository.EFCore.WebAPI.Sample.Data
{
    public class AppDbContext : ReposDbContext
    {
        public AppDbContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
