using BookStoreRazorWeb_Temp.Data;
using BookStoreRazorWeb_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreRazorWeb_Temp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty] //we need this to bind the object with page and cs file
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _context.Categories.Add(Category);
            _context.SaveChanges();
            TempData["success"] = "Category created succesfully";
            return RedirectToPage("Index");
        }
    }
}
