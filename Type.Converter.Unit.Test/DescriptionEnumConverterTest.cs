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
    public class DescriptionEnumConverterTest
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        public DescriptionEnumConverterTest()
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
            };

            _jsonSerializerSettings.Converters.Add(new DescriptionEnumConverter<MyEnumDescription>());
        }

        [Fact]
        public void ShouldReturnMyType()
        {
            var result = JsonConvert.DeserializeObject<MyModel>("{\"my_description_field\": \"Não\" }", _jsonSerializerSettings);
        }
    }
}