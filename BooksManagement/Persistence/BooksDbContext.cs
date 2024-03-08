using BooksManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement.Persistence
{
    public class BooksDbContext 
    {
        public List<Book> Books { get; set; }

        public BooksDbContext() 
        { 
            Books = new List<Book>();
        }

    }
}
