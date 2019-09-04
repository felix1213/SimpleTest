using Dapper;
using FGPay.Code;
using FGPay.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FGPay.DAL
{
    public class UserDAL : BaseDal
    {
        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <typeparam name="T">数据集</typeparam>
        /// <param name="pagination">分页信息</param>
        /// <param name="paras">查询条件参数</param>
        /// <returns></returns>
        public IEnumerable<T> QryUsers<T>(Pagination pagination, Dictionary<string, object> paras)
        {
            WhereBuilder builder = new WhereBuilder();
            builder.FromSql = "tbUser";
            if (paras.ContainsKey("keyword"))
            {
                builder.AddWhere(" (AccountName Like '%'+@keyword+'%' OR RealName Like '%'+@keyword+'%')");
                builder.AddParameter("keyword", paras["keyword"]);
            }

            var rows = SortAndPage<T>(builder, pagination);
            return rows;
        }
        

        /// <summary>
        /// 新增/修改用户
        /// </summary>
        /// <param name="paras"></param>
        /// <returns></returns>
        public int Save(Dictionary<string, object> paras)
        {
            return StandardInsertOrUpdate("tbUser", paras, "ID", true, OperateType.User);
        }
    }
}
