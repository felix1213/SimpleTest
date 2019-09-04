using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FGPay.Models
{
    /// <summary>
    /// 二维码信息
    /// </summary>
    public class QRCode
    {
        public int ID { get; set; }

        [Display(Name = "二维码信息")]
        [StringLength(50)]
        public string CodeInformation { get; set; }

        [Required]
        [Display(Name = "二维码地址")]
        [StringLength(200)]
        public string URL { get; set; }
        [Required]
        [Display(Name = "收款账户")]
        [StringLength(50)]
        public string UserID { get; set; }

        [Display(Name = "收款真实姓名")]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "支付类型")]
        public PaymentType PaymentType { get; set; }

        /// <summary>
        ///1审核通过、 2未审核、3审核不通过
        /// </summary>
        [Required]
        [Display(Name = "状态")]
        [Column(TypeName ="tinyint")]
        public int State { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "修改时间")]
        public DateTime LastUpdateTime { get; set; }

        [Display(Name = "修改者")]
        [StringLength(50)]
        public string Operator { get; set; }

        [StringLength(30)]
        [Display(Name = "IP")]
        public string ClientIP { get; set; }
    }
}
