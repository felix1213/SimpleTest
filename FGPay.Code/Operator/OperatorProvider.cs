﻿namespace FGPay.Code
{
    public class OperatorProvider
    {
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }
        private string LoginUserKey = "fgpay_loginuserkey";
        private string LoginProvider = "";//Configs.GetValue("LoginProvider");

        public OperatorModel GetCurrent()
        {
            OperatorModel operatorModel = new OperatorModel();
            //if (LoginProvider == "Cookie")
            //{
            //    operatorModel = DESEncrypt.Decrypt(WebHelper.GetCookie(LoginUserKey).ToString()).ToObject<OperatorModel>();
            //}
            //else
            //{
            //    operatorModel = DESEncrypt.Decrypt(WebHelper.GetSession(LoginUserKey).ToString()).ToObject<OperatorModel>();
            //}
            return operatorModel;
        }
        public void AddCurrent(OperatorModel operatorModel)
        {
            //if (LoginProvider == "Cookie")
            //{
            //    WebHelper.WriteCookie(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()), 60);
            //}
            //else
            //{
            //    WebHelper.WriteSession(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()));
            //}
            //WebHelper.WriteCookie("nfine_mac", Md5.md5(Net.GetMacByNetworkInterface().ToJson(), 32));
            //WebHelper.WriteCookie("nfine_licence", Licence.GetLicence());
        }
        public void RemoveCurrent()
        {
            //if (LoginProvider == "Cookie")
            //{
            //    WebHelper.RemoveCookie(LoginUserKey.Trim());
            //}
            //else
            //{
            //    WebHelper.RemoveSession(LoginUserKey.Trim());
            //}
        }
    }
}
