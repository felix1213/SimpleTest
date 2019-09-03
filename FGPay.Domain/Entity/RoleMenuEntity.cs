using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FGPay.Domain.Entity
{
    /// <summary>
    /// 角色能操作的菜单
    /// </summary>
    public class RoleMenuEntity
    {
        public RoleEntity roleEntity { get; set; }
        public List<AllowOperation> allowOperations { get; set; }
    }

    public class AllowOperation
    {
        /// <summary>
        /// 选单ID
        /// </summary>
        public int id { get; set; }

        public bool add { get; set; }
        public bool update { get; set; }
        public bool delete { get; set; }
        public bool other { get; set; }
    }
}
