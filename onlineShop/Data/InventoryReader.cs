using OnlineShop.Products;
using OnlineShop.Products.Entities;
using System.Collections.Generic;

namespace OnlineShop.Data
{
    /// <summary>
    /// Class used to populate static data in the inventory.
    /// </summary>
    public class InventoryReader
    {
        public ProductsDescriptions Descriptions;
        public ProductsStocks Stocks;

        public InventoryReader()
        {
            Descriptions = new ProductsDescriptions();
            Stocks = new ProductsStocks();
            AddData();
        }

        private void AddProduct(Product p, int count)
        {
            Descriptions.Products.Add(p.Id, p);
            Stocks.Stocks.Add(p.Id, count);
        }

        private void AddData()
        {
            AddProduct(new Book("Master and Margarita", 10, "book", "green", new Size(3, 3, 3, 150), 400, "Bulgakov"), 13);
            AddProduct(new Book("Pride and Prejudice", 11, "book", "blue", new Size(3, 3, 3, 160), 300, "Jane Austen"), 13);
            AddProduct(new Book("Happy yenotishches", 10, "book, snow", "green", new Size(3, 3, 3, 150), 400, "Yen McNotishe"), 0);
            AddProduct(new BackPack("Marmot 80", 100, "backpack", "green", new Size(3, 3, 3, 150), 80, "cotton"), 13);
            AddProduct(new BackPack("Marmot 40", 60, "backpack", "blue", new Size(3, 3, 3, 150), 40, "cotton"), 13);
            AddProduct(new Book("Christmas White", 13, "book", "green", new Size(3, 3, 3, 150), 400, "Bulgakov"), 13);
            AddProduct(new Book("Guide for painting eggs", 9, "book, ester, bunny", "white", new Size(3, 3, 3, 150), 400, "Bulgakov"), 13);
            AddProduct(new BackPack("Mother's packpack", 99, "backpack, mother's day, mother", "orange", new Size(40, 60, 5, 350), 50, "cotton"), 90);
            AddProduct(new Book("Love your Valentine", 99, "book, love, valentine, heart", "red", new Size(3, 3, 3, 160), 300, "John Azimov"), 13);

            Song song1 = new Song("song1", 1, "hiphop", 180, "Smith");
            Song song2 = new Song("song2", 1, "hiphop", 180, "Smith");
            Song song3 = new Song("song3", 1, "hiphop", 180, "Smith");
            Song song4 = new Song("song4", 1, "hiphop", 180, "Smith");
            Album album1 = new Album("Hip hop collection", 3, "hiphop", new List<Song>() { song1, song2, song3, song4 });
            AddProduct(song1, Constants.UNLIMITED);
            AddProduct(song2, Constants.UNLIMITED);
            AddProduct(song3, Constants.UNLIMITED);
            AddProduct(song4, Constants.UNLIMITED);
            AddProduct(album1, Constants.UNLIMITED);
        }
    }
}
