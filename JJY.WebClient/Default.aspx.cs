using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JJY.WCF.Entity;
using JJY.WCF.Interface;
using JJY.ProxyFactory;

namespace JJY.WebClient
{
    public partial class Default : System.Web.UI.Page
    {
        private static IAccount iaccountClient;
        public static IAccount IAccountClient
        {
            get
            {
                if (iaccountClient == null)
                {
                    iaccountClient = ServiceProxyFactory.Create<IAccount>("NetTcpBinding_IAccount");
                }
                return iaccountClient;
            }
        }

        private static IGood  igoodClient;
        public static IGood IGoodClient
        {
            get
            {
                if (igoodClient == null)
                {
                    igoodClient = ServiceProxyFactory.Create<IGood>("NetTcpBinding_IGood");
                }
                return igoodClient;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            //这个是WCF端开放了MexData，从net.tcp://localhost:8084/accoun/mex下载的数据
            //account.AccountClient client = new account.AccountClient();
            //ACUser user = client.GetUser();

            //这个是用的本地接口的方法
            string name = IGoodClient.GetGoodName();
            //ACUser user1 = IAccountClient.GetUser();
        }
    }
}