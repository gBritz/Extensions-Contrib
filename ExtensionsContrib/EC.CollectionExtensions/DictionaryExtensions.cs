using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace EC.CollectionExtensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// <para>Resgatar dado de modo seguro.</para>
        /// <para>Caso não encontre o valor, será assumido o valor default de seu tipo.</para>
        /// </summary>
        /// <typeparam name="T">Tipo a ser resgatado.</typeparam>
        /// <param name="dic"></param>
        /// <param name="key">Chave onde está armazenado o dado.</param>
        /// <returns>Valor encontrado ou o tipo default.</returns>
        public static T GetSafe<T>(this IDictionary dic, String key)
        {
            return GetSafe(dic, key, default(T));
        }

        /// <summary>
        /// <para>Resgatar dado de modo seguro.</para>
        /// <para>Caso não encontre o valor, será assumido o valor default de seu tipo.</para>
        /// </summary>
        /// <typeparam name="T">Tipo a ser resgatado.</typeparam>
        /// <param name="dic"></param>
        /// <param name="key">Chave onde está armazenado o dado.</param>
        /// <param name="defaultValue">Valor default caso ainda não esteja setado na session.</param>
        /// <returns>Valor encontrado ou o tipo default.</returns>
        public static T GetSafe<T>(this IDictionary dic, String key, T defaultValue)
        {
            if (dic == null)
                throw new ArgumentNullException("dic");

            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");

            var result = defaultValue;
            if (dic.Contains(key))
                result = (T)dic[key];

            return result;
        }

        public static IDictionary<String, Object> AsDictionary(this Object source)
        {
            var result = new Dictionary<String, Object>();

            if (source != null)
            {
                var properties = TypeDescriptor.GetProperties(source);
                for (var i = 0; i < properties.Count; i++)
                {
                    var property = properties[i];
                    result.Add(property.Name, property.GetValue(source));
                }
            }

            return result;
        }
    }
}