namespace onlineShop.Products
{
    public class Song: Product
    {
        public double Duration { get; set; }

        public string Artist { get; set; }

        public string Genre { get; set; }

        private Song()
        {
        }

        public Song(string name, double price, string tags, double duration, string artist, string genre) : base(name, price, tags)
        {
            Duration = duration;
            Artist = artist;
            Genre = genre;
        }

        public override bool DoesKeyWordMatches(string keyword)
        {
            return base.DoesKeyWordMatches(keyword) || Artist.ToLower().Contains(keyword);
        }
    }
}
