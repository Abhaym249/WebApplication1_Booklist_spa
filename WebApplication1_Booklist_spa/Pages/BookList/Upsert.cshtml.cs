using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1_Booklist_spa.Data;
using WebApplication1_Booklist_spa.Models;

namespace WebApplication1_Booklist_spa.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public UpsertModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task<ActionResult>OnGet(int? id)
        {
            Book = new Book();
            if (id == null) return Page();//create
            ///edit
            Book = await _context.Books.FindAsync(id.GetValueOrDefault());
            if (Book == null) return NotFound();
            return Page();
        }
    }
}
