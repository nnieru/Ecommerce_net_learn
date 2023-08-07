using ECommereApp_Razor.Data;
using ECommereApp_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommereApp_Razor.Pages.Categories;

[BindProperties]
public class Delete : PageModel
{
    public Category Category { get; set; }
    private AplicationDbContext _context;

    public Delete(AplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    public void OnGet(int? id)
    {
        if (id != null && id != 0)
        {
            Category = _context.Categories.Find(id);
        }
    }

    public IActionResult OnPost()
    {
        Category? obj = _context.Categories.Find(Category.Id);

        if (obj == null)
        {
            return NotFound();
        }
        _context.Categories.Remove(obj);
        _context.SaveChanges();
        return RedirectToPage("Index");
    }
}