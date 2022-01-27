using Type.Converter.Unit.Test.Enum;
using Type.Converter;
using Newtonsoft.Json;

namespace Type.Converter.Unit.Test.Model
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