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

        [Required]
        [Display(Name = "选单名称")]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        [Required]
        [Display(Name = "父级")]
        public int Parentid { get; set; }

        [Display(Name="Icon")]
        [Column(TypeName = "varchar(20)")]
        public string Icon { get; set; }

        [Display(Name = "Controller")]
        [Column(TypeName = "varchar(20)")]
        public string Controller { get; set; }

        [Display(Name = "Action")]
        [Column(TypeName = "varchar(20)")]
        public string Action { get; set; }
        
        [Display(Name = "Target")]
        [Column(TypeName = "varchar(20)")]
        public string Target { get; set; }

        [Display(Name = "Href")]
        [Column(TypeName = "varchar(40)")]
        public string Href { get; set; }

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
        [Required]
        [Display(Name = "排序值")]
        [Column(TypeName = "tinyint")]
        public int Sort { get; set; }
    }
}
