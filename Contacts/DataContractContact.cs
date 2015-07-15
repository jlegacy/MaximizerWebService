using System;
using System.Runtime.Serialization;

namespace Maximizer
{
    [DataContract]
    public class DataContractContact
    {
        [DataMember] public String CBusId;
        [DataMember] public String CConId;
        [DataMember] public String CEmail;
        [DataMember] public String CFirstName;
        [DataMember] public String CLastName;
        [DataMember] public String CPhone1;
        [DataMember] public String CPhone2;
        [DataMember] public String CPhone1Ext;
        [DataMember] public String CPhone2Ext;
        [DataMember] public String CPhone1Fax;
        [DataMember] public String CPhone2Fax;
        [DataMember] public String CPosition;
    }
}