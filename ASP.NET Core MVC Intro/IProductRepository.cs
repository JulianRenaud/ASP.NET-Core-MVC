using ASP.NET_Core_MVC_Intro.Models;

namespace ASP.NET_Core_MVC_Intro
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProduct(int id);
    }
}