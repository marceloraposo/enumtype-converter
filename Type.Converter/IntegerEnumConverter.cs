using System;
using Newtonsoft.Json;

namespace Type.Converter
{
    public class IntegerEnumConverter<T> : JsonConverter<T>
    {
        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            int intValue = (int)Enum.Parse(typeof(T), value.ToString());
            writer.WriteValue($"{intValue}");
        }

        public override T ReadJson(JsonReader reader, System.Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string stringValue = $"{reader.Value}";
            int intValue = Convert.ToInt32(stringValue); 
            string intValueString = $"{intValue}";

            if (Enum.IsDefined(typeof(T), intValue))
            {
                T result = (T)Enum.Parse(typeof(T), intValueString);
                return result;
            }
            else
            {
                throw new Exception("Char value [" + intValue + "] not exist in Enum [" + typeof(T).Name + "]");
            }
        }
    }
}