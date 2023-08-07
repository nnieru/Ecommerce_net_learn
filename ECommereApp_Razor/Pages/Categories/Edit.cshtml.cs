using ECommereApp_Razor.Data;
using ECommereApp_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommereApp_Razor.Pages.Categories;

[BindProperties]
public class Edit : PageModel
{

    public Category Category { get; set; }
    private readonly AplicationDbContext _context;

    public Edit(AplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    public void OnGet(int? id)
    {
        if (id != null || id != 0)
        {
            Category = _context.Categories.Find(id);
        }
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Update(Category);
            _context.SaveChanges();
            TempData["success"] = "Category updated successfully!";
            return RedirectToPage("Index");
        }

        return Page();
    }
}