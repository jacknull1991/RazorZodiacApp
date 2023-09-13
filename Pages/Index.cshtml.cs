using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZodiacApp.Models;

namespace ZodiacApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [Display(Name = "Year")]
    public int Year { get; set; }
    private readonly int _currentYear = DateTime.Now.Year;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        ViewData["Zodiac"] = null;
        ViewData["Error"] = null;
    }

    public void OnPost(int year) 
    {
        if (year < 1900 || year > _currentYear + 1) 
        {
            ViewData["Error"] = "error";
            ViewData["Zodiac"] = null;
        } else 
        {
            ViewData["Error"] = null;
            ViewData["Zodiac"] = Utils.GetZodiac(year);
        }
        
    }
}
