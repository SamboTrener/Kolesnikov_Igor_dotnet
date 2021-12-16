using Microsoft.EntityFrameworkCore;

namespace hw10.Models
{
    public class ApplicationContext : DbContext
    {
        
        public DbSet<ExpressionCache> ExpressionCaches { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}