using System.Reflection;

namespace DbAccess.Utils
{
    public static class AttributeUtils
    {
        public static bool HasAttribute<T>(this PropertyInfo prop) where T : Attribute
        {
            return Attribute.IsDefined(prop, typeof(T));
        }

        public static T? GetAttribute<T>(this PropertyInfo prop, bool inherit = false) where T : Attribute
        {
            var attributes = (T[])prop.GetCustomAttributes(typeof(T), inherit);
            if (attributes.Length < 1) return null;
            return attributes[0];
        }
    }
}
