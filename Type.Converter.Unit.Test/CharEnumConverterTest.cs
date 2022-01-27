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
    public class CharEnumConverterTest
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        public CharEnumConverterTest()
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
            };

            _jsonSerializerSettings.Converters.Add(new CharEnumConverter<MyEnum>());
        }

        [Fact]
        public void ShouldReturnMyType()
        {
            var result = JsonConvert.DeserializeObject<MyModel>("{\"my_field\":\"N\"}", _jsonSerializerSettings);
        }
    }
}