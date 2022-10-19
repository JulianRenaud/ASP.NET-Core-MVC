using ASP.NET_Core_MVC_Intro.Models;
using Dapper;
using System.Data;

namespace ASP.NET_Core_MVC_Intro
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }
    }
}
