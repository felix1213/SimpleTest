using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FGPay.Domain.Entity
{
    /// <summary>
    /// 导航菜单类
    /// </summary>
    public class MenuEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 导航菜单名称
        /// </summary>
        public string name { get; set; }


        /// <summary>
        /// 菜单标识码
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// controller
        /// </summary>
        public string controller { get; set; }

        /// <summary>
        /// action
        /// </summary>
        public string action { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public int parentid { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int state { get; set; }

        /// <summary>
        /// 导航菜单排序
        /// </summary>
        public int sortvalue { get; set; }
    }
}
