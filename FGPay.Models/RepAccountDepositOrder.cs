using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FGPay.Models
{
    /// <summary>
    /// 码商 缴纳保证金订单
    /// </summary>
    public class RepAccountDepositOrder
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "姓名")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "账号")]
        [StringLength(50)]
        public string UserID { get; set; }
        [Required]
        [Display(Name = "充值单号")]
        [StringLength(50)]
        public string OrderNo { get; set; }

        [Required]
        [Display(Name = "充值金额")]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name ="订单状态")]
        [Column(TypeName ="tinyint")]
        public int State { get; set; }

        [Required]
        [Display(Name = "银行名称")]
        [StringLength(50)]
        public string BankFullName { get; set; }

        [Required]
        [Display(Name = "开户姓名")]
        [StringLength(20)]
        public string AccountName { get; set; }

        [Required]
        [Display(Name = "银行卡号")]
        [StringLength(20)]
        public string AccountCardNumber { get; set; }

        [Display(Name = "附加信息")]
        [StringLength(50)]
        public string ExtraRemark { get; set; }

        [Display(Name = "备注")]
        [StringLength(50)]
        public string Remark { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "修改时间")]
        public DateTime LastUpdateTime { get; set; }
    }
}
