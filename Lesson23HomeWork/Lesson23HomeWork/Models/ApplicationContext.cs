using Lesson23HomeWork.Models.EFDto_Lesson23HomeWork;
using Microsoft.EntityFrameworkCore;

namespace Lesson23HomeWork.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Book>().HasData(
                    new Book { Id = 1, Name = "Don Quixote", Author = "Miguel de Cervantes", Description = "Alonso Quixano, a retired country gentleman in his fifties, lives in an unnamed section of La Mancha with his niece and a housekeeper. He has become obsessed with books of chivalry, and believes th..." },
                    new Book { Id = 2, Name = "The Great Gatsby", Author = " F. Scott Fitzgerald", Description = "The novel chronicles an era that Fitzgerald himself dubbed the \"Jazz Age\". Following the shock and chaos of World War I, American society enjoyed unprecedented levels of prosperity during the \"roar..." },
                    new Book { Id = 3, Name = "War and Peace", Author = "Leo Tolstoy", Description = "Epic in scale, War and Peace delineates in graphic detail events leading up to Napoleon's invasion of Russia, and the impact of the Napoleonic era on Tsarist society, as seen through the eyes of fi..." },
                    new Book { Id = 4, Name = "The Divine Comedy", Author = "Dante Alighieri", Description = "Belonging in the immortal company of the great works of literature, Dante Alighieri's poetic masterpiece, The Divine Comedy, is a moving human drama, an unforgettable visionary journey through the ..." }
                    );
        }
    }
}
