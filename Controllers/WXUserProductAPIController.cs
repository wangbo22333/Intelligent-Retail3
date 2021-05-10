using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Intelligent_Retail3.Data;
using Intelligent_Retail3.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Linq;

namespace Intelligent_Retail3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("any")]
    public class WXUserProductAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private static readonly Dictionary<string, string> product_dict = new Dictionary<string, string> {
            {"0","10021"},
            {"1","10022"},
            {"2","10020"},
            {"3","10019"},
            
        };

        public WXUserProductAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WXUserProductAPI
        [HttpGet]
        public async Task<ActionResult<List<ProductResultModel>>> ProductAsync(string DeviceName, int ProductWeight, string PictureResult)
        {
            List<ProductResultModel> productResult = new List<ProductResultModel>();
            //Dictionary<string, int> dict_1 = JsonConvert.DeserializeObject<Dictionary<string, int>>(PictureResult);
            JObject dict_2 = (JObject)JsonConvert.DeserializeObject(PictureResult);
            System.Diagnostics.Debug.WriteLine(dict_2);
            IEnumerable<JProperty> properties = dict_2.Properties();
            foreach (JProperty item in properties)
            {
                CommodityManage product_info = await _context.CommodityManage.FirstOrDefaultAsync(m => m.ProductID == product_dict[item.Name]);
                ProductResultModel temp = new ProductResultModel(product_info.ProductName, product_info.ProductImage, Convert.ToSingle(product_info.ProductPrice), (int)item.Value);
                productResult.Add(temp);
            }

            return productResult;
            




            //return $"设备名：{DeviceName},重量：{ProductWeight},图片结果：{dict_2}";
            //return await _context.CommodityManage.ToListAsync();

        }

        // GET: api/WXUserProductAPI/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<CommodityManage>> GetCommodityManage(int id)
        //{
        //    var commodityManage = await _context.CommodityManage.FindAsync(id);

        //    if (commodityManage == null)
        //    {
        //        return NotFound();
        //    }

        //    return commodityManage;
        //}




        private bool CommodityManageExists(int id)
        {
            return _context.CommodityManage.Any(e => e.ID == id);
        }
    }
}
