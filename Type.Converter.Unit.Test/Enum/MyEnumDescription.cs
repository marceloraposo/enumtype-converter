using System.ComponentModel;
using Type.Converter;

namespace Type.Converter.Unit.Test.Enum
{
    public enum MyEnumDescription
    {
        [Description("Sim")]
        Yes = 0,
        [Description("Não")]
        No = 1
    }
}