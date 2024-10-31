using DaodApi.Model;
using Microsoft.EntityFrameworkCore;

namespace DaodApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<FormDataModel> FormData { get; set; }
    }
}
