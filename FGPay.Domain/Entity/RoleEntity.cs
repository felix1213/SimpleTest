using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FGPay.Domain.Entity
{
    /// <summary>
    /// 角色类
    /// </summary>
    public class RoleEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 角色简介
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int state { get; set; }
    }
}
