using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace JJY.WCF.ConsLanuch
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = null;
            
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            ServiceModelSectionGroup svcmod = (ServiceModelSectionGroup)conf.GetSectionGroup("system.serviceModel");

            foreach (ServiceElement el in svcmod.Services.Services)
            {
                Type type = Type.GetType(el.Name+",JJY.WCF.Service");
                if(type == null)
                {
                    Console.WriteLine(string.Format("服务{0}实例化失败"), el.Name);
                }
                host = new ServiceHost(type);
                //host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
                try
                {
                    host.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("服务{0}启动失败", el.Name));
                    Console.WriteLine(string.Format("错误内容:{0}", ex.ToString()));
                }
                Console.WriteLine(string.Format("{0}已经启动",el.Name));
            }
            Console.ReadLine();
        }
    }
}
