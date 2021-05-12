using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Intelligent_Retail3.Models
{
    public class ProductResultModel
    {
        public ProductResultModel(string productID, string productName, string productImage, float productPrice, int number)
        {
            ProductID = productID;
            ProductName = productName;
            ImgLink = productImage;
            ProductPrice = productPrice;
            ProductNumber = number;
        }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ImgLink { get; set; }
        public float ProductPrice { get; set; }
        public int ProductNumber { get; set; }
        
    }
}
