namespace GetSwiftNet
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;

    /// <summary>
    /// Converts a object which defines a value which need converting to a string.
    /// </summary>
    internal class StringValueTypeConverter : JsonConverter
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="JsonConverter"/> can read JSON.
        /// </summary>
        public override bool CanRead => false;

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>true if this instance can convert the specified object type; otherwise, false.</returns>
        public override bool CanConvert(Type objectType) => true;

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            var objectType = value.GetType();
            var stringOperator = GetStringOperator(objectType);

            if (stringOperator == null)
            {
                throw new JsonSerializationException($"Supplied value of type {objectType} does not have an implicit operator to {typeof(string).FullName}.");
            }

            string text = GetValueAsString(value, stringOperator);
            writer.WriteValue(text);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        private static MethodInfo GetStringOperator(Type objectType)
        {
            // We get the implicit operator which returns a string
            var op = objectType
                .GetMethods()
                .Where(m => m.Name == "op_Implicit")
                .Where(m => m.ReturnType == typeof(string))
                .FirstOrDefault();

            if (op != null)
            {
                var p = op.GetParameters();

                // operators must have 1 parameter
                // we check it is the type of the incoming value
                if (p.Length == 1 && p[0].ParameterType == objectType)
                {
                    return op;
                }
            }

            return null;
        }

        private static string GetValueAsString(object value, MethodInfo stringOperator)
        {
            string converted = (string)stringOperator.Invoke(null, new[] { value });
            return converted;
        }
    }
}
