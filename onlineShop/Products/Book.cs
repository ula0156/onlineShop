using onlineShop.Products.Entities;

namespace onlineShop.Products
{
    public class Book: PhysicalProduct
    {
        public Book(string name, double price, string tags, string color, Size size, int numberOfPages, string author) : base(name, price, tags, color, size)
        {
            NumberOfPages = numberOfPages;
            Author = author;
        }

        public int NumberOfPages { get; set; }
        public string Author { get; set; }

        public override bool DoesKeyWordMatches(string keyword)
        {
            return base.DoesKeyWordMatches(keyword) || Author.ToLower().Contains(keyword);
        }
    }
}
