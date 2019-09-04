using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FGPay.Models
{
    /// <summary>
    /// 码商额度信息
    /// </summary>
    public class RepAccountCredit
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "保证金")]
        [Column(TypeName = "money")]
        public decimal DepositAmount { get; set; }

        [Required]
        [Display(Name = "奖励金额")]
        [Column(TypeName = "money")]
        public decimal BonusAmount { get; set; }

        [Required]
        [Display(Name = "冻结金额")]
        public decimal FrozenAmount { get; set; }

        [Required]
        [Display(Name = "已收金额")]
        [Column(TypeName = "money")]
        public decimal ReceiptAmount { get; set; }

        [Required]
        [Display(Name = "微信抽成")]
        [Column(TypeName = "money")]
        public decimal Wechat { get; set; }

        [Required]
        [Display(Name = "支付宝抽成")]
        [Column(TypeName = "money")]
        public decimal Alipay { get; set; }

        [Required]
        [Display(Name = "云闪付抽成")]
        [Column(TypeName = "money")]
        public decimal UnionPay { get; set; }

        [Required]
        [Display(Name = "推广费")]
        [Column(TypeName = "money")]
        public decimal MarketingFee { get; set; }

        public int RepAccountID { get; set; }
        public RepAccount RepAccount { get; set; }
    }
}
