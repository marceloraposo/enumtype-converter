using System;
using Xunit;
using FluentAssertions;
using Type.Converter.Unit.Test.Model;
using Type.Converter.Unit.Test.Enum;
using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json.Serialization;

namespace Type.Converter.Unit.Test
{
    public class IntegerEnumConverterTest
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        public IntegerEnumConverterTest()
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
            };

            _jsonSerializerSettings.Converters.Add(new CharEnumConverter<MyEnumInteger>());
        }

        [Fact]
        public void ShouldReturnMyType()
        {
            var result = JsonConvert.DeserializeObject<MyModel>("{\"my_integer_field\": 1 }", _jsonSerializerSettings);
        }
    }
}