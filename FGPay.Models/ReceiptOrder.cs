using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FGPay.Models
{
    /// <summary>
    /// 收款订单
    /// </summary>
   public  class ReceiptOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "varchar(50)")]
        public string ID { get; set; } = KeyProducer.GuidKey;

        [Required]
        [Display(Name = "订单号")]
        [StringLength(50)]
        public string OrderNo { get; set; }

        [Required]
        [Display(Name = "商户订单号")]
        [StringLength(50)]
        public string MerchantOrderNo { get; set; }


        [Display(Name = "代理")]
        [StringLength(20)]
        public string AgentUserID { get; set; }

        [Display(Name = "代理名称")]
        [StringLength(50)]
        public string AgentFullName { get; set; }

        [Required]
        [Display(Name = "商户名")]
        [StringLength(20, MinimumLength = 3)]
        public string MerchantUserID { get; set; }

        [Required]
        [Display(Name = "商户名称")]
        [StringLength(50)]
        public string MerchantFullName { get; set; }

        [Required]
        [Display(Name = "支付类型")]
        public PaymentType PaymentType { get; set; }

        [Required]
        [Display(Name = "收款二维码账号")]
        [StringLength(50)]
        public string QRAccountUserID { get; set; }

        [Required]
        [Display(Name = "收款账号")]
        [StringLength(50)]
        public string AccountUserID { get; set; }

        [Display(Name = "真实姓名")]
        [StringLength(20)]
        public string AccountName { get; set; }

        [Required]
        [Display(Name = "金额")]
        [Column(TypeName= "money")]
        public decimal Amount { get; set; }

        [Display(Name = "附加信息")]
        [StringLength(50)]
        public string ExtraRemark { get; set; }

        [Display(Name = "备注")]
        [StringLength(50)]
        public string Remark { get; set; }

        /// <summary>
        /// 1已支付,2未支付、3通道停用、4商户停用、5代理停用、6额度已满、7二维码异常、8超时确认
        /// </summary>
        [Required]
        [Display(Name = "状态")]
        [Column(TypeName = "tinyint")]
        public int State { get; set; }

        [Display(Name = "同步回调地址")]
        [StringLength(50)]
        public string SyncCallbackUrl { get; set; }

        [Display(Name = "异步回调地址")]
        [StringLength(50)]
        public string AyncCallbackUrl { get; set; }

        [Display(Name = "操作员")]
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
