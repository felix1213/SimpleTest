using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FGPay.Code;

namespace FGPay.Web.Controllers
{
    public class BaseController : Controller
    {

        protected void SetSession(string k, string v)
        {
            HttpContext.Session.SetString(k, v);
        }

        protected string GetSession(string k) => HttpContext.Session.GetString(k);

        protected ContentResult PagerData(int totalCount, object rows)
        {
            return Content(JsonConvert.SerializeObject(new { total = totalCount.ToString(), rows = rows }));
        }

        protected ContentResult OperationReturn(bool _success, string _msg = "")
        {
            return Content(JsonConvert.SerializeObject(new { msg = _msg != "" ? _msg : (_success ? "操作成功" : "操作失败"), success = _success }));
        }

        protected ContentResult AjaxReturn(ResultType resultType, string _msg)
        {
            return Content(new AjaxResult { state = resultType.ToString(), message = _msg }.ToJson());
        }

       
    }

    /// <summary>
    /// 表示 ajax 操作结果类型的枚举
    /// </summary>
    public enum ResultType
    {
        /// <summary>
        /// 消息结果类型
        /// </summary>
        info,
        /// <summary>
        /// 成功结果类型
        /// </summary>
        success,
        /// <summary>
        /// 警告结果类型
        /// </summary>
        warning,
        /// <summary>
        /// 异常结果类型
        /// </summary>
        error
    }
}