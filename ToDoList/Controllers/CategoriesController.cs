using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    ToDoListContext _db;

    public CategoriesController(ToDoListContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> categories = _db.Categories.ToList();
      return View(categories);
    }

    public ActionResult Create()
    {
      return View("Create");
    }

    [HttpPost]
    public ActionResult Create(string Name)
    {
      Category newCategory = new Category() { Name = Name };
      _db.Categories.Add(newCategory);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [HttpPost]
    public ActionResult Edit(Category category)
    {
      _db.Entry(category).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Category thisCategory = _db.Categories.Include(Category => Category.Items).ThenInclude(join => join.Item).FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    public ActionResult Delete(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      _db.Categories.Remove(thisCategory);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}








// [HttpPost("/categories/{categoryId}/items")]
// public ActionResult Create(int categoryId, string itemDescription)
// {
//   Dictionary<string, object> model = new Dictionary<string, object>();
//   Category foundCategory = Category.Find(categoryId);
//   Item newItem = new Item(itemDescription);
//   foundCategory.AddItem(newItem);
//   List<Item> categoryItems = foundCategory.Items;
//   model.Add("items", categoryItems);
//   model.Add("category", foundCategory);
//   return View("Show", model);
// }
