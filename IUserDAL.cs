using System.Collections.Generic;
using System.Data;
using FGPay.Code;
using FGPay.Domain.Entity;

namespace FGPay.IDAL
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public interface IUserDAL
    {

        /// <summary>
        /// 首次登陆强制修改密码
        /// </summary>
        bool InitUserPwd(UserEntity user);


        /// <summary>
        /// 用户登录
        /// </summary>
        UserEntity UserLogin(Dictionary<string, object> paras);

        UserEntity GetUserByUserId(string userId);


        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paras"></param>
        /// <param name="iCount"></param>
        /// <returns></returns>
        IEnumerable<T> QryUsers<T>(Dictionary<string, object> paras, out int iCount);

        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <typeparam name="T">数据集</typeparam>
        /// <param name="pagination">分页信息</param>
        /// <param name="paras">查询条件参数</param>
        /// <returns></returns>
        IEnumerable<T> QryUsers<T>(Pagination pagination, Dictionary<string, object> paras);
        IEnumerable<T> QryAllUser<T>();
        /// <summary>
        /// 查询用户资料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paras"></param>
        /// <returns></returns>
        T QryUserInfo<T>(Dictionary<string, object> paras);

        /// <summary>
        /// 检查账号、邮箱是否存在重复
        /// </summary>
        /// <param name="paras"></param>
        /// <returns></returns>
        int CheckUseridAndEmail(Dictionary<string, object> paras);

        /// <summary>
        /// 新增/修改用户
        /// </summary>
        /// <param name="paras"></param>
        /// <returns></returns>
        int Save(Dictionary<string, object> paras);
        /// <summary>
        /// 仅删除用户(可批量删除)
        /// </summary>
        /// <param name="idList">需要删除的id集</param>
        /// <returns></returns>
        bool OnlyDeleteUser(string idList);

        /// <summary>
        ///  查询真实姓名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        IEnumerable<T> QryRealName<T>(Dictionary<string, object> paras);

        /// <summary>
        ///  查询部门主管
        /// </summary>
        /// <param name="departmentId">部门编号</param>
        /// <returns></returns>
        string GetCharge(int departmentId);

        /// <summary>
        ///  设置部门主管(每个部门只存在一个主管)
        /// </summary>
        /// <param name="departmentId">部门编号</param>
        /// <param name="accountName">部门主管登录名</param>
        /// <returns></returns>
        bool SetCharge(int departmentId, string accountName);

    }
}
