using onlineShop.Products;
using System.Collections.Generic;


namespace onlineShopWeb.Models
{
    public class HomeViewModel
    {
        public List<Book> BooksList { get; set; }
        public List<Song> SongsList { get; set; }
        
    }

    public class HomeViewModelBook
    {
        public Book book { get; set; }
    }

    public class HomeViewModelSong
    {
        public Song song { get; set; }
    }
}