using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1_Booklist_spa.Data;

namespace WebApplication1_Booklist_spa.Pages.BookList
{
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
    }
}
