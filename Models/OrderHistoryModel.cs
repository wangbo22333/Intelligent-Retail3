using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intelligent_Retail3.Models
{
    public class OrderHistoryModel
    {
        public string DeviceName { get; set; }
        public string OrderDate { get; set; }
        public string OrderDetail { get; set; }
        public float TotalPrice { get; set; }

    }
    public class OrderHistoryDetail
    {
        public string ProductName { get; set; }
        public string ImgLink { get; set; }
        public string Price { get; set; }
        public int ProductNumber { get; set; }
    }
}
