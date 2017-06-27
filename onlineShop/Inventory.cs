using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    class Inventory
    {
        public Inventory()
        {
            Products = new Dictionary<Product, int>();

            // Add some products by default so the inventory is not empty.
            // In a real application we would read the items from a database.
            Products.Add(new Book(200, "J.K. Rowling", "Harry Potter and the book of shadows", 10, "book", new Size(20, 15, 5, 200), 
                new Manufacturer("Printing House Jaqualin",
                new ContactInformation("Rowling@gmail.com", "14567 SE 12st, San Francisco", "206 - 435 - 765- 11"))), 20);
            Products.Add(new Book(150, "Kate Smith", "Travel guide", 15, "book", new Size(20, 13, 3, 150), 
                new Manufacturer("CA Printing House", 
                new ContactInformation("travelGurus@test.com", "5243 NE 98, LA 93556", "286 - 7654- 5670"))), 30);
            Products.Add(new Backpack(25, "Cotton", "Marmot Light", 100, "backpack", new Size(13, 15, 20, 200), 
                new Manufacturer("Marmot", 
                new ContactInformation("marmot.test@test.com","16732 UpHill 13, 45762, IL", "+1 (234) 677 9787"))), 20);
            Products.Add(new Backpack(50, "Cotton","Marmot Medium", 150, "backpack", new Size(14, 17, 30, 250),
                new Manufacturer("Marmot",
                new ContactInformation("marmot.test@test.com", "16732 UpHill 13, 45762, IL", "+1 (234) 677 9787"))), 27);
            Products.Add(new Book(250, "J.K. Rowling", "Harry Potter and the conscript", 13, "book", new Size(20, 15, 5, 200), 
                new Manufacturer("Printing House Jaqualin",
                new ContactInformation("Rowling@gmail.com", "14567 SE 12st, San Francisco", "206 - 435 - 765- 11"))), 45);
            Products.Add(new Book(100, "Julia Larsen", "Travel all over the world", 17, "book", new Size(7, 5, 2, 50), 
                new Manufacturer("Expedia C",
                new ContactInformation("FeedYouCuriousity@test.com", "111 5th Ave, 65789 NYC", "211- 115- 6580"))), 100);
        }

        // Each Inventory object will make available the items that it contains in the form of a list.
        public Dictionary<Product, int> Products { get; }
        public Dictionary<Product, DateTime> FutureProducts { get; }
    }
}
