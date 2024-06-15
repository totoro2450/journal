using System.Text.Json;
using Newtonsoft.Json;

namespace Journal.Shared.Helpers
{
    public static class JsonHelper
    {
        public static object? FromJsonOrNull(string json, Type targetType, bool saveTypes = false)
        {
            if (string.IsNullOrEmpty(json)) return null;
            try
            {
                if (saveTypes == false)
                {
                    return JsonConvert.DeserializeObject(json, targetType);
                }
                
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    TypeNameHandling = saveTypes ? TypeNameHandling.All : TypeNameHandling.None,
                };

                return JsonConvert.DeserializeObject(json, settings);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string? ToJsonOrNull(object? obj, bool saveTypes = false)
        {
            if (obj == null) return null;

            try
            {
                var settings = JsonHelperSerializerSettings.Standard(saveTypes);
                return JsonConvert.SerializeObject(obj, settings);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static object FromJson(string json, Type targetType)
        {
            return JsonConvert.DeserializeObject(json, targetType)!;
        }

        public static string ToJsonIndented(object item)
        {
            var serializerOptions = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = System.Text.Json.JsonSerializer.Serialize(item, serializerOptions);
            return jsonString;
        }

        public static string ToJson(object item, bool saveTypes = false)
        {
            var serializerSettings = JsonHelperSerializerSettings.Standard(saveTypes);
            return JsonConvert.SerializeObject(item, serializerSettings);
        }
    }

    public static class JsonHelperSerializerSettings
    {
        public static JsonSerializerSettings Standard(bool saveTypes = false)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = saveTypes ? TypeNameHandling.All : TypeNameHandling.None,
            };

            return settings;
        }
    }
}
