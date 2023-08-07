using ECommereApp_Razor.Data;
using ECommereApp_Razor.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ECommereApp_Razor.Pages.Categories;

public class Index : PageModel
{
    private readonly AplicationDbContext _context;
    public List<Category> CategoryList { get; set; }

    public Index(AplicationDbContext dbContext)
    {
        _context = dbContext;
    }
    
    public void OnGet()
    {
        CategoryList = _context.Categories.ToList();
    }
}