using System;
using Xunit;
using FluentAssertions;
using EnumType.Converter.Unit.Test.Model;
using EnumType.Converter.Unit.Test.Enum;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnumType.Converter.Unit.Test
{
    public class CustomEnumConverterTest
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        public CustomEnumConverterTest()
        {
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                WriteIndented = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
                Converters = { new CustomEnumConverter<MyCustomEnum>() },
            };
        }

        [Fact]
        public void ShouldReturnMyType()
        {
            var myCustomModel = new MyCustomModel()
            {
                myCustomField = MyCustomEnum.Nao
            };

            var resultSerialize = JsonSerializer.Serialize(myCustomModel, _jsonSerializerOptions);

            var result = JsonSerializer.Deserialize<MyCustomModel>("{\"myCustomField\": \"Não\" }", _jsonSerializerOptions);

            Assert.True(result.myCustomField == MyCustomEnum.Nao);
        }
    }
}