using Microsoft.EntityFrameworkCore;
using WebApplication1_Booklist_spa.Models;

namespace WebApplication1_Booklist_spa.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {

        }
        public DbSet<BookList> BookLists { get; set; }
    }
}
