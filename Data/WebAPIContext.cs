using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext (DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPI.Models.EntityFrameworkModel> EntityFrameworkModel { get; set; }
    }
}
