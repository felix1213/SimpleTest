using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  FGPay.DAL
{
    public enum OperateType
    {
        /// <summary>
        /// 其他
        /// </summary>
        None = 0,
        /// <summary>
        /// 系统
        /// </summary>
        System = 1,
        /// <summary>
        /// 游戏
        /// </summary>
        Game = 2,
        /// <summary>
        /// 用户
        /// </summary>
        User = 3
    }
}
