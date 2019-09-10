using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FGPay.Models
{
    /// <summary>
    /// 选单
    /// </summary>
    public class SystemMenu
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MenuID { get; set; }

        [Required]
        [Display(Name = "选单标识")]
        [Column(TypeName = "tinyint")]
        public int MenuTag { get; set; }

        [Display(Name = "选单名称")]
        [StringLength(20)]
        public string Name { get; set; }

        [Display(Name = "Controller")]
        [StringLength(20)]
        public string Controller { get; set; }

        [Display(Name = "Action")]
        [StringLength(20)]
        public string Action { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        [Display(Name = "父级ID")]
        public int Parentid { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Required]
        [Display(Name = "状态")]
        [Column(TypeName = "tinyint")]
        public int State { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        public int Sort { get; set; }
    }
}
