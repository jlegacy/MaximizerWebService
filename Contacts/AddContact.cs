using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Maximizer
{
      [DataContract]
    public class AddContact
    {
        [DataMember]
        public String CBusId;
        [DataMember]
        public String CConId;
        [DataMember]
        public String CFirstName;
        [DataMember]
        public String CLastName;
        [DataMember]
        public String CPosition;
        [DataMember]
        public String CPhone1;
        [DataMember]
        public String CPhone2;
        [DataMember]
        public String CPhone1Fax;
        [DataMember]
        public String CPhone2Fax;
        [DataMember]
        public String CEmail;
        [DataMember]
        public String CPhone1Ext;
        [DataMember]
        public String CPhone2Ext;
    }
}