/*-------------------------------------*
 * 創建人:         J.Y
 * 創建時間:       2019/04/28
 * 最后修改時間:    
 * 最后修改原因:
 * 修改歷史:
 * 2019/04/28       J.Y       創建
 *-------------------------------------*/
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using FGPay.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace FGPay.Web.Domain
{
    /// <summary>
    /// 权限拦截过滤
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class PermissionFilterAttribute : ActionFilterAttribute
    {
        private string controller { get; set; }
        private string action { get; set; }
        private Operationype operationype { get; set; }
        private bool isViewPage = false;


        /// <summary>
        /// 权限过滤
        /// </summary>
        /// <param name="_controller">Controller</param>
        /// <param name="_action">Action</param>
        /// <param name="_operationype">执行动作类型</param>
        public PermissionFilterAttribute(string _controller = "", string _action = "", Operationype _operationype = Operationype.View)
        {
            isViewPage = _controller.Equals(string.Empty) && _action.Equals(string.Empty);
            controller = _controller;
            action = _action;
            operationype = _operationype;
        }
        /// <summary>
        /// 权限拦截
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var allowAccess = false;
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            if (controller.Equals(string.Empty))
            {
                controller = filterContext.RouteData.Values["controller"].ToString();
            }
            if (action.Equals(string.Empty))
            {
                action = filterContext.RouteData.Values["action"].ToString();
            }

            
            string g = filterContext.HttpContext.Session.GetString("g");
            string u = filterContext.HttpContext.Session.GetString("u");
            //Controller controller = context.Controller as Controller;

            //if (controller != null)
            //{
            //    //getting a service
            //    IMyService myService = controller.HttpContext.RequestServices.GetService(typeof(IMyService)) as IMyService;
            //    //injecting values in the ViewData
            //    controller.ViewData["myservice"] = myService;
            //}
            #region MockData 当前用户当前操作的权限
            var ctl =  ((Microsoft.AspNetCore.Mvc.Controller)filterContext.Controller);
            ctl.ViewData["Add"] = true;
            ctl.ViewData["Update"] = true;
            ctl.ViewData["Delete"] = true;
            ctl.ViewData["Other"] = true;
            ctl.ViewBag.Title = "后端用户";
            #endregion
            //if ()  //从Redis中读取当前群组权限数据 List<MenuPermission>
            //{
            //var memuInfo = new MenuPermission();
            ////var memuInfo = ((List<MenuPermission>)HttpContext.Current.Session["MemuList"]).SingleOrDefault(
            ////    x => x.controller.Equals(controller, StringComparison.CurrentCultureIgnoreCase)
            ////    && x.action.Equals(action, StringComparison.CurrentCultureIgnoreCase));

            //if (memuInfo != null)
            //{
            //    switch (operationype)
            //    {
            //        case Operationype.View:
            //            allowAccess = true;
            //            break;
            //        case Operationype.Add:
            //            allowAccess = memuInfo.add;
            //            break;
            //        case Operationype.Update:
            //            allowAccess = memuInfo.update;
            //            break;
            //        case Operationype.Delete:
            //            allowAccess = memuInfo.delete;
            //            break;
            //        case Operationype.Other:
            //            allowAccess = memuInfo.other;
            //            break;
            //    }
            //    filterContext.Controller.ViewData["Add"] = memuInfo.add;
            //    filterContext.Controller.ViewData["Update"] = memuInfo.update;
            //    filterContext.Controller.ViewData["Delete"] = memuInfo.delete;
            //    filterContext.Controller.ViewBag.Title = memuInfo.Name;
            //}
            //}

            //if (!allowAccess)
            //{
            //    filterContext.HttpContext.Session.Clear();
            //    // filterContext.HttpContext.Request.IsAjaxRequest()
            //    if (isViewPage)
            //    {
            //        filterContext.RequestContext.HttpContext.Response.Redirect("~/Login/Index");
            //    }
            //    else
            //    {
            //        var obj = new { success = false, msg = Resource.ResourceManager.GetString("ormsg_nopermissions"), code = "-100" };
            //        filterContext.Result = new ContentResult() { Content = JsonConvert.SerializeObject(obj) };
            //    }
            //}
            //else
            //{
            //    //判断重复登入
            //    var CurrentOnline = System.Web.HttpContext.Current.Application["CurrentOnline"];
            //    Hashtable htOnline = (Hashtable)CurrentOnline;
            //    if (htOnline != null && htOnline[filterContext.HttpContext.Session["UserId"].ToString()].ToString() != filterContext.HttpContext.Session["LoginTime"].ToString())
            //    {
            //        filterContext.HttpContext.Session.Clear();
            //        if (isViewPage)
            //        {
            //            filterContext.RequestContext.HttpContext.Response.Redirect("~/Manager/Login?t=rl");
            //        }
            //        else
            //        {
            //            var obj = new { success = false, msg = Resource.ResourceManager.GetString("ormsg_distanceLogin"), code = "-101" };
            //            filterContext.Result = new ContentResult() { Content = JsonConvert.SerializeObject(obj) };
            //        }
            //        return;
            //    }
            //}
        }


    }
}