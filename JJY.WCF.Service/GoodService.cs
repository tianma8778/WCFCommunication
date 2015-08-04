using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JJY.WCF.Interface;

namespace JJY.WCF.Service
{
    public class GoodService:IGood
    {
        public string GetGoodName()
        {
            return "Name";
        }
    }
}
