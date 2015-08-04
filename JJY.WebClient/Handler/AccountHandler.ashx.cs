using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using JJY.WCF.Entity;
using JJY.WCF.Interface;
using JJY.ProxyFactory;

namespace JJY.WebClient.Handler
{
    /// <summary>
    /// AccountHandler 的摘要说明
    /// </summary>
    public class AccountHandler : IHttpHandler
    {
        //private static IAccount iaccountClient;
        //public static IAccount IAccountClient
        //{
        //    get
        //    {
        //        if (iaccountClient == null)
        //        {
        //            iaccountClient = ServiceProxyFactory.Create<IAccount>("NetTcpBinding_IAccount");
        //        }
        //        return iaccountClient;
        //    }
        //}
        public void ProcessRequest(HttpContext context)
        {
            string type = context.Request["method"];


            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}