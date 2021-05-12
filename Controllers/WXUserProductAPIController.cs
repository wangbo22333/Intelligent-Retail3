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
using System.Collections;

namespace Intelligent_Retail3.Controllers
{
    public class Compute_weight
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            List<IList<int>> result = new List<IList<int>>();
            List<int> current = new List<int>();
            Dfs(candidates, result, current, target, 0);
            return result;
        }
        public void Dfs(int[] candidates, List<IList<int>> result, List<int> current, int target, int begin)
        {
            if (target == 0)
            {
                result.Add(new List<int>(current));
            }
            if (target < 0) return;
            for (int i = begin; i < candidates.Length; i++)
            {
                if (target - candidates[i] < 0) break;
                if (begin < i && candidates[i] == candidates[i - 1]) continue;
                current.Add(candidates[i]);
                target -= candidates[i];
                Dfs(candidates, result, current, target, i + 1);
                target += candidates[i];
                current.Remove(candidates[i]);
            }
        }
    }

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
        private static readonly Dictionary<int, string> product_dict_weight = new Dictionary<int, string> {
            {114,"10019"},
            {309,"10021"},
            {564,"10022"}

        };
        private static readonly int[] gap_weight = new int[30] { 114, 114, 114, 114, 114, 114, 114, 114, 114, 114, 309, 309, 309, 309, 309, 309, 309, 309, 309, 309, 564, 564, 564, 564, 564, 564, 564, 564, 564, 564 };
        //private static readonly int[] gap_weight_2 = new int[] { 115, 230, 310, 425, 565, 620, 680, 875, 1130 };

        public WXUserProductAPIController(ApplicationDbContext context)
        {
            _context = context;
        }




        // GET: api/WXUserProductAPI
        [HttpGet]
        public async Task<ActionResult<List<ProductResultModel>>> ProductAsync(string DeviceName, float ProductWeight, string PictureResult)
        {
            List<ProductResultModel> productResult = new List<ProductResultModel>();
            //Dictionary<string, int> dict_1 = JsonConvert.DeserializeObject<Dictionary<string, int>>(PictureResult);
            JObject dict_2 = (JObject)JsonConvert.DeserializeObject(PictureResult);
            System.Diagnostics.Debug.WriteLine(dict_2);
            float temp_weight = 0;
            IEnumerable<JProperty> properties = dict_2.Properties();
            foreach (JProperty item in properties)
            {
                CommodityManage product_info = await _context.CommodityManage.FirstOrDefaultAsync(m => m.ProductID == product_dict[item.Name]);
                ProductResultModel temp = new ProductResultModel(product_dict[item.Name], product_info.ProductName, product_info.ProductImage, Convert.ToSingle(product_info.ProductPrice), (int)item.Value);
                productResult.Add(temp);
                temp_weight += Convert.ToSingle(product_info.ProductWeight) * (int)item.Value;
            }
            float abs_weight_gap = Math.Abs(temp_weight - ProductWeight);
            if (temp_weight > ProductWeight)
            {
                if (abs_weight_gap < 0.5 * temp_weight)
                {
                    return productResult;
                }
                else
                {
                    return productResult;
                }

            }
            else
            {
                if (abs_weight_gap < 0.5 * temp_weight)
                {
                    return productResult;
                }
                else
                {
                    int j = 1;
                    for (int i = (int)(-0.05 * (int)ProductWeight); i < 0.05 * (int)ProductWeight; i++)
                    {
                        IList<IList<int>> res = new List<IList<int>>();
                        Compute_weight compute_Weight = new Compute_weight();
                        res = compute_Weight.CombinationSum2(gap_weight,  (int)ProductWeight + i - (int)temp_weight);
                        foreach (var item in res)
                        {
                            System.Diagnostics.Debug.WriteLine("重量可能的组合结果{0}：", j);
                            foreach (var item_2 in item)
                            {
                                System.Diagnostics.Debug.WriteLine(item_2);
                                CommodityManage product_info_2 = await _context.CommodityManage.FirstOrDefaultAsync(m => m.ProductID == product_dict_weight[item_2]);
                                ProductResultModel temp_2 = new ProductResultModel(product_dict_weight[item_2], product_info_2.ProductName, product_info_2.ProductImage, Convert.ToSingle(product_info_2.ProductPrice), item.Count(t=> t == item_2));
                                productResult.Add(temp_2);
                            }
                            j++;
                        }
                        

                    }


                    return productResult;
                }

            }







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
