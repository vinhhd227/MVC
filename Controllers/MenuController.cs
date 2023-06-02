using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

public class MenuController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWebHostEnvironment _env;
    private ProductService _productService;

    public MenuController(ILogger<HomeController> logger, IWebHostEnvironment env, ProductService productService)
    {
        _logger = logger;
        _env = env;
        _productService = productService;
    }
    public List<ProductModel> products { set; get; }
    // public const int ITEMS_PER_PAGE = 12;
    // [BindProperty(SupportsGet = true, Name = "p")]
    // public int currentPage { set; get; }
    // public int countPages { set; get; }
    // public class MenuInfo
    // {
    //     public List<ProductModel> products { set; get; }
    //     public const int ITEMS_PER_PAGE = 12;
    //     [BindProperty(SupportsGet = true, Name = "p")]
    //     public int currentPage { set; get; }
    //     public int countPages { set; get; }
    // }
    // [BindProperty]
    // public MenuInfo menuInfo { set; get; }

    public IActionResult Category(int? id)
    {
        products = _productService.AllProduct();
        if (id != null)
        {
            List<ProductModel> productsById = (from p in products where p.CateId == id select p).ToList<ProductModel>();
            ViewData["products"] = productsById;
            return View();
        }
        else
        {
            ViewData["products"] = products;
            return View();
        }
        // menuInfo.products = _productService.AllProduct();
        // menuInfo.currentPage = 0;
        // menuInfo.countPages = from p in menuInfo.products where p.CateId == 1 select p;
        // if (menuInfo.currentPage < 1) menuInfo.currentPage = 1;
        // if (menuInfo.currentPage > menuInfo.countPages) menuInfo.currentPage = menuInfo.countPages;

    }

    public IActionResult Product()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
