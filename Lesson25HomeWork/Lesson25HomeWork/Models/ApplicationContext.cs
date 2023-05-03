using Microsoft.EntityFrameworkCore;

namespace Lesson25HomeWork.Models
{
    public class ApplicationContext : DbContext
    {
    public DbSet<IndexFormModel> Users { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
    }
};
