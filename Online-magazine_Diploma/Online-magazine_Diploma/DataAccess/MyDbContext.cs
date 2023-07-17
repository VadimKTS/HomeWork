using Microsoft.EntityFrameworkCore;
using Online_magazine_Diploma.DataAccess.Entity;
using Online_magazine_Diploma.KDF;
using System.Text;

namespace Online_magazine_Diploma.DataAccess
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "admin",
                    Email = "admin@mail.com",
                    PasswordHash = HashPasswordKDF.HashPassword("admin"),
                    PhoneNumber = "+ 375 29 000 00 00",
                    IsDeleted = false,
                    UserRole = UserRole.Administrator
                }
                );
			modelBuilder.Entity<Titel>().HasData(
				new Titel
				{
					Id = Guid.NewGuid(),
					Name = "Default Title Name",
                    ActivateDate = DateTime.Now,
                    ImageAddress = "default",
				}
				);
		}

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ArticleType> ArticleTypes { get; set; }
        public DbSet<Titel> Titels { get; set; }
    }
}
