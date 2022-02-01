using System.Text.Json.Serialization;
using EnumType.Converter.Unit.Test.Enum;

namespace EnumType.Converter.Unit.Test.Model
{
    public class MyCustomModel
    {
        [JsonPropertyName("myCustomField")]
        public MyCustomEnum myCustomField { get; set; }
    }
}