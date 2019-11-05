using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Intelligent_Retail3.Models;

namespace Intelligent_Retail3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Intelligent_Retail3.Models.BrandCategory> BrandCategory { get; set; }
        public DbSet<Intelligent_Retail3.Models.CommodityManage> CommodityManage { get; set; }
        public DbSet<Intelligent_Retail3.Models.DeviceManage> DeviceManage { get; set; }
        public DbSet<Intelligent_Retail3.Models.DeviceProduct> DeviceProduct { get; set; }
        public DbSet<Intelligent_Retail3.Models.ProductCategory> ProductCategory { get; set; }
        public DbSet<Intelligent_Retail3.Models.WXUser> WXUser { get; set; }
        public DbSet<Intelligent_Retail3.Models.WXUserOrder> WXUserOrder { get; set; }
    }
}
