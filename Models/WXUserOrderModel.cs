using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Intelligent_Retail3.Models
{
    public class WXUserOrder
    {
        public int ID { get; set; }
        [DisplayName("用户编号")]
        public string WXUserID { get; set; }
        [DisplayName("用户手机号")]
        public string WXUserPhone { get; set; }
        [DisplayName("商品总价")]
        public decimal TotalPrice { get; set; } 
        [DisplayName("交易号")]
        public string WXPayNumber { get; set; }
        [DisplayName("订单状态")]
        public int State { get; set; }
        [DisplayName("订单创建时间")]
        public DateTime CreateTime { get; set; }
    }
}
