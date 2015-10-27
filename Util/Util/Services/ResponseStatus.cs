using System.Runtime.Serialization;

namespace ChickenScratch.Util.Services
{
    [DataContract]
    public enum ResponseStatus : int
    {
        [EnumMember]
        ErrorValidation = -2,

        [EnumMember]
        Error = -1,

        [EnumMember]
        Information = 0,

        [EnumMember]
        Success = 1,

        [EnumMember]
        Warning = 2
    }
}
