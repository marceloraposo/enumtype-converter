using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace EnumType.Converter.Unit.Test.Enum
{
    public enum MyCustomEnum
    {
        [EnumMember(Value = "Sim")]
        Sim,
        [EnumMember(Value = "Não")]
        Nao,        
    }
}