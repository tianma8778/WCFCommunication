using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace JJY.WCF.Entity
{
    [DataContract]
    public class ACUser
    {
        [DataMember]
        public string Name { get; set; }
    }
}
