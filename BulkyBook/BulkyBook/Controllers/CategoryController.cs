using BulkyBook.Data;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkyBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;

        private readonly AppDbContext _appDbContext;
        public CategoryController(ILogger<CategoryController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _appDbContext.categories.AsEnumerable();
            return View(categories);
        }

        [HttpGet,ActionName("delete")]
        public IActionResult Index(int id)
        {
            if(id == 0 || id==null)
            {
                return NotFound();
            }
            var data = _appDbContext.categories.Find(id);
            if(data == null)
            {
                return NotFound(id);
            }
            _appDbContext.categories.Remove(data);
            _appDbContext.SaveChanges();
            TempData["Success"] = "Category Deleted successfully!";
            return RedirectToAction("index");
            //IEnumerable<Category> categories = _appDbContext.categories.AsEnumerable();
            //return View(categories);
        }

        public IActionResult Category()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Category(Category category)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.categories.Add(category);
                _appDbContext.SaveChanges();
                TempData["Success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var category = _appDbContext.categories.Find(id);
            if (category == null)
            { 
                return NotFound(); 
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.categories.Update(category);
                _appDbContext.SaveChanges();
                TempData["Success"] = "Category Edited successfully!";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}