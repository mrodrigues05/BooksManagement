using System.ComponentModel.DataAnnotations;

namespace BooksManagement.Entities
{
    public class Book
    {
        public Book() 
        {
            IsDeleted = true;
        }

        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }


        //met atualização
        public void Update(string title, string author, string genre, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Author = author;
            Genre = genre;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

    }
}
