using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Intelligent_Retail3.Models
{
    public class ProductCategory
    {
        public int ID { get; set; }
        [DisplayName("商品类别编号")]
        public string CategoryID { get; set; }
        [DisplayName("类别名称")]
        public string CategoryName { get; set; }
        [DisplayName("类别信息")]
        public string CategoryInfo { get; set; }
    }
}
