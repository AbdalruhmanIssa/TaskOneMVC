using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        ApplicationDBContext context=new ApplicationDBContext();
        public ViewResult Index()
        {
            var cats = context.Categories.ToList();
            return View(cats);
        }
        public ViewResult Details(int id)
        {
           var cat=context.Categories.FirstOrDefault(c => c.Id == id);
            return View(cat);
        }
        public ViewResult Create()
        {
            return View(new Categorey ());
        }

        [HttpPost]
        public IActionResult Create(Categorey category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            bool nameExist=context.Categories.Any(c => c.Name == category.Name);
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            if (category is null)
            {
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Categorey category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            bool nameExists = context.Categories.Any(c => c.Name == category.Name && c.Id != category.Id);
            if (nameExists)
            {
                ModelState.AddModelError("Name", "category name already exist");
                return View(category);
            }

            var existingCategory = context.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return RedirectToAction("Index");
            }

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public RedirectToActionResult Delete(int id)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == id);

            if (category is null)
            {
                return RedirectToAction("Index");
            }

            context.Categories.Remove(category);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
