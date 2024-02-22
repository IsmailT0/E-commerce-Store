using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext db) { 
            _context = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _context.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create() { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order can not be matched the Name.");
            }
            //if (obj.Name != null && obj.Name == "test")
            //{
            //    ModelState.AddModelError("", "Test is a invalid name.");
            //}
            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return View();
            
        }

        public IActionResult Edit(int? id)
        {
            if(id == 0 || id == null) { 
                return NotFound();
            }

            Category? categoryFromDb = _context.Categories.Find(id);
            //Category? categoryFromDb1 = _context.Categories.FirstOrDefault(u => u.Id==id);
            //Category? categoryFromDb2 = _context.Categories.Where(u=> u.Id == id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            //if (obj.Name != null && obj.Name == "test")
            //{
            //    ModelState.AddModelError("", "Test is a invalid name.");
            //}
            
            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Category? categoryFromDb = _context.Categories.Find(id);
            //Category? categoryFromDb1 = _context.Categories.FirstOrDefault(u => u.Id==id);
            //Category? categoryFromDb2 = _context.Categories.Where(u=> u.Id == id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {

            //if (obj.Name != null && obj.Name == "test")
            //{
            //    ModelState.AddModelError("", "Test is a invalid name.");
            //}
            Category? obj = _context.Categories.Find(id);
            if (obj == null) { return NotFound(); }
            
            _context.Categories.Remove(obj);

            _context.SaveChanges();

            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");


        }

    }
}
