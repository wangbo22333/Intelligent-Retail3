using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Intelligent_Retail3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AppUsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;    // 用户管理

        public AppUsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: AppUserController
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.Users.ToListAsync();
            return View(user);
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var commodityManage = await _userManager.Users
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (commodityManage == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(commodityManage);
        //}




    }
}
