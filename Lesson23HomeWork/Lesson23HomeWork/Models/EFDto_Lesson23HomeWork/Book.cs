using System.ComponentModel.DataAnnotations;
namespace Lesson23HomeWork.Models.EFDto_Lesson23HomeWork
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

    }
}
