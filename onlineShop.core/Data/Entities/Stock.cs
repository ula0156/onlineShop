using System;
using System.ComponentModel.DataAnnotations;

namespace onlineShop.Data.Entities
{
    public class Stock
    {
        [Key]
        [Required]
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
    }
}
