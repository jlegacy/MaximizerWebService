using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Maximizer
{
    [DataContract]
    public class RequestTest
    {
         [DataMember] 
        public String Test { get; set; }
        [DataMember] 
         public String Test2 { get; set; }
       
    }
}