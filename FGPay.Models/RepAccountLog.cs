using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FGPay.Models
{
    /// <summary>
    /// 码商，操作日志信息
    /// </summary>
    public  class RepAccountLog
    {
        public int ID { get; set; }

        /// <summary>
        ///1 登陆、2提现、3取款、4上传二维码、5管理二维码
        /// </summary>
        [Required]
        [Display(Name = "日志类型")]
        [Column(TypeName = "tinyint")]
        public int LogType { get; set; }

        /// <summary>
        /// 登陆、提现、取款、上传二维码、管理二维码
        /// </summary>
        [Required]
        [Display(Name = "日志类型")]
        [Column(TypeName = "varchar(20)")]
        public string LogTitle { get; set; }

        [Required]
        [Display(Name = "用户名")]
        [StringLength(50)]
        public string UserID { get; set; }

        [Required]
        [Display(Name = "内容")]
        [StringLength(300)]
        public string Information { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 冗余字段，用于日期查询
        /// </summary>
        [Display(Name = "创建日期")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "IP")]
        public string ClientIP { get; set; }
    }
}
