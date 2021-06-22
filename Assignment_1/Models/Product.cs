using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Condition { get; set; }
        public decimal Paid { get; set; }
        public decimal Value { get; set; }

        //sets up foreign key
        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; }
        
    }
}
