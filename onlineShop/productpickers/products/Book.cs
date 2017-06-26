namespace onlineShop
{
    // See Backpack for more information.
    class Book : PhysicalProduct
    {
        public Book(int numberOfPages, string author, string name, double price, Size size, Manufacturer manufacturer) : base(name, price, size, manufacturer)
        {
            NumberOfPages = numberOfPages;
            Author = author;
        }

        public int NumberOfPages { get; }
        public string Author { get; }
    }
}
