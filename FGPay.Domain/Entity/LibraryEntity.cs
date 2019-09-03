using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGPay.Domain.Entity
{
    /// <summary>
    /// 表实体类
    /// 作者:J.Y
    /// 创建时间:2019-05-14 14:42:04
    /// </summary>
    [Serializable]
    public partial class LibraryEntity
    {
        private int _id;
        /// <summary>
        /// ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        private int _tag;
        /// <summary>
        /// 标识[1部门;2用户状态……]
        /// </summary>
        public int tag
        {
            set { _tag = value; }
            get { return _tag; }
        }
        private int _pid;
        /// <summary>
        /// 父级ID
        /// </summary>
        public int pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        private int _sort;
        /// <summary>
        /// 排序值
        /// </summary>
        public int sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        private string _name;
        /// <summary>
        /// 名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        private string _code;
        /// <summary>
        /// 用以关联多语系
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }

    }

}
