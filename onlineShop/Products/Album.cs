using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop.Products
{
    public class Album : Product
    {
        public List<Song> Songs { get; set; } 
      
        public Album(string name, double price, string tags, List<Song> songs): base(name, price, tags)
        {
            Songs = songs;
        }  

        public double GetDuration()
        {
            double duration = 0;
            foreach (var song in Songs)
            {
                duration += song.Duration;
            }
            return duration;
        }

        public override bool DoesKeyWordMatches(string keyword)
        {
            foreach (var song in Songs)
            {
                if (song.DoesKeyWordMatches(keyword))
                {
                    return true;
                }
            }
            return base.DoesKeyWordMatches(keyword);
        }
    }
}
