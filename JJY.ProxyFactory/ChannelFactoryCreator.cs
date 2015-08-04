using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Collections;

namespace JJY.ProxyFactory
{
    internal static class ChannelFactoryCreator
    {
        //键值对 存放通道工厂,对HashTable进行加锁声明  允许并发读但只能一个线程写
        private static Hashtable channelFactories = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// 根据地址创建通道工厂
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpointName"></param>
        /// <returns></returns>
        public static ChannelFactory<T> Create<T>(string endpointName)
        {
            //是否地址是否为空
            if (string.IsNullOrEmpty(endpointName))
            {
                throw new ArgumentNullException("endpointName");
            }

            //声明一个空的通道工厂
            ChannelFactory<T> channelFactory = null;

            //判断是否存在此通道工厂
            //存在，获取通道工厂
            if (channelFactories.ContainsKey(endpointName))
            {
                channelFactory = channelFactories[endpointName] as ChannelFactory<T>;
            }

            //不存在，创建通道工厂
            if (channelFactory == null)
            {

                channelFactory = new ChannelFactory<T>(endpointName);
                channelFactory.Credentials.UserName.UserName = "gongjing";
                channelFactory.Credentials.UserName.Password = "111";
                //对写入进行加锁
                lock (channelFactories.SyncRoot)
                {
                    channelFactories[endpointName] = channelFactory;
                }
            }
            return channelFactory;
        }
    }
}
