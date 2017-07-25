using onlineShop.App;
using onlineShop.Data;
using onlineShop.Products;
using System.Text;

namespace onlineShop.Pages
{
    public class ProductPage : IPage
    {
        private Product _product;
        private NavigationData _navData;

        public ProductPage(Product product)
        {
            _product = product;
        }

        public string OnNavigatedTo(NavigationData data)
        {
            _navData = data;
            StringBuilder menu = new StringBuilder();
            menu.AppendLine($"{_product.Name} - {_product.Price:C}");
            menu.AppendLine("-------------------");
            if (_product is PhysicalProduct)
            {
                PhysicalProduct physicalProduct = _product as PhysicalProduct;
                menu.AppendLine($"dimentions: {physicalProduct.Size.Depth}x{physicalProduct.Size.Height}x{physicalProduct.Size.Width}");
                menu.AppendLine($"weight: { physicalProduct.Size.Weight}");
                menu.AppendLine($"color: {physicalProduct.Color}");

                if (physicalProduct is Book)
                {
                    Book book = physicalProduct as Book;
                    menu.AppendLine($"number of pages: {book.NumberOfPages}");
                    menu.AppendLine($"Author: {book.Author}");
                } else if (physicalProduct is BackPack)
                {
                    BackPack backPack = physicalProduct as BackPack;
                    menu.AppendLine($"volume: {backPack.Volume}");
                    menu.AppendLine($"material: {backPack.Material}");
                }
            }
            else
            {
                Song song = _product as Song;
                menu.AppendLine($"Artist: {song.Artist}\nDuration: {song.Duration} sec");
            }
            menu.AppendLine("");
            if (_navData.Cart.Products.ContainsKey(_product))
            {
                menu.AppendLine("1. Remove from the cart.");
            } else if (_navData.StocksReader.GetProductStock(_product.Id) != 0)
            {
                menu.AppendLine("1. Add to the cart");
            }

            menu.AppendLine("2. Go to the cart page.\n3. Go to the main page.\n----------");

            return menu.ToString();
        }

        public IPage OnUserInput(string input)
        {
            int userSelection = 0;
            if (int.TryParse(input, out userSelection))
            {
                if (userSelection == 1)
                {
                    if (_navData.Cart.Products.ContainsKey(_product))
                    {
                        _navData.Cart.RemoveProduct(_product);
                    } else
                    {
                        _navData.Cart.TryAddProduct(_product);
                    } 
                }
                else if (userSelection == 2)
                {
                    return new CartPage();
                }
                else if (userSelection == 3)
                {
                    return new MainPage();
                }
            }
            return new ProductPage(_product);
        }


    }
}
