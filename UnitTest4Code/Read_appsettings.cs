using FGPay.Code.Configs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest4Code
{
    [TestClass]
    public class Read_appsettings
    {
        [TestMethod]
        public void TestMethod1()
        {
            var value = ConfigHelper.GetSectionValue("AllowedHosts");
            var strConn = ConfigHelper.GetConnectionString("DevConnection");
        }
    }
}
