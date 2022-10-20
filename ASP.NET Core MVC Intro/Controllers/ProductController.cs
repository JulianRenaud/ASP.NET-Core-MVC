using ASP.NET_Core_MVC_Intro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_MVC_Intro.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productrepository;


        public ProductController(IProductRepository productrepository)
        {
            _productrepository = productrepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _productrepository.GetAllProducts();
            return View(products);
        }

        public IActionResult ViewProduct(int id)
        {
            var product = _productrepository.GetProduct(id);
            return View(product);
        }


    }
}
