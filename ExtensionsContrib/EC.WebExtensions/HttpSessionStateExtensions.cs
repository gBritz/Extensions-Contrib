using EC.SystemExtensions;
using System;
using System.Web.SessionState;

namespace EC.WebExtensions
{
    public static class HttpSessionStateExtensions
    {
        public static T GetSafe<T>(this HttpSessionState session, String key)
        {
            return GetSafe<T>(session, key, default(T));
        }

        public static T GetSafe<T>(this HttpSessionState session, String key, T defaultValue)
        {
            if (session == null)
                throw new ArgumentNullException("session");
            if (key == null)
                throw new ArgumentNullException("key");

            var value = session[key];
            return value == null ? defaultValue : (T)value;
        }

        public static T[] GetSafeArray<T>(this HttpSessionState session, String key, Boolean emptyCollection)
        {
            if (session == null)
                throw new ArgumentNullException("session");
            if (key == null)
                throw new ArgumentNullException("key");

            var value = session[key];
            return value == null ? emptyCollection ? Array<T>.Empty() : null : (T[])value;
        }

        public static void SetSafe<T>(this HttpSessionState session, String key, T value)
        {
            if (session == null)
                throw new ArgumentNullException("session");
            if (key == null)
                throw new ArgumentNullException("key");

            if (value == null || value.Equals(default(T)))
                session.Remove(key);
            else
                session.Add(key, value);
        }
    }
}