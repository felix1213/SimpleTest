using System;
using System.Data;
using System.Collections.Generic;
using FGPay.Domain.Entity;

namespace FGPay.IDAL
{
    /// <summary>
    /// 系统设置
    /// </summary>
    public interface ISystemDAL
    {
        #region 选单权限相关

        /// <summary>
        /// 获得对应角色的选单权限
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paras"></param>
        /// <returns></returns>
        IEnumerable<T> RoleMenuGetListByRoleId<T>(Dictionary<string, object> paras);

        /// <summary>
        /// 获得角色
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> RoleGetList<T>(Dictionary<string, object> paras);

        int RoleSave(Dictionary<string, object> paras);

        /// <summary>
        ///  根据Id删除角色
        /// </summary>
        /// <param name="paras"></param>
        /// <returns></returns>
        int RoleDelete(Dictionary<string, object> paras);

        #endregion

        #region 系统数据相关

        /// <summary>
        /// 系统数据加载
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="RoleId"></param>
        /// <param name="groups"></param>
        /// <param name="departments"></param>
        /// <param name="projects"></param>
        /// <param name="tasks"></param>
        /// <param name="prioritys"></param>
        /// <param name="menuPermissions"></param>
        void SystemDataInit<T1, T2, T3>(int RoleId, ref List<T1> groups, ref List<T2> departments, ref List<T2> projects, ref List<T2> tasks, ref List<T2> prioritys, ref List<T2> expenses, ref List<T2> duty, ref List<T3> menuPermissions);

        /// <summary>
        /// 新增/修改 公用数据类型
        /// </summary>
        /// <param name="libraryEntity"></param>
        /// <returns></returns>
        int LibrarySave(LibraryEntity libraryEntity);

        /// <summary>
        ///  获得公用数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paras"></param>
        /// <returns></returns>
        IEnumerable<T> LibraryGetList<T>(Dictionary<string, object> paras);

        /// <summary>
        /// 删除公用数据 (可批量删除)
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        bool DeleteLibrary(int id, int tag);

        #endregion

        #region 选单相关

        /// <summary>
        ///  新增/修改 菜单
        /// </summary>
        /// <param name="paras"></param>
        /// <returns></returns>
        int MemuSave(Dictionary<string, object> paras);

        /// <summary>
        ///  删除菜单 (可批量删除)
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        bool DeleteMemu(string idList);

        /// <summary>
        /// 获得选单
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paras"></param>
        /// <returns></returns>
        IEnumerable<T> MenuGetList<T>(Dictionary<string, object> paras);

        #endregion
    }
}
