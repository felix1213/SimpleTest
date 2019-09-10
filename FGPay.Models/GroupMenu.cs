using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FGPay.Models
{
    public class GroupMenu
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// 群组ID
        /// </summary>
        [Required]
        [Display(Name = "群组")]
        public int GroupID { get; set; }

        /// <summary>
        /// 选单ID
        /// </summary>
        [Required]
        [Display(Name = "选单")]
        public int MenuID { get; set; }

        [Display(Name = "新增")]
        public bool Add { get; set; }

        [Display(Name = "修改")]
        public bool Update { get; set; }

        [Display(Name = "删除")]
        public bool Delete { get; set; }

        [Display(Name = "其他")]
        public bool Other { get; set; }
    }
}
