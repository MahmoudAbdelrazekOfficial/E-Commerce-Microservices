using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Core.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string ProductName { get; set; } // should be ProductId 
        public string Description { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
