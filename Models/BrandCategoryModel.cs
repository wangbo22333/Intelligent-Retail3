using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Intelligent_Retail3.Models
{
    public class BrandCategory
    {
        public int ID { get; set; }
        [DisplayName("品牌编号")]
        public string BrandID { get; set; }
        [DisplayName("品牌名称")]
        public string BrandName { get; set; }
        [DisplayName("品牌信息")]
        public string BrandInfo { get; set; }
    }
}
