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
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categorey category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
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
