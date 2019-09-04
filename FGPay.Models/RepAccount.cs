using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FGPay.Models
{
    /// <summary>
    /// 代收账户，码商
    /// </summary>
    public class RepAccount
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "用户名")]
        [StringLength(50)]
        public string UserID { get; set; }

        [Display(Name = "上级码商")]
        [StringLength(50)]
        public string  UpperLevel { get; set; }

        [Required]
        [Display(Name = "登录密码")]
        [StringLength(50)]
        public string LoginPwd { get; set; }

        [Required]
        [Display(Name = "提现密码")]
        [StringLength(50)]
        public string WithdrawalPwd { get; set; }

        [Required]
        [Display(Name = "手机号")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "真实姓名")]
        [StringLength(20)]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "银行名称")]
        [StringLength(50)]
        public string BankFullName { get; set; }

        [Required]
        [Display(Name = "账号姓名")]
        [StringLength(20)]
        public string AccountName { get; set; }

        [Required]
        [Display(Name = "银行卡号")]
        [StringLength(20)]
        public string AccountCardNumber { get; set; }


        [Display(Name = "修改者")]
        [StringLength(50)]
        public string Operator { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "修改时间")]
        public DateTime LastUpdateTime { get; set; }

        [StringLength(30)]
        [Display(Name = "IP")]
        public string ClientIP { get; set; }
    }
}
