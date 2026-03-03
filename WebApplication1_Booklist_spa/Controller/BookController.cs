using System.Linq;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1_Booklist_spa.Data;

namespace WebApplication1_Booklist_spa.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var booklist = _context.Books.ToList();
            return Json(new { data = booklist });
        
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var bookInDb = _context.Books.Find(id);
            if(bookInDb == null)
                return Json(new {Success=false,messaeg="Unable to delete data !!!" });
            _context.Books.Remove(bookInDb);
            _context.SaveChanges();
            return Json(new { Success = true, message = "Data deleted successfully !!!" });
        }
    }
}
