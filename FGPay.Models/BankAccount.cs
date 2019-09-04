using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FGPay.Models
{
    /// <summary>
    /// 银行通道，收保证金账户管理
    /// </summary>
   public  class BankAccount
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "银行名称")]
        [StringLength(50)]
        public string BankFullName { get; set; }
        [Required]
        [Display(Name = "账号姓名")]
        [StringLength(50)]
        public string AccountName { get; set; }
        [Required]
        [Display(Name = "银行卡号")]
        [StringLength(20)]
        public string AccountCardNumber { get; set; }

        /// <summary>
        /// 1启用,2停用
        /// </summary>
        [Required]
        [Display(Name = "状态")]
        [Column(TypeName = "tinyint")]
        public int State { get; set; }

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
    }
}
