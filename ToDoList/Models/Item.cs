using System.Collections.Generic;
using System;

namespace ToDoList.Models
{
  public class Item
  {
    public int ItemId { get; set; }
    public string Description { get; set; }
    public bool Completed {get;set;} = false;
    public virtual ICollection<CategoryItem> Categories { get; }
    public DateTime DueDate {get;set;}

    public Item()
    {
      this.Categories = new HashSet<CategoryItem>();
    }
  }
}