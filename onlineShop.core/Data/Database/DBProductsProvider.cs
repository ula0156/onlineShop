using System;
using System.Linq;
using onlineShop.Products;

namespace onlineShop.Data.Database
{
    public class DBProductsProvider : IProductsProvider
    {
        private ProductsModel _productsModel;

        public DBProductsProvider()
        {
            _productsModel = new ProductsModel();
        }

        public IQueryable<Product> GetProducts()
        {
            return _productsModel.Products;
        }

        public bool TryAddProduct(Product product)
        {
            if (!_productsModel.Products.Any(p => p.Id == product.Id))
            {
                _productsModel.Products.Add(product);
                _productsModel.SaveChanges();
                return true;
            }

            return false;
        }

        public bool TryRemoveProduct(Guid productId)
        {
            var product = _productsModel.Products.FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                _productsModel.Products.Remove(product);
            }

            return true;
        }
    }
}
