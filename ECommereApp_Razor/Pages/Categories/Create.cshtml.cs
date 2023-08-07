using ECommereApp_Razor.Data;
using ECommereApp_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommereApp_Razor.Pages.Categories;
 
[BindProperties ]
public class Create : PageModel
{

    
    public Category Category { get; set; }
    private readonly AplicationDbContext _context;

    public Create(AplicationDbContext dbContext)
    {
        _context = dbContext;
    }
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        _context.Categories.Add(Category);
        _context.SaveChanges();
        TempData["success"] = "Data added sucessfully!";
        return RedirectToPage("Index"); 
    }
}