using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    ToDoListContext _db;

    public CategoriesController(ToDoListContext db)
    {
      _db = db;
    }

    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> categories = _db.Categories.ToList();
      return View(categories);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(string categoryName)
    {
      Category newCategory = new Category(categoryName);
      return RedirectToAction("Index");
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

    //  [HttpGet("/categories/{id}")]
    // public ActionResult Show(int id)
    // {
    //     Dictionary<string, object> model = new Dictionary<string, object>();
    //     Category selectedCategory = Category.Find(id);
    //     List<Item> categoryItems = selectedCategory.Items;
    //     model.Add("category", selectedCategory);
    //     model.Add("items", categoryItems);
    //     return View(model);
    // }
  }
}