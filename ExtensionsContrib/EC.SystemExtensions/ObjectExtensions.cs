using System;
using System.Reflection;

namespace EC.SystemExtensions
{
    public static class ObjectExtensions
    {
        private readonly static MethodInfo method = typeof(Object).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);

        public static T CreateShallowCopy<T>(this T obj) where T : class
        {
            return obj == null ? null : (T)method.Invoke(obj, null);
        }
    }
}