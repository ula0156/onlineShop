using onlineShop.App;
using onlineShop.Data;
using onlineShop.Products;
using System.Text;

namespace onlineShop.Pages
{
    public class CartProductPage: IPage
    {
        private NavigationData _navData;
        private Product _product;

        public CartProductPage(Product product)
        {
            _product = product;
        }

        public string OnNavigatedTo(NavigationData data)
        {
            _navData = data;
            StringBuilder menu = new StringBuilder();
            if (_product is PhysicalProduct)
            {
                menu.AppendLine($" {_product.Name} - Number of copies: { _navData.Cart.Products[_product]}");
            }
            else
            {
                menu.AppendLine($" {_product.Name}");
            }
            menu.AppendLine("-------------------");
            if (_product is PhysicalProduct)
            {
                menu.AppendLine($"1. Add copy to the cart");
            }
            menu.AppendLine($"2. Remove product from the cart");
            menu.AppendLine("");
            menu.AppendLine("A. Go to the product page");
            menu.AppendLine("B. Go to the main page");
            menu.AppendLine("C. Return to the cart page");

            return menu.ToString();
        }

        public IPage OnUserInput(string input)
        {
            if (input == "1")
            {
                _navData.Cart.TryAddProduct(_product);
                return new CartProductPage(_product);
            } 
            else if (input == "2")
            {
                _navData.Cart.RemoveProduct(_product);
                return new CartProductPage(_product);
            }
            else if (input.ToUpper() == "A")
            {
                return new ProductPage(_product);
            }
            else if (input.ToUpper() == "B")
            {
                return new MainPage();
            }
            else if (input.ToUpper() == "C")
            {
                return new CartPage();
            }
            return new CartProductPage(_product);
        }
    }
}
