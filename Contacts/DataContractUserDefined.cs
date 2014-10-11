using System;
using System.Runtime.Serialization;

namespace Maximizer
{
    [DataContract]
    public class DataContractUserDefined
    {
        [DataMember] public String UBusId;
        [DataMember] public String UConId;
        [DataMember] public String UUsrId;
        [DataMember] public String UField;
        [DataMember] public String UItem;
        [DataMember] public String UType;
    }
}