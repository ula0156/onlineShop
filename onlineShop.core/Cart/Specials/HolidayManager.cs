using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop.Entities
{
    public class HolidayManager
    {
        private List<Tuple<DateTime, TimeSpan, List<string>>> _holidays;

        public HolidayManager()
        {
            _holidays = new List<Tuple<DateTime, TimeSpan, List<string>>>();
            _holidays.Add(new Tuple<DateTime, TimeSpan, List<string>>(
                new DateTime(DateTime.Now.Year, 12, 25), 
                TimeSpan.FromDays(14), 
                new List<string>() { "Christmas", "dear", "snow" }));
            _holidays.Add(new Tuple<DateTime, TimeSpan, List<string>>(new DateTime(DateTime.Now.Year, 5, 8),
                TimeSpan.FromDays(14),
                new List<string> { "Mother", "mother's day" }));
            _holidays.Add(new Tuple<DateTime, TimeSpan, List<string>>(new DateTime(DateTime.Now.Year, 2, 14),
                TimeSpan.FromDays(14),
                new List<string> { "Valentine", "love", "heart" }));
            _holidays.Add(new Tuple<DateTime, TimeSpan, List<string>>(new DateTime(DateTime.Now.Year, 4, 30),
                TimeSpan.FromDays(14),
                new List<string> { "Ester", "bunny", "eggs", "chocolate" }));

        }
        
        public bool IsHoliday(DateTime date, out List<string> keyWords)
        {
            foreach (var holiday in _holidays)
            {
                if (date < holiday.Item1.Date && date >= holiday.Item1 - holiday.Item2)
                {
                    keyWords = holiday.Item3;
                    return true;
                }
            }

            keyWords = null;
            return false;               
        }
    }
}
