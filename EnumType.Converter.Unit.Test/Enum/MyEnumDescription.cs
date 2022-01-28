using System.ComponentModel;
using EnumType.Converter;

namespace EnumType.Converter.Unit.Test.Enum
{
    public enum MyEnumDescription
    {
        [Description("Sim")]
        Yes = 0,
        [Description("Não")]
        No = 1
    }
}