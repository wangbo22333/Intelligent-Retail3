using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intelligent_Retail3.Models
{
    public class DeviceManage
    {
        public int ID { get; set; }
        [DisplayName("设备编号")]
        [Required(ErrorMessage = "必须填写设备编号")]
        public string DeviceID { get; set; }
        [Required(ErrorMessage = "必须填写设备三元组")]
        public string DeviceNumber { get; set; }
        [Required(ErrorMessage = "必须填写设备三元组")]
        public string DeviceProductKey { get; set; }
        [Required(ErrorMessage = "必须填写设备三元组")]
        public string DeviceSecret { get; set; }
        [Required(ErrorMessage = "必须填写省份")]
        [DisplayName("所在省份")]
        public string DeviceProvince { get; set; }
        [Required(ErrorMessage = "必须填写市区")]
        [DisplayName("所在市区")]
        public string DeviceCity { get; set; }
        [Required(ErrorMessage = "必须填写设备部署具体地址")]
        [DisplayName("具体地址")]
        public string DeviceAddress { get; set; }
        [Required(ErrorMessage = "必须填写设备部署时间")]
        [DisplayName("部署时间")]
        public DateTime DeviceSetDay { get; set; }
    }
}
