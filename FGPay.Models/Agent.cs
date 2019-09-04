using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FGPay.Models
{
    /// <summary>
    /// 代理
    /// </summary>
    public class Agent
    {
        public int AgentID { get; set; }
        [Required]
        [Display(Name ="代理名")]
        [StringLength(20)]
        public string AgentUserID { get; set; }

        [Required]
        [Display(Name = "代理名称")]
        [StringLength(50)]
        public string AgentFullName { get; set; }

        [Required]
        [Display(Name = "账户余额")]
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }


        [Display(Name = "银行名称")]
        [StringLength(50)]
        public string BankFullName { get; set; }

        [Display(Name = "开户姓名")]
        [StringLength(50)]
        public string AccountName { get; set; }

        [Display(Name = "银行卡号")]
        [StringLength(20)]
        public string AccountCardNumber { get; set; }

        [Display(Name = "备注")]
        [StringLength(100)]
        public string Remark { get; set; } = "";

        /// <summary>
        /// 1正常，2表示禁用
        /// </summary>
        [Required]
        [Display(Name = "代理状态")]
        [Column(TypeName = "tinyint")]
        public int AgentState { get; set; } = 1;

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

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "登录时间")]
        public DateTime LastLoginTime { get; set; }

        [StringLength(30)]
        [Display(Name = "IP")]
        public string ClientIP { get; set; }

    }
}
