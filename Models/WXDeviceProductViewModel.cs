using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Intelligent_Retail3.Models
{
    public class WXDeviceProductAPI
    {
        [DisplayName("商品编号")]
        public string ProductID { get; set; }
        [DisplayName("类别名称")]
        public string CategoryName { get; set; }
        [DisplayName("商品名称")]
        public string ProductName { get; set; }
        [DisplayName("商品图片")]
        public string ProductImage { get; set; }
        [DisplayName("商品价格")]
        public string ProductPrice { get; set; }

    }
}
