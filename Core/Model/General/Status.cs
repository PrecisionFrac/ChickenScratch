using System.Runtime.Serialization;

namespace ChickenScratch.Model
{
    [DataContract]
    public enum StatusEnum
    {
        [EnumMember]
        Active = 'A'
    }
}
