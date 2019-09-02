using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FGPay.Manager.Models
{
    /// <summary>
    /// 代理
    /// </summary>
    public class Agent
    {
        public int AgentID { get; set; }
        [Display(Name ="用户名")]
        [StringLength(50)]
        public string AgentUserID { get; set; }

        [Display(Name = "代理名称")]
        [StringLength(50)]
        public string AgentFullName { get; set; }

        [Display(Name = "账户余额")]
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        [Display(Name = "支付宝费率")]
        [Column(TypeName = "numeric(4, 2)")]
        public Double AaliPayRate { get; set; }

        [Display(Name = "微信费率")]
        [Column(TypeName = "numeric(4, 2)")]
        public Double WeChatPayRate { get; set; }

        [Display(Name = "云闪付费率")]
        [Column(TypeName = "numeric(4, 2)")]
        public Double UnionPayRate { get; set; }

        [Display(Name = "备注")]
        [StringLength(100)]
        public string Remark { get; set; } = "";

        /// <summary>
        /// 1正常，2表示禁用
        /// </summary>
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



    }
}
