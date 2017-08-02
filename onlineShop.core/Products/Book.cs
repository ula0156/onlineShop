using onlineShop.Products.Entities;

namespace onlineShop.Products
{
    public class Book: PhysicalProduct
    {
        public int NumberOfPages { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        
        private Book()
        {
        }
        
        public Book(string name, double price, string tags, string color, Size size, int numberOfPages, string author, string genre) : base(name, price, tags, color, size)
        {
            NumberOfPages = numberOfPages;
            Author = author;
            Genre = genre; 
        }

        public override bool DoesKeyWordMatches(string keyword)
        {
            return base.DoesKeyWordMatches(keyword) || Author.ToLower().Contains(keyword);
        }
    }
}
