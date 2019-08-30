using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FGPay.Web.Domain
{
    [Description("操作类型")]
    public enum Operationype
    {
        /// <summary>
        /// 查看
        /// </summary>
        View = 0,
        /// <summary>
        /// 新增
        /// </summary>
        Add = 1,
        /// <summary>
        /// 修改
        /// </summary>
        Update = 2,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 3,
        /// <summary>
        /// 删除
        /// </summary>
        Other = 4
    };
}