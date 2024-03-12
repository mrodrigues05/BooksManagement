using BooksManagement.Entities;
using Microsoft.EntityFrameworkCore;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }

}

