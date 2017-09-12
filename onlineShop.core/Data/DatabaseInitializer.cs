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
            productsManager.TryAddProduct(new Book("Master and Margarita", 10, "book", "green", new Size(3, 3, 3, 150), 400, "Bulgakov", "fiction"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Pride and Prejudice", 11, "book", "blue", new Size(3, 3, 3, 160), 535, "Jane Austen", "romance"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Foundation", 10, "book, snow", "green", new Size(3, 3, 3, 150), 420, "Isaak Azimov", "sci-fi"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Foundation 2", 10, "book", "green", new Size(3, 3, 3, 150), 230, "Isaak Azimov", "sci-fi"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Harry Potter", 13, "book adventure", "green", new Size(3, 3, 3, 150), 230, "Oscar", "fiction"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("1984", 9, "book", "white future", new Size(3, 3, 3, 150), 400, "Notith", "sci-fi"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("The little Paris", 9, "book", "white", new Size(3, 3, 3, 150), 254, "Nina Gerge", "romance"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("The trial of Apalo", 99, "book adventure", "red", new Size(3, 3, 3, 160), 130, "Rick Riordan", "adventure"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("The call of the wind", 99, "book romantic", "red", new Size(3, 3, 3, 160), 300, "Jack London", "adventure"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Unforgettable", 1, "song energy", 180, "Jay z", "hip-hop"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("That's what I like", 1, "song energetic energy", 180, "Bruno Mars", "hip-hop"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("So what", 1, "song meditation", 180, "Miles Davis", "jazz"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Strange fruit", 1, "song active", 180, "Billie Hiliday", "jazz"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Thunderbird", 1, "song romantic", 180, "Hans Zimmer", "electronic"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Time", 1, "song mindful", 180, "Hans Zimmer", "electronic"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Confluence", 1, "song motivating", 180, "John Williams", "soundtrack"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("A window to the past", 1, "song romance", 180, "John Williams", "soundtrack"), Constants.UNLIMITED);
        }
    }
}
