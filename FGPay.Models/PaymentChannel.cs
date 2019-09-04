using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FGPay.Models
{
    /// <summary>
    /// 支付通道
    /// </summary>
    public class PaymentChannel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "支付类型")]
        [Column(TypeName = "tinyint")]
        public PaymentType PaymentType { get; set; }
        [Required]
        [Display(Name = "支付名称")]
        [StringLength(50)]
        public string ChannelName { get; set; }

        [Required]
        [Display(Name = "每笔最低限额")]
        [Column(TypeName = "money")]
        public decimal MinLimitSingle{ get; set; }
        [Required]
        [Display(Name = "每笔最大限额")]
        [Column(TypeName = "money")]
        public decimal MaxLimitSingle { get; set; }
        [Required]
        [Display(Name = "每日限额")]
        [Column(TypeName = "money")]
        public decimal MaxLimitDaily{ get; set; }

        /// <summary>
        /// 1正常，2表示停用
        /// </summary>
        [Required]
        [Display(Name = "通道状态")]
        [Column(TypeName = "tinyint")]
        public int ChannelState { get; set; }

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
    }
}
