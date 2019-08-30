using Microsoft.AspNetCore.Mvc;
using FGPay.Code;
using FGPay.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FGPay.Web.Controllers
{
    public class ClientsDataController : BaseController
    {
        [HttpGet]
        public ActionResult GetClientsDataJson()
        {
            string g = GetSession("g");
            string u = GetSession("u");
            
            var groups = new List<group>();
            groups.Add(new group() { id = 1, name = "Admin" });
            groups.Add(new group() { id = 2, name = "测试" });

            var menuPermissions = new List<MenuPermission>();
            menuPermissions.Add(new MenuPermission() { id = 1, name = "用户管理", controller = "", action = "", parentid = 0, code = "system" });
            menuPermissions.Add(new MenuPermission() { id = 1, name = "后端用户", controller = "User", action = "Index", parentid = 1, code = "system", add = true, update = true, delete = true, other = true });

            var data = new ClientData();
            data.groups = groups;
            data.menuPermissions = menuPermissions;
            data.userInfo = new UserInfo();
            data.userInfo.u = u;
            data.userInfo.g = int.Parse(g);
            data.userInfo.name = "admin";
            return Content(data.ToJson());
        }
    }
}
