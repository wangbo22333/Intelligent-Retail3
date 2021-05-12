using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intelligent_Retail3.Models
{
    public class OrderDataModel
    {
        //string open_id, List<ProductResultModel> productResult, decimal total_price, string order_code
        public string OpenId { get; set; }
        public string ProductResult { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderCode { get; set; }
    }
}
