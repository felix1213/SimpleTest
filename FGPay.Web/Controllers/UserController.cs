using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FGPay.Web.Domain;
using FGPay.Web.Models;
using FGPay.Code;
using FGPay.Domain.Entity;

namespace FGPay.Web.Controllers
{
    public class UserController : BaseController
    {
        DAL.UserDAL userDAL = new DAL.UserDAL(); //测试用，尚未确定与DB交互的分层划分

        [PermissionFilter]
        public IActionResult Index()
        {
            return View();
        }

        [PermissionFilter("user", "index")]
        public IActionResult GetGridJson(Pagination pagination, string keyword)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(keyword))
            {
                pars["keyword"] = keyword;
            }
            var data = new
            {
                rows = userDAL.QryUsers<UserEntity>(pagination,pars),//DALUtility.UserCore.QryUsers<UserEntity>(pagination, pars), 
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [PermissionFilter("user", "index")]
        public IActionResult UserEdit(int ID = 0)
        {
            var userInfo = new UserEntity();
            #region MockData

            #endregion
            if (ID > 0)
            {
                Dictionary<string, object> paras = new Dictionary<string, object>();
                paras["ID"] = ID;
                // userInfo = DALUtility.UserCore.QryUserInfo<UserEntity>(paras);
            }
            return View(userInfo);
        }

        [PermissionFilter("user", "index", Operationype.Add)]
        public IActionResult Add(UserEntity userEntity)
        {
            return SubmitForm(userEntity);
        }

        [PermissionFilter("user", "index", Operationype.Update)]
        public IActionResult Update(UserEntity userEntity)
        {
            return SubmitForm(userEntity);
        }

        private IActionResult SubmitForm(UserEntity userEntity)
        {
            Dictionary<string, object> paras = new Dictionary<string, object>();
            paras["ID"] = userEntity.ID;
            paras["AccountName"] = userEntity.AccountName;
            paras["Email"] = userEntity.Email;
            //验证账号、邮箱是否重复
            int result = 0;// DALUtility.UserCore.CheckUseridAndEmail(paras); //1 账号重复 2邮箱重复
            if (result > 0)
            {
                return OperationReturn(false, result == 1 ? "账号重复" : "邮箱重复");
            }
            if (userEntity.Password != "******")
            {
                paras["Password"] = userEntity.Password;
            }
            // 用户是否修改密码
            if (userEntity.ID == 0)
            {
                paras["IfChangePwd"] = false;
            }
            paras["RealName"] = userEntity.RealName;
            paras["RoleId"] = userEntity.RoleId;
            paras["MobilePhone"] = userEntity.MobilePhone;
            paras["Birthday"] = userEntity.Birthday;
            paras["IsAble"] = userEntity.IsAble;
            paras["Description"] = userEntity.Description == null ? "" : userEntity.Description;
            // 改变部门时初始化职务
            //if (userEntity.ID != 0)
            //{
            //    Dictionary<string, object> para = new Dictionary<string, object>();
            //    para["ID"] = userEntity.ID;
            //    // 获取原部门
            //    int departmentId = DALUtility.UserCore.QryUserInfo<UserEntity>(paras).DepartmentId;
            //    if (departmentId != userEntity.DepartmentId)
            //    {
            //        paras["DutyId"] = 1;
            //    }
            //}
            bool boo = true;//DALUtility.UserCore.Save(paras) > 0;
            return OperationReturn(boo);
        }

        /// <summary>
        ///  修改用户是否启用
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="IsAble"></param>
        /// <returns></returns>
        [PermissionFilter("user", "index", Operationype.Update)]
        public IActionResult UpdateIsAble(int ID, bool IsAble)
        {
            Dictionary<string, object> paras = new Dictionary<string, object>();
            paras["ID"] = ID;
            paras["IsAble"] = IsAble;
            return OperationReturn(true);//DALUtility.UserCore.Save(paras) > 0);
        }
        /// <summary>
        ///  用户删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>

        [PermissionFilter("user", "index", Operationype.Delete)]
        public IActionResult Delete(int ID)
        {
            return OperationReturn(true);//DALUtility.UserCore.OnlyDeleteUser(ID.ToString()));
        }
    }
}