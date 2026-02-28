using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1_Booklist_spa.Data;
using WebApplication1_Booklist_spa.Models;

namespace WebApplication1_Booklist_spa.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await _context.Books.ToListAsync();
        }
        public async Task<ActionResult> OnPostDelete(int id)
        {
            var bookinDb =  await _context.Books.FindAsync(id);
            if(bookinDb == null) return NotFound();
            _context.Books.Remove(bookinDb);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
