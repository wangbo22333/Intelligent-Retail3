using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Intelligent_Retail3.Models
{
    public class DeviceProduct
    {
        public int ID { get; set; }
        [DisplayName("设备编号")]
        public string DeviceID { get; set; }
        [DisplayName("商品编号")]
        public string ProductID { get; set; }
        [DisplayName("本机该商品库存")]
        public int DeviceProductStock { get; set; }
        [DisplayName("本机该商品销量")]
        public int DeviceProductSale { get; set; }
    }
}
