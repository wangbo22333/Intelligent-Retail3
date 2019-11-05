using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Intelligent_Retail3.Models
{
    public class CommodityManage
    {
        public int ID { get; set; }
        [DisplayName("商品编号")]
        public string ProductID { get; set; }
        [DisplayName("商品类别编号")]
        public string CategoryID { get; set; }
        [DisplayName("品牌编号")]
        public string BrandID { get; set; }
        [DisplayName("商品名称")]
        public string ProductName { get; set; }
        [DisplayName("商品图片")]
        public string ProductImage { get; set; }
        [DisplayName("商品重量")]
        public string ProductWeight { get; set; }
        [DisplayName("商品价格")]
        public string ProductPrice { get; set; }
        [DisplayName("商品总库存")]
        public int ProductStock { get; set; }
        [DisplayName("商品总销量")]
        public int ProductSale { get; set; }
    }
}
