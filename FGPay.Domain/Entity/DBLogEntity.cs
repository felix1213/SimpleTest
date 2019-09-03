using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FGPay.Code;

namespace FGPay.Domain.Entity
{
    /// <summary>
    /// 数据库操作日志
    /// </summary>
    public class DBLogEntity
    {
        public string _id { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 表名
        /// </summary>
        public string tabName { get; set; }
        /// <summary>
        /// 目标ID
        /// </summary>
        public string tId { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public int lType { get; set; }
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        public string sql { get; set; }
        /// <summary>
        /// 执行参数
        /// </summary>
        public string paras { get; set; }
        /// <summary>
        /// 总运行时间（毫秒）
        /// </summary>
        public long ms { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string uId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime ctime { get; set; }
    }
}
