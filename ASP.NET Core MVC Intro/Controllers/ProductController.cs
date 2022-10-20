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

        public IActionResult UpdateProduct(int id)
        {
            Product prod = _productrepository.GetProduct(id);
            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            _productrepository.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        public IActionResult InsertProduct()
        {
            var prod = _productrepository.AssignCategory();
            return View(prod);
        }
        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            _productrepository.InsertProduct(productToInsert);
            return RedirectToAction("Index");
        }

    }
}
