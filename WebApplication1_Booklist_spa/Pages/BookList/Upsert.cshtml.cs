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
        public async Task<ActionResult> OnGet(int? id)
        {
            Book = new Book();
            if (id == null) return Page();//create
            ///edit
            Book = await _context.Books.FindAsync(id.GetValueOrDefault());
            if (Book == null) return NotFound();
            return Page();
        }
        public async Task<ActionResult> OnPost()
        {
            if (Book == null) return NotFound();
            if (!ModelState.IsValid) return NotFound();
            if (Book.Id == 0)
            
                //create
                await _context.Books.AddAsync(Book);
            
            else
            
                //edit
                _context.Books.Update(Book);
               await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}
