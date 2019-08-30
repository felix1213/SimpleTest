using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FGPay.Manager.Models
{
    /// <summary>
    /// 商户
    /// </summary>
    public class Merchant
    {
        public int MerchantID { get; set; }
        [Required]
        [Display(Name = "商户名")]
        [StringLength(20, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "密码")]
        [StringLength(50)]
        public string PassWord { get; set; }

        [Display(Name = "商户名称")]
        [StringLength(50)]
        public string MerchantFullName { get; set; }

        [Display(Name = "联系方式")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 1正常，2表示禁用
        /// </summary>
        [Display(Name = "商户状态")]
        [Column(TypeName = "tinyint")]
        public int MerchantState { get; set; } = 1;

        /// <summary>
        /// 1到账结算，2其它方式
        /// </summary>
        [Display(Name = "结算方式")]
        [Column(TypeName = "tinyint")]
        public int SettleType { get; set; } = 1;

        /// <summary>
        /// 1普通权限，2其它
        /// </summary>
        [Display(Name = "权限")]
        [Column(TypeName = "tinyint")]
        public int Role { get; set; } = 1;

        [Display(Name = "预付费率")]
        [Column(TypeName = "numeric(5, 2)")]
        public decimal PrepaidRate { get; set; }
        [Display(Name = "取现费率")]
        [Column(TypeName = "numeric(5, 2)")]
        public decimal WithdrawalRate { get; set; }

        [Display(Name = "账户余额")]
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        [Display(Name = "密钥")]
        [StringLength(50)]
        public string Md5key { get; set; }

        [Display(Name = "备注")]
        [StringLength(100)]
        public string Remark { get; set; }

        [Display(Name = "操作员")]
        [StringLength(50)]
        public string Operator { get; set; }

        [Display(Name = "代理")]
        public int? AgentID { get; set; }

    }
}
