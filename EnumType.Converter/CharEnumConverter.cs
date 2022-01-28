using System;
using Newtonsoft.Json;

namespace EnumType.Converter
{
    public class CharEnumConverter<T> : JsonConverter<T>
    {
        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            char charValue = (char)(int)Enum.Parse(typeof(T), value.ToString());
            writer.WriteValue($"{charValue}");
        }

        public override T ReadJson(JsonReader reader, System.Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string stringValue = (string)reader.Value;
            char charValue = stringValue[0];
            int intValue = (int)charValue;
            string intValueString = $"{intValue}";

            if (Enum.IsDefined(typeof(T), intValue))
            {
                T result = (T)Enum.Parse(typeof(T), intValueString);
                return result;
            }
            else
            {
                throw new Exception("Char value [" + charValue + "] not exist in Enum [" + typeof(T).Name + "]");
            }
        }
    }
}