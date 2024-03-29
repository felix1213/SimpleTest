﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FGPay.Models
{
    /// <summary>
    /// 商户
    /// </summary>
    public class Merchant
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "商户名")]
        [StringLength(20, MinimumLength = 3)]
        public string MerchantUserID { get; set; }
        [Required]
        [Display(Name = "密码")]
        [StringLength(50)]
        public string PassWord { get; set; }

        [Required]
        [Display(Name = "商户名称")]
        [StringLength(50)]
        public string MerchantFullName { get; set; }

        [Display(Name = "联系方式")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 1正常，2表示禁用
        /// </summary>
        [Required]
        [Display(Name = "商户状态")]
        [Column(TypeName = "tinyint")]
        public int MerchantState { get; set; } = 1;

        /// <summary>
        /// 1到账结算，2其它方式
        /// </summary>
        [Required]
        [Display(Name = "结算方式")]
        [Column(TypeName = "tinyint")]
        public int SettleType { get; set; } = 1;

        /// <summary>
        /// 1普通权限，2其它
        /// </summary>
        [Display(Name = "权限")]
        [Column(TypeName = "tinyint")]
        public int Role { get; set; } = 1;
        [Required]
        [Display(Name = "预付费率")]
        [Column(TypeName = "numeric(4, 2)")]
        public Double PrepaidRate { get; set; }
        [Required]
        [Display(Name = "取现费率")]
        [Column(TypeName = "numeric(4, 2)")]
        public Double WithdrawalRate { get; set; }
        [Required]
        [Display(Name = "账户余额")]
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        [Display(Name = "密钥")]
        [StringLength(50)]
        public string Md5key { get; set; }

        [Display(Name = "备注")]
        [StringLength(100)]
        public string Remark { get; set; } = "";

        [Display(Name = "操作员")]
        [StringLength(50)]
        public string Operator { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "修改时间")]
        public DateTime LastUpdateTime { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "登录时间")]
        public DateTime LastLoginTime { get; set; }

        [StringLength(30)]
        [Display(Name = "IP")]
        public string ClientIP { get; set; }

        [Display(Name = "代理")]
        public int? AgentID { get; set; }
        /// <summary>
        /// 代理，导航属性
        /// </summary>
        public Agent MerchantAgent { get; set; }


    }
}
