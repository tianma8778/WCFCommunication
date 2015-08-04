using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using JJY.WCF.Entity;

namespace JJY.WCF.Interface
{
    [ServiceContract]
    public interface IGood
    {
        [OperationContract]
        string GetGoodName();
    }
}
