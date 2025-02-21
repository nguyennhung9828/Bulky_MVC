using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicantDBContext _db;
        public CategoryController(ApplicantDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategory = _db.Categories.ToList();
            return View(objCategory);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category objCategory)
        {
            if (objCategory.Name == objCategory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(objCategory);
                _db.SaveChanges();
                TempData["success"] = "Category create successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Category create error";
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }

            Category? category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost(Category objCategory)
        {
            
            if (ModelState.IsValid)
            {
                _db.Categories.Update(objCategory);
                _db.SaveChanges();
                TempData["success"] = "Category update successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Category update error";
            return View(objCategory);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? objCategory = _db.Categories.Find(id);
            if (objCategory !=null)
            {
                _db.Categories.Remove(objCategory);
                _db.SaveChanges();
                TempData["success"] = "Category delete successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Category delete error";
            return View();
        }

    }
}
