using Newtonsoft.Json;

namespace coreMvcFundamentals.Helpers
{
    public static class sessionHelper
    {
        public static void setObjectAsJson(this ISession session, string key, object value) 
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T? getObjectFromJson<T>(this ISession session, string key) 
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
