using onlineShop.Data;
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
        public void InitializeDatabase(IProductsReader reader, ProductsManager productsManager)
        {
            var products = reader.GetProducts();
            if (products.GetEnumerator().MoveNext())
            {
                // There are already products in the database, not adding them again.
                return;
            }

            productsManager.TryAddProduct(new Book("Black Spring", 10, "book", "Assets/Images/fantasy/1.jpg","", new Size(3, 3, 3, 150), 400, "Alison Croggon", "fantasy"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Descendant", 11, "book", "Assets/Images/fantasy/2.jpg", "", new Size(3, 3, 3, 160), 535, "Lesley", "fantasy"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Start Carrier", 10, "book", "Assets/Images/fantasy/3.jpg", "", new Size(3, 3, 3, 150), 420, "Ian Duglas", "fantasy"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Once Lost", 10, "book", "Assets/Images/fantasy/4.jpg", "", new Size(3, 3, 3, 150), 230, "Stephan Morse", "fantasy"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Chosen Maiden", 13, "book fiction", "Assets/Images/fiction/1.jpg", "", new Size(3, 3, 3, 150), 230, "Eva Stachniak", "fiction"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("The end of the point", 9, "book novel", "Assets/Images/fiction/2.jpg", "",new Size(3, 3, 3, 150), 400, "Elizabeth Graver", "fiction"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("The girl who knew too much", 9, "book", "Assets/Images/fiction/3.jpg", "", new Size(3, 3, 3, 150), 254, "Vikrant Khanna", "fiction"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Year One", 20, "book romance", "Assets/Images/fiction/4.jpg", "", new Size(3, 3, 3, 160), 130, "Nora Roberts", "fiction"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("The power of habit", 20, "book self help", "Assets/Images/self-improvment/2.jpg", "", new Size(3, 3, 3, 160), 300, "Charles Duhige", "self-improvment"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Big magic", 21, "book self help", "Assets/Images/self-improvment/1.jpg", "", new Size(3, 3, 3, 160), 300, "Elizabeth Gilbert", "self-improvment"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Wild Ideas", 19, "book self help", "Assets/Images/self-improvment/3.jpg", "", new Size(3, 3, 3, 160), 300, "Cathy Wild", "self-improvment"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Yourself First", 18, "book self help", "Assets/Images/self-improvment/4.jpg", "", new Size(3, 3, 3, 160), 300, "Iyanla Vanzant", "self-improvment"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Girl out of water", 9, "book romance", "Assets/Images/romance/1.jpg", "", new Size(3, 3, 3, 160), 300, "Laura Silverman", "romance"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Lord of Shadows", 12, "book romance", "Assets/Images/romance/2.jpg", "", new Size(3, 3, 3, 160), 300, "Cassandra Clare", "romance"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("City of Lost Souls", 14, "book romance", "Assets/Images/romance/3.jpg", "", new Size(3, 3, 3, 160), 300, "Cassandra Clare", "romance"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Book("Secrets she kept", 99, "romance", "Assets/Images/romance/4.jpg", "", new Size(3, 3, 3, 160), 300, "Cathy Gohlke", "romance"), Constants.UNLIMITED);


            productsManager.TryAddProduct(new Song("Eine kleine Nachtmusik", 5, "music classical", "Assets/Images/classical/1.jpg", 30, "Wolfgang Mozart", "classical"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Requiem K626_Introitus Requiem Aeternam", 5, "music classical", "Assets/Images/classical/2.jpg", 35, "Wolfgang Mozart", "classical"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Symphony #5", 5, "music classical", "Assets/Images/classical/3.jpg", 30, "Beethoven", "classical"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Symphony #9", 5, "music classical", "Assets/Images/classical/4.jpg", 40, "Beethoven", "classical"), Constants.UNLIMITED);

            productsManager.TryAddProduct(new Song("Lean On", 2, "music electronic modern", "Assets/Images/electronic/1.jpg", 5, "DJ Snake", "electronic"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Don't let me down", 3, "music electronic modern", "Assets/Images/electronic/2.jpg", 4, "Daya", "electronic"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Get Lucky", 1, "music electronic modern", "Assets/Images/electronic/3.jpg", 3, "Daft Punk", "electronic"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Wake me up", 2, "music electronic modern", "Assets/Images/electronic/4.jpg", 4, "Avici", "electronic"), Constants.UNLIMITED);

            productsManager.TryAddProduct(new Song("Misty", 3, "live jazz music", "Assets/Images/jazz/1.jpg", 7, "Johny Mathis", "jazz"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("My Funny Valentine", 3, "live jazz music", "Assets/Images/jazz/2.jpg", 8, "Ella Fitzgerald", "jazz"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Sing Sing Sing", 3, "live jazz music", "Assets/Images/jazz/3.jpg", 10, "Nenny Goodman", "jazz"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Take 5", 3, "live jazz music", "Assets/Images/jazz/4.jpg", 7, "Dave Brubeck", "jazz"), Constants.UNLIMITED);

            productsManager.TryAddProduct(new Song("Crazy For You", 3, "soundtrack music", "Assets/Images/soundtrack/1.jpg", 5, "Madonna", "soundtrack"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Exhale", 3, "soundtrack music", "Assets/Images/soundtrack/2.jpg", 5, "Whitney Houston", "soundtrack"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Moana", 3, "soundtrack music", "Assets/Images/soundtrack/3.jpg", 4, "Alessia Cara", "soundtrack"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("Ghostbusters", 3, "soundtrack music", "Assets/Images/soundtrack/4.jpg", 6, "Ray Parker Jr.", "soundtrack"), Constants.UNLIMITED);
            productsManager.TryAddProduct(new Song("My Heart Will Go On", 3, "soundtrack music", "Assets/Images/soundtrack/4.jpg", 5, "Celine Dion", "soundtrack"), Constants.UNLIMITED);
        }
    }
}
