using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FGPay.Manager.Models;

namespace FGPay.Manager
{
    public static class DbInitializer
    {
        public static void Initialize(FGPayContext context)
        {
            context.Database.EnsureCreated();

            #region  加入测试数据
            if (context.Merchants.Any())//存在数据
            {
                return;
            }
            var agents = new Agent[] {
                new Agent{ AaliPayRate=2.0, AgentFullName="代理007", AgentState=1, Balance=860, AgentUserID="AG"+DateTime.Now.ToString("YYMMdd")+"007",
                 CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, Operator="admin", Remark="哈哈", UnionPayRate=2.5, WeChatPayRate=2.5},
                     new Agent{ AaliPayRate=2.0, AgentFullName="代理005", AgentState=1, Balance=860, AgentUserID="AG"+DateTime.Now.ToString("YYMMdd")+"021",
                 CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, Operator="admin", Remark="哈哈", UnionPayRate=2.5, WeChatPayRate=2.5},
                          new Agent{ AaliPayRate=2.0, AgentFullName="代理002", AgentState=1, Balance=860, AgentUserID="AG"+DateTime.Now.ToString("YYMMdd")+"035",
                 CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, Operator="admin", Remark="哈哈", UnionPayRate=2.5, WeChatPayRate=2.5}
            };

            foreach (var item in agents)
            {
                context.Agents.Add(item);
            }
            context.SaveChanges();

            var merchants = new Merchant[] {
                new Merchant{ AgentID=agents.Single(d=>d.AgentFullName=="代理007").AgentID, Balance=20000,CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, Md5key=Guid.NewGuid().ToString(),
                    MerchantFullName ="美高梅",  MerchantUserID="ME"+DateTime.Now.ToString("YYMMdd")+"02", Operator="admin", PassWord="123", PhoneNumber="136592233356", PrepaidRate=3.0,
                 Remark="", SettleType=1, WithdrawalRate=0},
                                new Merchant{ AgentID=agents.Single(d=>d.AgentFullName=="代理007").AgentID,Balance=1000,CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, Md5key=Guid.NewGuid().ToString(),
                    MerchantFullName ="天域",  MerchantUserID="ME"+DateTime.Now.ToString("YYMMdd")+"17",Operator="admin", PassWord="123", PhoneNumber="136592233356", PrepaidRate=3.0,
                 Remark="", SettleType=1, WithdrawalRate=0},
                                                new Merchant{ AgentID=agents.Single(d=>d.AgentFullName=="代理007").AgentID, Balance=0,CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, Md5key=Guid.NewGuid().ToString(),
                    MerchantFullName ="瑞吉",  MerchantUserID="ME"+DateTime.Now.ToString("YYMMdd")+"39", Operator="admin", PassWord="123", PhoneNumber="136592233356", PrepaidRate=3.0,
                  SettleType=1, WithdrawalRate=0},
            };
            foreach (var item in merchants)
            {
                context.Merchants.Add(item);
            }
            context.SaveChanges();

            var merchantRates = new MerchantRate[] {
                new MerchantRate{ CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, MerchantID=merchants.Single(d=>d.MerchantFullName=="美高梅").MerchantID, Operator="admin", Rate=3.0, PaymentType=PaymentType.AliPay, State=1},
                 new MerchantRate{ CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, MerchantID=merchants.Single(d=>d.MerchantFullName=="美高梅").MerchantID,Operator="admin", Rate=3.0, PaymentType=PaymentType.WechatPay, State=1},
                  new MerchantRate{ CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, MerchantID=merchants.Single(d=>d.MerchantFullName=="美高梅").MerchantID,Operator="admin", Rate=3.0, PaymentType=PaymentType.UnionPay, State=1},
                   new MerchantRate{ CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, MerchantID=merchants.Single(d=>d.MerchantFullName=="天域").MerchantID, Operator="admin", Rate=3.0, PaymentType=PaymentType.AliPay, State=1},
                    new MerchantRate{ CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, MerchantID=merchants.Single(d=>d.MerchantFullName=="天域").MerchantID,Operator="admin", Rate=3.0, PaymentType=PaymentType.WechatPay, State=1},
                     new MerchantRate{ CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, MerchantID=merchants.Single(d=>d.MerchantFullName=="天域").MerchantID, Operator="admin", Rate=3.0, PaymentType=PaymentType.UnionPay, State=1},
            };

            foreach (var item in merchantRates)
            {
                context.MerchantRates.Add(item);
            }
            context.SaveChanges();
            #endregion
        }
    }
}
