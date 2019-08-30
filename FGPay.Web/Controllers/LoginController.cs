using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FGPay.Code;

namespace FGPay.Web.Controllers
{
    public class LoginController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAuthCode()
        {
            var objVerifyCode = new VerifyCode();
            string code = objVerifyCode.GetVerifyCode();
            SetSession("_verifycode", Md5.Md5Hash(code.ToLower()));
            return File(objVerifyCode.GetVerifyCodeImg(code), @"image/Gif");
        }
        [HttpGet]
        public IActionResult OutLogin()
        {
            //new LogApp().WriteDbLog(new LogEntity
            //{
            //    F_ModuleName = "系统登录",
            //    F_Type = DbLogType.Exit.ToString(),
            //    F_Account = OperatorProvider.Provider.GetCurrent().UserCode,
            //    F_NickName = OperatorProvider.Provider.GetCurrent().UserName,
            //    F_Result = true,
            //    F_Description = "安全退出系统",
            //});
            //Session.Abandon();
            //Session.Clear();
            //OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
            
        }

        [HttpPost]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            string s = GetSession("_verifycode");
            if (string.IsNullOrEmpty(s) || Md5.Md5Hash(code.ToLower()) != s)
            {
                return AjaxReturn(ResultType.error, "验证码错误，请重新输入");
            }
            SetSession("g", "1");//群组ID，用以关联对于选单权限
            SetSession("u", username);
            return Content(new AjaxResult { state = ResultType.success, message = "登录成功。" }.ToJson());
        }
    }
}