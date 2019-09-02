using System.Reflection;

namespace GetNonPublicValueByReflection
{
    public class GetNonPublicValue
    {
        public static object GetPropertyValue<T>(T obj, string name)
        {
            var type_ = obj.GetType();
            var pi_ = type_.GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var value_ = pi_.GetValue(obj);
            return value_;
        }

        public static object GetFieldValue<T>(T obj, string field)
        {
            var type_ = obj.GetType();
            var fi_ = type_.GetField(field, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var value_ = fi_.GetValue(obj);
            return value_;
        }
    }
}
