using System;
using System.Collections.Generic;
using System.Text;

namespace FGPay.Models
{
    public static class KeyProducer
    {
        /// <summary>
        /// 生成日期+Guid主键
        /// </summary>
        public static string GuidKey => $"{DateTime.Now.ToString("yyyy-MM-dd")}-{Guid.NewGuid().ToString()}";
    }
}
