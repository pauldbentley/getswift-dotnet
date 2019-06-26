namespace GetSwiftNet.Infrastructure
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Restfully;

    /// <summary>
    /// A serialization service using Newtonsoft.Json.
    /// </summary>
    public class GetSwiftSerializer : ISerializer
    {
        private JsonSerializerSettings SerializerSettings { get; } = BuildSerializerSettings();

        /// <summary>
        /// Serializes a value to a JSON string.
        /// </summary>
        /// <param name="value">The value to serialize.</param>
        /// <returns>A JSON string representation of the given value.</returns>
        public string Serialize(object value) => JsonConvert.SerializeObject(value, SerializerSettings);

        /// <summary>
        /// Deserializes a JSON string to an object.
        /// </summary>
        /// <typeparam name="T">The type of value to deserialize.</typeparam>
        /// <param name="value">A JSON string to deserialize.</param>
        /// <returns>An object deserialized from the JSON string.</returns>
        public T Deserialize<T>(string value) => JsonConvert.DeserializeObject<T>(value, SerializerSettings);

        private static JsonSerializerSettings BuildSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },
                DateParseHandling = DateParseHandling.DateTime,
                NullValueHandling = NullValueHandling.Ignore,
            };
        }
    }
}