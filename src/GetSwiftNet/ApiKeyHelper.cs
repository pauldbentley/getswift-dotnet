namespace GetSwiftNet
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Provides helper methods for working with API keys.
    /// </summary>
    internal static class ApiKeyHelper
    {
        /// <summary>
        /// The name of the property which should be used by classes defining an API key.
        /// </summary>
        public const string ApiKeyPropertyName = "ApiKey";

        /// <summary>
        /// If the given object has a <see cref="Nullable{Guid}"/> property called ApiKey which is null, the given API key will be allocated.
        /// </summary>
        /// <param name="value">The object to have the API key allocated.</param>
        /// <param name="apiKey">The API key to apply to the object if it isn't already allocated.</param>
        public static void AllocateApiKey(object value, Guid? apiKey)
        {
            if (value == null || !apiKey.HasValue)
            {
                return;
            }

            var property = GetApiKeyProperty(value);
            SetApiKeyProperty(property, value, apiKey);
        }

        private static PropertyInfo GetApiKeyProperty(object value)
        {
            // find the ApiKey property on the value
            var property = value
                .GetType()
                .GetRuntimeProperty(ApiKeyPropertyName);

            return property.PropertyType == typeof(Guid?)
                ? property
                : null;
        }

        private static void SetApiKeyProperty(PropertyInfo property, object value, Guid? apiKey)
        {
            // there is a property
            if (property != null)
            {
                // if it doesn't have a value we set it
                if (property.GetValue(value) == null)
                {
                    property.SetValue(value, apiKey);
                }
            }
        }
    }
}
