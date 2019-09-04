using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FGPay.Models
{
    /// <summary>
    /// 代理额度变动
    /// </summary>
    public class AgentCreditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName ="varchar(50)")]
        public string ID { get; set; } = KeyProducer.GuidKey;

        [Required]
        [Display(Name = "代理名")]
        [StringLength(20, MinimumLength = 3)]
        public string AgentUserID { get; set; }

        [Required]
        [Display(Name = "商户名")]
        [StringLength(20, MinimumLength = 3)]
        public string MerchantUserID { get; set; }

        /// <summary>
        /// 1存款，2提现
        /// </summary>
        [Required]
        [Display(Name = "类型")]
        [Column(TypeName = "tinyint")]
        public int CreditLogType { get; set; }

        [Required]
        [Display(Name = "之前余额")]
        [Column(TypeName = "money")]
        public decimal BeforeCredit { get; set; }

        [Required]
        [Display(Name = "余额")]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Display(Name = "之后余额")]
        public decimal AfterCredit => BeforeCredit + Amount;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "订单号")]
        [StringLength(20)]
        public string OrderNumber { get; set; }

        [Display(Name = "备注")]
        [StringLength(100)]
        public string Remark { get; set; } = "";
    }
}
