using onlineShop.App;
using OnlineShop.Data;
using OnlineShop.Products;
using System.Text;

namespace OnlineShop.Pages
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
            menu.AppendLine($" {_product.Name}\n----------\n1. Add copy to the cart\n2. Remove product from the cart");
            menu.AppendLine($"Number of copies: { _navData.Cart.Products[_product]}");
            menu.AppendLine($"A. Go to the product page\nB. Go to the main page\nC. Return to the cart page");
            return menu.ToString();
        }

        public IPage OnUserInput(string input)
        {
            if (input == "1")
            {
                _navData.Cart.TryAddProduct(_product);
            } 
            else if (input == "2")
            {
                _navData.Cart.RemoveProduct(_product); 
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
