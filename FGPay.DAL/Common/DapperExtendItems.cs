using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  FGPay.DAL
{
    public class GridData
    {
        public string SortField { get; set; }
        public string SortDirection { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int RecordCount { get; set; }
    }

    public class WhereBuilder
    {
        private DynamicParameters _parameters = new DynamicParameters();

        public DynamicParameters Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        private List<string> _wheres = new List<string>();

        public List<string> Wheres
        {
            get { return _wheres; }
            set { _wheres = value; }
        }


        private string _fromSql = String.Empty;

        public string FromSql
        {
            get { return _fromSql; }
            set { _fromSql = value; }
        }

        public void AddWhere(string item)
        {
            _wheres.Add(item);
        }

        public void AddParameter(string name, object value)
        {
            _parameters.Add(name, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paras">当前参数集</param>
        /// <param name="key">paras[key]中的key</param>
        /// <param name="dbField">DB字段</param>
        /// <param name="operatorTag">运算符(= > < >= like ……)</param>
        /// <param name="obj"></param>
        /// <param name="addParameter"></param>
        public void AddWhereAndParameter(Dictionary<string, object> paras, string key, string dbField = "", string operatorTag = "=", string obj = "", bool addParameter = true)
        {
            if (paras.ContainsKey(key) && !string.IsNullOrEmpty(paras[key].ToString()))
            {
                if (string.IsNullOrEmpty(dbField))
                {
                    dbField = key;
                }
                if (string.IsNullOrEmpty(obj))
                {
                    obj = key;
                }
                AddWhere(string.Format("{0} {1} {2}", dbField, operatorTag, obj.Equals(key) ? "@" + obj : obj));
                if (addParameter)
                {
                    AddParameter(key, paras[key]);
                }
            }
        }
    }
}
