using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FGPay.Models;

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
                new Agent{  AgentFullName="代理007", AgentState=1, Balance=860, AgentUserID="AG"+DateTime.Now.ToString("YYMMdd")+"007",
                 CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, Operator="admin", Remark="哈哈"},
                     new Agent{ AgentFullName="代理005", AgentState=1, Balance=860, AgentUserID="AG"+DateTime.Now.ToString("YYMMdd")+"021",
                 CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, Operator="admin", Remark="哈哈", },
                          new Agent{  AgentFullName="代理002", AgentState=1, Balance=860, AgentUserID="AG"+DateTime.Now.ToString("YYMMdd")+"035",
                 CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, Operator="admin", Remark="哈哈"}
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
                new MerchantRate{ CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, MerchantID=merchants.Single(d=>d.MerchantFullName=="美高梅").ID, Operator="admin", Rate=3.0, PaymentType=PaymentType.AliPay, State=1},
                 new MerchantRate{ CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, MerchantID=merchants.Single(d=>d.MerchantFullName=="美高梅").ID,Operator="admin", Rate=3.0, PaymentType=PaymentType.WechatPay, State=1},
                  new MerchantRate{ CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, MerchantID=merchants.Single(d=>d.MerchantFullName=="美高梅").ID,Operator="admin", Rate=3.0, PaymentType=PaymentType.UnionPay, State=1},
                   new MerchantRate{ CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, MerchantID=merchants.Single(d=>d.MerchantFullName=="天域").ID, Operator="admin", Rate=3.0, PaymentType=PaymentType.AliPay, State=1},
                    new MerchantRate{ CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, MerchantID=merchants.Single(d=>d.MerchantFullName=="天域").ID,Operator="admin", Rate=3.0, PaymentType=PaymentType.WechatPay, State=1},
                     new MerchantRate{ CreateTime=DateTime.Now, LastUpdateTime=DateTime.Now, MerchantID=merchants.Single(d=>d.MerchantFullName=="天域").ID, Operator="admin", Rate=3.0, PaymentType=PaymentType.UnionPay, State=1},
            };

            foreach (var item in merchantRates)
            {
                context.MerchantRates.Add(item);
            }
            context.SaveChanges();

            var mainMenus = new SystemMenu[] {
                new SystemMenu(){ MenuTag=1,Name="代理管理",Parentid=0,Icon="users",Controller="",Action="",State=1,Sort=10 },
                new SystemMenu(){ MenuTag=1,Name="商户管理",Parentid=0,Icon="users",Controller="",Action="",State=1,Sort=9 },
                new SystemMenu(){ MenuTag=1,Name="代收(码商)管理",Parentid=0,Icon="users",Controller="",Action="",State=1,Sort=8 },
                new SystemMenu(){ MenuTag=1,Name="设置",Parentid=0,Icon="sliders",Controller="",Action="",State=1,Sort=7 },
                new SystemMenu(){ MenuTag=1,Name="营收统计",Parentid=0,Icon="grid",Controller="",Action="",State=1,Sort=6 }
            };

            foreach (var item in mainMenus)
            {
                context.SystemMenu.Add(item);
            }
            context.SaveChanges();

            var subMenus = new SystemMenu[] {
                new SystemMenu(){ MenuTag=1,Name="代理信息",Parentid=1,Controller="Agent",Action="Index",State=1,Sort=10 },
                new SystemMenu(){ MenuTag=1,Name="费率设置",Parentid=1,Controller="Agent",Action="Index",State=1,Sort=9 },
                new SystemMenu(){ MenuTag=1,Name="取现订单",Parentid=1,Controller="Agent",Action="Index",State=1,Sort=8 },
                new SystemMenu(){ MenuTag=1,Name="交易记录",Parentid=1,Controller="Agent",Action="Index",State=1,Sort=7 },
                new SystemMenu(){ MenuTag=1,Name="商户信息",Parentid=2,Controller="Merchant",Action="Index",State=1,Sort=10 },
                new SystemMenu(){ MenuTag=1,Name="费率设置",Parentid=2,Controller="Merchant",Action="Index",State=1,Sort=9 },
                new SystemMenu(){ MenuTag=1,Name="订单信息",Parentid=2,Controller="Merchant",Action="Index",State=1,Sort=8 },
                new SystemMenu(){ MenuTag=1,Name="取现订单",Parentid=2,Controller="Merchant",Action="Index",State=1,Sort=7 },
                new SystemMenu(){ MenuTag=1,Name="交易记录",Parentid=2,Controller="Merchant",Action="Index",State=1,Sort=6 },
                new SystemMenu(){ MenuTag=1,Name="代收信息",Parentid=3,Controller="Agent",Action="Index",State=1,Sort=10 },
                new SystemMenu(){ MenuTag=1,Name="缴纳保证金订单",Parentid=3,Controller="Agent",Action="Index",State=1,Sort=9 },
                new SystemMenu(){ MenuTag=1,Name="取现订单",Parentid=3,Controller="Agent",Action="Index",State=1,Sort=8 },
                new SystemMenu(){ MenuTag=1,Name="操作记录",Parentid=3,Controller="Agent",Action="Index",State=1,Sort=7 },
                new SystemMenu(){ MenuTag=1,Name="银行账户",Parentid=4,Controller="Merchant",Action="Index",State=1,Sort=10 },
                new SystemMenu(){ MenuTag=1,Name="支付通道",Parentid=4,Controller="Merchant",Action="Index",State=1,Sort=9 },
                new SystemMenu(){ MenuTag=1,Name="二维码信息",Parentid=4,Controller="Merchant",Action="Index",State=1,Sort=8 },
                new SystemMenu(){ MenuTag=1,Name="选单管理",Parentid=4,Controller="SystemMenu",Action="Index",State=1,Sort=7 },
                new SystemMenu(){ MenuTag=1,Name="群组管理",Parentid=4,Controller="Merchant",Action="Index",State=1,Sort=6 },
                new SystemMenu(){ MenuTag=1,Name="后台用户管理",Parentid=4,Controller="Merchant",Action="Index",State=1,Sort=5 },
                new SystemMenu(){ MenuTag=1,Name="报表1",Parentid=5,Controller="Merchant",Action="Index",State=1,Sort=5 },
                new SystemMenu(){ MenuTag=1,Name="报表2",Parentid=5,Controller="Merchant",Action="Index",State=1,Sort=5 },
                new SystemMenu(){ MenuTag=1,Name="报表3",Parentid=5,Controller="Merchant",Action="Index",State=1,Sort=5 },
                new SystemMenu(){ MenuTag=1,Name="报表4",Parentid=5,Controller="Merchant",Action="Index",State=1,Sort=5 },
                new SystemMenu(){ MenuTag=1,Name="外链",Parentid=5, Target="_blank",Href="http://www.qq.com",State=1,Sort=5 }
            };

            foreach (var item in subMenus)
            {
                context.SystemMenu.Add(item);
            }
            context.SaveChanges();
            #endregion
        }
    }
}
