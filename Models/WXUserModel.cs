using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Intelligent_Retail3.Models
{
    public class WXUser
    {
        public int ID { get; set; }
        [DisplayName("用户昵称")]
        public string WXUserNickName { get; set; }
        [DisplayName("用户微信ID")]
        public string WXUserOpenID { get; set; }
        [DisplayName("用户手机号")]
        public string WXUserPhone { get; set; }
        [DisplayName("用户性别")]
        public string WXUserGender { get; set; }
        [DisplayName("用户生日")]
        public DateTime WXUserBirthday { get; set; }
    }

}
