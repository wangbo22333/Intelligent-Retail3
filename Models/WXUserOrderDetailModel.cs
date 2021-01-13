using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Intelligent_Retail3.Models
{
    public class WXUserOrderDetail
    {
        public int ID { get; set; }
        [DisplayName("订单编号")]
        public string WXUserOrderID { get; set; }
        [DisplayName("用户手机号")]
        public string WXUserPhone { get; set; }
        [DisplayName("商品编号")]
        public string WXProductID { get; set; }
        [DisplayName("该商品数量")]
        public int WXProductNumber { get; set; }
    }
}
