using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Intelligent_Retail3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("any")]
    public class CodeValuesController : ControllerBase
    {
        [HttpGet]
        public string GetOpenId(string code)
        {
            string url = string.Format("https://api.weixin.qq.com/sns/jscode2session?appid=" + "wx241c5966e0de91f1" + "&secret=" + "2f97cb05dc34c456eaa730e9a0a356d8" + "&grant_type=authorization_code&js_code=" + code + "");
            WebClient wc = new WebClient();
            Encoding enc = Encoding.GetEncoding("UTF-8");
            Byte[] pageData = wc.DownloadData(url);
            string re = enc.GetString(pageData);
            return re;
        }

    }
}
