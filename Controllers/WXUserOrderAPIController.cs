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

namespace Intelligent_Retail3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WXUserOrderAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WXUserOrderAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WXUserOrderAPI
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<WXUserOrder>>> GetWXUserOrder()
        //{
        //    return await _context.WXUserOrder.ToListAsync();
        //}

        // GET: api/WXUserOrderAPI/5
        [HttpGet]
        public async Task<ActionResult<List<OrderHistoryModel>>> GetWXUserOrder(string id)
        {

            var wXUserOrder = await _context.WXUserOrder.Where(b => b.WXUserID == id).OrderByDescending(b => b.CreateTime).ToListAsync();
            if (wXUserOrder == null)
            {
                return NotFound();
            }
            List<OrderHistoryModel> orderHistories = new List<OrderHistoryModel>();
            System.Diagnostics.Debug.WriteLine("正在查询订单：");
            foreach (var item in wXUserOrder)
            {
                
                var OrderDetails = await _context.WXUserOrderDetail.Where(b => b.WXUserOrderID == item.WXPayNumber).ToListAsync();
                List<OrderHistoryDetail> orderHistoryDetails = new List<OrderHistoryDetail>();
                foreach(var item_2 in OrderDetails)
                {
                    var single_product = _context.CommodityManage.Single(b => b.ProductID == item_2.WXProductID);
                    OrderHistoryDetail detail = new OrderHistoryDetail { 
                        ProductName = single_product.ProductName,
                        ImgLink = single_product.ProductImage,
                        Price = single_product.ProductPrice,
                        ProductNumber = item_2.WXProductNumber
                    };
                    orderHistoryDetails.Add(detail);
                }
                OrderHistoryModel orderHistory = new OrderHistoryModel
                {
                    DeviceName = "西南大学零售柜",
                    OrderDate = item.CreateTime.ToString("F"),
                    OrderDetail = JsonConvert.SerializeObject(orderHistoryDetails),
                    TotalPrice = (float)item.TotalPrice

                };
                System.Diagnostics.Debug.WriteLine("正在查询订单详情：");
                orderHistories.Add(orderHistory);
            }
            //wXUserOrder.WXPayNumber
            //List<WXUserOrderDetail> OrderDetails = new List<WXUserOrderDetail>();
            //var OrderDetails = await _context.WXUserOrderDetail.Where(b => b.WXUserOrderID == wXUserOrder.WXPayNumber).ToListAsync();
            //orderHistory.Add();
            return orderHistories;
        }

        // PUT: api/WXUserOrderAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWXUserOrder(int id, WXUserOrder wXUserOrder)
        {
            if (id != wXUserOrder.ID)
            {
                return BadRequest();
            }

            _context.Entry(wXUserOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WXUserOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WXUserOrderAPI
        [HttpPost]
        public async Task<ActionResult<WXUserOrder>> PostWXUserOrder([FromForm] OrderDataModel data)
        {
            //string open_id, List<ProductResultModel> productResult, decimal total_price, string order_code
            System.Diagnostics.Debug.WriteLine("正在创建订单：");
            System.Diagnostics.Debug.WriteLine(data.OpenId);

            //foreach (var item in productResult)
            //{
            //    WXUserOrder wXUserOrder = new WXUserOrder();
            //    wXUserOrder.WXUserID = open_id;
            //}
            WXUserOrder wXUserOrder = new WXUserOrder
            {
                WXUserID = data.OpenId,
                TotalPrice = data.TotalPrice,
                WXPayNumber = data.OrderCode,
                WXUserPhone = "",
                State = 1,
                CreateTime = DateTime.Now
            };
            _context.WXUserOrder.Add(wXUserOrder);
            //List<WXUserOrderDetail> OrderDetails = new List<WXUserOrderDetail>();
            List<ProductResultModel>  OrderDetails = JsonConvert.DeserializeObject<List<ProductResultModel>>(data.ProductResult);
            System.Diagnostics.Debug.WriteLine(data.ProductResult);
            System.Diagnostics.Debug.WriteLine("商品数据");
            for (int i = 0; i< OrderDetails.Count(); i++)
            {
                System.Diagnostics.Debug.WriteLine(OrderDetails[i].ProductName);
                WXUserOrderDetail wXUserOrderDetail = new WXUserOrderDetail
                {
                    WXUserOrderID = data.OrderCode,
                    WXUserPhone = "",
                    WXProductID = OrderDetails[i].ProductID,
                    WXProductNumber = OrderDetails[i].ProductNumber,
                };
                _context.WXUserOrderDetail.Add(wXUserOrderDetail);

            }
            
            await _context.SaveChangesAsync();
            //foreach(var item in wXUserOrderDetails)
            //{
            //    CreatedAtAction("GetWXUserOrderDetail", new { id = item.ID }, item);
            //}
            return CreatedAtAction("GetWXUserOrder", new { id = wXUserOrder.ID }, wXUserOrder);
        }

        // DELETE: api/WXUserOrderAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WXUserOrder>> DeleteWXUserOrder(int id)
        {
            var wXUserOrder = await _context.WXUserOrder.FindAsync(id);
            if (wXUserOrder == null)
            {
                return NotFound();
            }

            _context.WXUserOrder.Remove(wXUserOrder);
            await _context.SaveChangesAsync();

            return wXUserOrder;
        }

        private bool WXUserOrderExists(int id)
        {
            return _context.WXUserOrder.Any(e => e.ID == id);
        }
    }
}
