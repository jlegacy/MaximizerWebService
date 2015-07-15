using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Maximizer
{
     [DataContract]
    public class PassContactInfo
    {
         [DataMember] 
        public String CBusId { get; set; }
         [DataMember] 
        public String CConId { get; set; }
         [DataMember] 
        public String CFirstName { get; set; }
         [DataMember] 
        public String CLastName { get; set; }
         [DataMember] 
        public String CPosition { get; set; }
         [DataMember] 
        public String CPhone1 { get; set; }
         [DataMember] 
        public String CPhone2 { get; set; }
         [DataMember] 
        public String CPhone1Fax { get; set; }
         [DataMember] 
        public String CPhone2Fax { get; set; }
         [DataMember] 
        public String CEmail { get; set; }
         [DataMember]
         public String CPhone1Ext { get; set; }
         [DataMember]
         public String CPhone2Ext { get; set; }
    }
}