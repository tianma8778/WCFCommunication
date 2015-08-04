using JJY.WCF.Interface;
using JJY.WCF.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJY.WCF.Service
{
    public class AccountService:IAccount
    {
        public ACUser GetUser()
        {
            ACUser user = new ACUser { Name = "林世荣" };
            return user;
        }
    }
}
