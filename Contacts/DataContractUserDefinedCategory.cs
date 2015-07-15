using System;
using System.Runtime.Serialization;

namespace Maximizer
{
    public class DataContractUserDefinedCategory
    {
        [DataMember] public String XUserDefId;
        [DataMember] public String XUserDefText;
        [DataMember] public String XUserSort;
    }
}