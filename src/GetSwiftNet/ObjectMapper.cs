namespace GetSwiftNet
{
    using Newtonsoft.Json;

    /// <summary>
    /// Provides helper functions to map JSON to objects.
    /// </summary>
    /// <typeparam name="T">The type of object to map</typeparam>
    internal static class ObjectMapper<T>
    {
        /// <summary>
        /// Creates a object of type T from the given JSON string.
        /// </summary>
        /// <param name="json">The JSON string to convert.</param>
        /// <returns>An object populated from the JSON.</returns>
        public static T MapFromJson(string json)
        {
            return MapFromJson(json, null);
        }

        /// <summary>
        /// Creates an object of type T from the JSON defined in the service response.
        /// The response is allocated to the object if there is a relevant property.
        /// </summary>
        /// <param name="response">The response from the service server.</param>
        /// <returns>An object populated from the JSON in the service response.</returns>
        public static T MapFromJson(ServiceResponse response)
        {
            return MapFromJson(response?.Content, response);
        }

        /// <summary>
        /// Creates an object of type T from the given JSON string.
        /// The response is allocated to the object if there is a relevant property.
        /// </summary>
        /// <param name="json">The JSON string to convert.</param>
        /// <param name="response">The response from the service server.</param>
        /// <returns>An object populated from the JSON with the service response allocated.</returns>
        public static T MapFromJson(string json, ServiceResponse response)
        {
            var type = typeof(T);
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ApiList<>))
            {
                // The JSON will be an array of the object
                // we want to add in the "data" element
                // so that it is deserialized correctly
                json = "{ \"data\": " + json + " }";
            }

            var model = JsonConvert.DeserializeObject<T>(json, GetSwiftConfiguration.SerializerSettings);

            // save the response to the result for reference
            if (response != null)
            {
                response.AllocateResponse(model);
            }

            return model;
        }
    }
}
