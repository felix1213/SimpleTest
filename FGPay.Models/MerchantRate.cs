using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FGPay.Models
{

    /// <summary>
    /// 商户费率表
    /// </summary>
    public class MerchantRate
    {
        public int ID { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }

        [Required]
        [Display(Name = "费率")]
        [Column(TypeName = "numeric(4, 2)")]
        public Double Rate { get; set; }

        /// <summary>
        /// 1正常，2禁用
        /// </summary>
        [Display(Name = "状态")]
        [Column(TypeName = "tinyint")]
        public int State { get; set; } = 1;

        [Display(Name = "操作员")]
        [StringLength(50)]
        public string Operator { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "创建时间")]
        public DateTime  CreateTime { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "修改时间")]
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        public int MerchantID { get; set; }

        public Merchant Merchant { get; set; }
    }
}
