using EnumType.Converter.Unit.Test.Enum;
using EnumType.Converter;
using Newtonsoft.Json;

namespace EnumType.Converter.Unit.Test.Model
{
    public class MyModel
    {

        [JsonConverter(typeof(CharEnumConverter<MyEnum>))]
        public MyEnum myField;

        [JsonConverter(typeof(IntegerEnumConverter<MyEnumInteger>))]
        public MyEnumInteger myIntegerField;  

        [JsonConverter(typeof(DescriptionEnumConverter<MyEnumDescription>))]
        public MyEnumDescription myDescriptionField;                

    }
}