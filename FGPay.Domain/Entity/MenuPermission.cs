using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGPay.Domain.Entity
{
    /// <summary>
    /// 对应角色的选单权限
    /// </summary>
    public class MenuPermission
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string controller { get; set; }
        public string action { get; set; }
        public bool add { get; set; }
        public int parentid { get; set; }
        public bool update { get; set; }
        public bool delete { get; set; }
        public bool other { get; set; }
    }
}
