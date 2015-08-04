using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.ServiceModel;

namespace JJY.ProxyFactory
{
    public class ServiceRealProxy<T> : RealProxy
    {

        private string _endpointName;
        public ServiceRealProxy(string endpointName)
            : base(typeof(T))
        {
            if (string.IsNullOrEmpty(endpointName))
            {
                throw new ArgumentNullException("endpointName");
            }
            this._endpointName = endpointName;

        }

        public override IMessage Invoke(IMessage msg)
        {
            //创建指定终结点地址的指定类型的通道
            T channel = ChannelFactoryCreator.Create<T>(this._endpointName).CreateChannel();
            //定义方法调用的消息接口
            IMethodCallMessage methodCall = (IMethodCallMessage)msg;
            //定义方法调用返回消息接口
            IMethodReturnMessage methodReturn = null;
            //创建一个object类型的methodCall参数数组
            object[] copiedArgs = Array.CreateInstance(typeof(object), methodCall.Args.Length) as object[];
            //将参数复制到数组中
            methodCall.Args.CopyTo(copiedArgs, 0);
            try
            {
                //获得channel类中的符合copiedArgs参数的方法的返回值
                object returnValue = methodCall.MethodBase.Invoke(channel, copiedArgs);
                //保存为响应远程对象上的方法调用而返回的消息

                //从中生成当前 ReturnMessage 实例的被调用方法所返回的对象。 
                //作为 out 参数从被调用方法返回的对象。 
                //从被调用方法返回的 out 参数的数目。 
                //方法调用的 LogicalCallContext。提供在进行远程方法调用期间用执行代码路径传送的一组属性。 
                //对被调用方法进行的原始方法调用。 
                methodReturn = new ReturnMessage(returnValue, copiedArgs, copiedArgs.Length, methodCall.LogicalCallContext, methodCall);
                //关闭通信对象
                (channel as ICommunicationObject).Close();

            }

            catch (Exception ex)
            {
                if (ex.InnerException is CommunicationException || ex.InnerException is TimeoutException)
                {
                    (channel as ICommunicationObject).Abort();
                }
                if (ex.InnerException != null)
                {
                    methodReturn = new ReturnMessage(ex.InnerException, methodCall);
                }
                else
                {
                    methodReturn = new ReturnMessage(ex, methodCall);
                }
            }
            return methodReturn;

        }

    }
}
