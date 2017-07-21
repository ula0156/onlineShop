using onlineShop.Managers;
using onlineShop.Products;
using onlineShop.Products.Entities;

namespace onlineShop
{
    /// <summary>
    /// Class used to populate static data in the inventory. This is only used to test other features
    /// until we start using the database.
    /// </summary>
    public class DatabaseInitializer
    {
        public void InitializeDatabase(ProductsManager productsManager)
        {
            productsManager.TryAddProduct(new Book("Master and Margarita", 10, "book", "green", new Size(3, 3, 3, 150), 400, "Bulgakov"), 13);
            productsManager.TryAddProduct(new Book("Pride and Prejudice", 11, "book", "blue", new Size(3, 3, 3, 160), 300, "Jane Austen"), 13);
            productsManager.TryAddProduct(new Book("Happy yenotishches", 10, "book, snow", "green", new Size(3, 3, 3, 150), 400, "Yen McNotishe"), 0);
            productsManager.TryAddProduct(new BackPack("Marmot 80", 100, "backpack", "green", new Size(3, 3, 3, 150), 80, "cotton"), 13);
            productsManager.TryAddProduct(new BackPack("Marmot 40", 60, "backpack", "blue", new Size(3, 3, 3, 150), 40, "cotton"), 13);
            productsManager.TryAddProduct(new Book("Christmas White", 13, "book", "green", new Size(3, 3, 3, 150), 400, "Bulgakov"), 13);
            productsManager.TryAddProduct(new Book("Guide for painting eggs", 9, "book, ester, bunny", "white", new Size(3, 3, 3, 150), 400, "Bulgakov"), 13);
            productsManager.TryAddProduct(new BackPack("Mother's packpack", 99, "backpack, mother's day, mother", "orange", new Size(40, 60, 5, 350), 50, "cotton"), 90);
            productsManager.TryAddProduct(new Book("Love your Valentine", 99, "book, love, valentine, heart", "red", new Size(3, 3, 3, 160), 300, "John Azimov"), 13);
            productsManager.TryAddProduct(new Song("song1", 1, "hiphop", 180, "Smith"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("song2", 1, "hiphop", 180, "Smith"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("song3", 1, "hiphop", 180, "Smith"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("song4", 1, "hiphop", 180, "Smith"), Constants.UNLIMITED);
        }
    }
}
