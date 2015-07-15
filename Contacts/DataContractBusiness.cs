using System;
using System.Runtime.Serialization;

namespace Maximizer
{
    [DataContract]
    public class DataContractBusiness
    {
        [DataMember] public String BAddress;
        [DataMember] public String BBusId;
        [DataMember] public String BCity;
        [DataMember] public String BEmail;
        [DataMember] public String BName;
        [DataMember] public String BPhone1;
        [DataMember] public String BPhone2;
        [DataMember] public String BFax1;
        [DataMember] public String BState;
        [DataMember] public String BZip;
    }
}