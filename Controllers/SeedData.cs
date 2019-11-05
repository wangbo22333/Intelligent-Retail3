using Intelligent_Retail3.Data;
using Intelligent_Retail3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intelligent_Retail3.Controllers
{
    //public class SeedData
    //{
    //    public static void Initialize(IServiceProvider serviceProvider)
    //    {
    //        using (var context = new ApplicationDbContext(
    //            serviceProvider.GetRequiredService<
    //                DbContextOptions<ApplicationDbContext>>()))
    //        {
    //            //查找任意商品
    //            if (context.CommodityManage.Any())
    //            {
    //                return;   // DB has been seeded
    //            }
                
    //            context.BrandCategory.AddRange(
    //                new BrandCategory
    //                {
    //                    BrandID = "1000",
    //                    BrandName = "可口可乐",
    //                    BrandInfo = "可口可乐的一些供应商信息"
    //                },
    //                new BrandCategory
    //                {
    //                    BrandID = "1001",
    //                    BrandName = "百事",
    //                    BrandInfo = "百事公司的一些供应商信息"
    //                },
    //                new BrandCategory
    //                {
    //                    BrandID = "1002",
    //                    BrandName = "康师傅",
    //                    BrandInfo = "康师傅的一些供应商信息"
    //                },
    //                new BrandCategory
    //                {
    //                    BrandID = "1003",
    //                    BrandName = "维他奶",
    //                    BrandInfo = "维他奶的一些供应商信息"
    //                },
    //                new BrandCategory
    //                {
    //                    BrandID = "1004",
    //                    BrandName = "哇哈哈",
    //                    BrandInfo = "哇哈哈的一些供应商信息"
    //                },
    //                new BrandCategory
    //                {
    //                    BrandID = "1005",
    //                    BrandName = "红牛",
    //                    BrandInfo = "红牛的一些供应商信息"
    //                },
    //                new BrandCategory
    //                {
    //                    BrandID = "1006",
    //                    BrandName = "统一",
    //                    BrandInfo = "统一的一些供应商信息"
    //                }
    //                );
    //            context.CommodityManage.AddRange(
    //                new CommodityManage
    //                {
    //                    ProductID = "10001",
    //                    CategoryID = "1000",
    //                    BrandID = "1000",
    //                    ProductName = "可口可乐330ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "330",
    //                    ProductPrice = "2.5",
    //                    ProductStock = 1000,
    //                    ProductSale = 199
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10002",
    //                    CategoryID = "1000",
    //                    BrandID = "1000",
    //                    ProductName = "雪碧330ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "330",
    //                    ProductPrice = "2.5",
    //                    ProductStock = 999,
    //                    ProductSale = 211
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10003",
    //                    CategoryID = "1000",
    //                    BrandID = "1000",
    //                    ProductName = "芬达330ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "330",
    //                    ProductPrice = "2.5",
    //                    ProductStock = 1120,
    //                    ProductSale = 58
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10004",
    //                    CategoryID = "1000",
    //                    BrandID = "1001",
    //                    ProductName = "百事可乐330ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "330",
    //                    ProductPrice = "2.5",
    //                    ProductStock = 1531,
    //                    ProductSale = 253
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10005",
    //                    CategoryID = "1000",
    //                    BrandID = "1001",
    //                    ProductName = "美年达330ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "330",
    //                    ProductPrice = "2.5",
    //                    ProductStock = 1321,
    //                    ProductSale = 241
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10006",
    //                    CategoryID = "1000",
    //                    BrandID = "1001",
    //                    ProductName = "七喜330ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "330",
    //                    ProductPrice = "2.5",
    //                    ProductStock = 1309,
    //                    ProductSale = 286
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10007",
    //                    CategoryID = "1000",
    //                    BrandID = "1002",
    //                    ProductName = "康师傅冰红茶柠檬味500ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "500",
    //                    ProductPrice = "3",
    //                    ProductStock = 1534,
    //                    ProductSale = 256
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10008",
    //                    CategoryID = "1001",
    //                    BrandID = "1002",
    //                    ProductName = "康师傅矿泉水550ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "550",
    //                    ProductPrice = "2",
    //                    ProductStock = 2543,
    //                    ProductSale = 564
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10009",
    //                    CategoryID = "1000",
    //                    BrandID = "1002",
    //                    ProductName = "康师傅酸梅汤500ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "500",
    //                    ProductPrice = "3",
    //                    ProductStock = 976,
    //                    ProductSale = 143
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10010",
    //                    CategoryID = "1000",
    //                    BrandID = "1003",
    //                    ProductName = "维他奶柠檬茶250ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "250",
    //                    ProductPrice = "2.5",
    //                    ProductStock = 2451,
    //                    ProductSale = 643
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10011",
    //                    CategoryID = "1000",
    //                    BrandID = "1003",
    //                    ProductName = "维他奶原为豆奶250ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "250",
    //                    ProductPrice = "2.5",
    //                    ProductStock = 1672,
    //                    ProductSale = 346
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10012",
    //                    CategoryID = "1000",
    //                    BrandID = "1003",
    //                    ProductName = "维他奶无糖杭白菊花茶500ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "500",
    //                    ProductPrice = "4",
    //                    ProductStock = 1378,
    //                    ProductSale = 243
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10013",
    //                    CategoryID = "1001",
    //                    BrandID = "1004",
    //                    ProductName = "哇哈哈纯净饮用水596ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "596",
    //                    ProductPrice = "1.5",
    //                    ProductStock = 1465,
    //                    ProductSale = 211
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10014",
    //                    CategoryID = "1000",
    //                    BrandID = "1004",
    //                    ProductName = "哇哈哈营养快线原味500ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "500",
    //                    ProductPrice = "4",
    //                    ProductStock = 1323,
    //                    ProductSale = 255
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10015",
    //                    CategoryID = "1000",
    //                    BrandID = "1004",
    //                    ProductName = "哇哈哈无糖苏打水350ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "350",
    //                    ProductPrice = "3",
    //                    ProductStock = 1211,
    //                    ProductSale = 156
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10016",
    //                    CategoryID = "1000",
    //                    BrandID = "1005",
    //                    ProductName = "红牛维生素功能饮料250ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "250",
    //                    ProductPrice = "4.5",
    //                    ProductStock = 1566,
    //                    ProductSale = 344
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10017",
    //                    CategoryID = "1000",
    //                    BrandID = "1006",
    //                    ProductName = "统一阿萨姆奶茶原味500ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "500",
    //                    ProductPrice = "3.5",
    //                    ProductStock = 1643,
    //                    ProductSale = 167
    //                },
    //                new CommodityManage
    //                {
    //                    ProductID = "10018",
    //                    CategoryID = "1001",
    //                    BrandID = "1006",
    //                    ProductName = "统一爱夸饮用矿泉水360ml",
    //                    ProductImage = "图片路径",
    //                    ProductWeight = "360",
    //                    ProductPrice = "2",
    //                    ProductStock = 1451,
    //                    ProductSale = 256
    //                }

    //                );
    //            context.DeviceManage.AddRange(
    //                new DeviceManage
    //                {
    //                    DeviceID = "10001",
    //                    DeviceNumber = "fPTs7J0lDr19D8wfiiOy",
    //                    DeviceProductKey = "a1fG8uBWpxK",
    //                    DeviceSecret = "DWVFIBvJj5wIMLQWEfz3kw5T9kGdYdt5",
    //                    DeviceProvince = "广东",
    //                    DeviceCity = "佛山",
    //                    DeviceAddress = "顺德创新设计研究院1楼",
    //                    DeviceSetDay = new DateTime(2019, 8, 30)
    //                }

    //                );
    //            context.DeviceProduct.AddRange(
    //                new DeviceProduct
    //                {
    //                    DeviceID = "10001",
    //                    ProductID = "10002",
    //                    DeviceProductStock = 10,
    //                    DeviceProductSale = 3
    //                },
    //                new DeviceProduct
    //                {
    //                    DeviceID = "10001",
    //                    ProductID = "10003",
    //                    DeviceProductStock = 8,
    //                    DeviceProductSale = 4
    //                },
    //                new DeviceProduct
    //                {
    //                    DeviceID = "10001",
    //                    ProductID = "10005",
    //                    DeviceProductStock = 12,
    //                    DeviceProductSale = 5
    //                },
    //                new DeviceProduct
    //                {
    //                    DeviceID = "10001",
    //                    ProductID = "10008",
    //                    DeviceProductStock = 6,
    //                    DeviceProductSale = 2
    //                },
    //                new DeviceProduct
    //                {
    //                    DeviceID = "10001",
    //                    ProductID = "10010",
    //                    DeviceProductStock = 14,
    //                    DeviceProductSale = 7
    //                },
    //                new DeviceProduct
    //                {
    //                    DeviceID = "10001",
    //                    ProductID = "10012",
    //                    DeviceProductStock = 11,
    //                    DeviceProductSale = 2
    //                },
    //                new DeviceProduct
    //                {
    //                    DeviceID = "10001",
    //                    ProductID = "10014",
    //                    DeviceProductStock = 10,
    //                    DeviceProductSale = 4
    //                },
    //                new DeviceProduct
    //                {
    //                    DeviceID = "10001",
    //                    ProductID = "10016",
    //                    DeviceProductStock = 15,
    //                    DeviceProductSale = 7
    //                }
    //                );
    //            context.ProductCategory.AddRange(
    //                new ProductCategory
    //                {
    //                    CategoryID = "1000",
    //                    CategoryName = "饮料/乳饮料",
    //                    CategoryInfo = "分类的备注信息"
    //                },
    //                new ProductCategory
    //                {
    //                    CategoryID = "1001",
    //                    CategoryName = "矿泉水/纯净水",
    //                    CategoryInfo = "分类的备注信息"
    //                }
    //                );
    //            context.WXUser.AddRange(
    //                new WXUser
    //                {
    //                    WXUserNickName = "Bobby",
    //                    WXUserOpenID = "111111111",
    //                    WXUserPhone = "17607000000",
    //                    WXUserGender = "男",
    //                    WXUserBirthday = new DateTime(2019, 9, 16)
    //                }
    //                );
    //            context.WXUserOrder.AddRange(
    //                new WXUserOrder
    //                {
    //                    WXUserOrderID = "10000001",
    //                    WXUserPhone = "17607000000",
    //                    WXProductID = "1008",
    //                    WXProductNumber = 2
    //                },
    //                new WXUserOrder
    //                {
    //                    WXUserOrderID = "10000001",
    //                    WXUserPhone = "17607000000",
    //                    WXProductID = "10016",
    //                    WXProductNumber = 1
    //                }
    //                );

    //            context.SaveChanges();
    //        }
    //    }
    //}
}
