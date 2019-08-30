using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FGPay.Web.Models
{
    public class UserEntity
    {
        /// <summary>
        /// 主键 Id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 用户登录 UserId
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 用户登录密码 UserPwd
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 部门编号
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 职务编号
        /// </summary>
        public int DutyId { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime? Entrydate { get; set; }

        /// <summary>
        /// 联系人手机号码 
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 邮箱 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 用户是否被启用
        /// </summary>
        public bool IsAble { get; set; }

        /// <summary>
        /// 用户是否修改密码（强制第一次登陆修改密码）
        /// </summary>
        public bool IfChangePwd { get; set; }

        /// <summary>
        /// 用户简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后更新人 
        /// </summary>
        public string UpdateBy { get; set; }

        /// <summary>
        /// 最后更新时间 
        /// </summary>
        public DateTime UpdateTime { get; set; }


    }
}
