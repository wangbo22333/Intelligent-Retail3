using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intelligent_Retail3.Models
{
    public class WXUserOrderAPI
    {
        public List<WXUserOrder> Orders;
        public List<WXUserOrderDetail> OrderDetails;
        public SelectList OrderGenres { get; set; }
    }
}
