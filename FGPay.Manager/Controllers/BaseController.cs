using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FGPay.Manager.Controllers
{
    public class BaseController : Controller
    {
        protected void SetSession(string k, string v)
        {
            HttpContext.Session.SetString(k, v);
        }

        protected string GetSession(string k) => HttpContext.Session.GetString(k);

        /// <summary>
        /// 状态下拉列表数据
        /// </summary>
        /// <param name="selectValue"></param>
        protected void PopulateStatesDropDownList(object selectValue = null)
        {
            var list = new List<object>();
            list.Add(new { Value = 1, Text = "正常" });
            list.Add(new { Value = 2, Text = "禁用" });
            ViewBag.State = new SelectList(list, "Value", "Text", selectValue);
        }
    }
}
