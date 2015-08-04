using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JJY.WCF.ConsLanuch
{
    public class Validator : System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName != "gongjing" || password != "111")
            {
                throw new FaultException(new FaultReason("用户名或密码错误"), new FaultCode("Error:0x0001"));
            }
        }
    }
}
