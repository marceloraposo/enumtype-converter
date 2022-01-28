using System;
using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;

namespace EnumType.Converter
{
    public class DescriptionEnumConverter<T> : JsonConverter<T>
    {
        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            char charValue = (char)(int)Enum.Parse(typeof(T), value.ToString());
            writer.WriteValue($"{charValue}");
        }

        public override T ReadJson(JsonReader reader, System.Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string stringValue = (string)reader.Value;

            foreach (FieldInfo fieldInfo in typeof(T).GetFields())
            {
                if (fieldInfo.GetCustomAttribute<DescriptionAttribute>() is DescriptionAttribute attribute && attribute.Description == stringValue)
                    return (T)fieldInfo.GetRawConstantValue();
            }

            throw new Exception($"Enum '{typeof(T)}' doesn't have a member with a [DescriptionAttribute('{stringValue}')]!");            
        }
    }
}