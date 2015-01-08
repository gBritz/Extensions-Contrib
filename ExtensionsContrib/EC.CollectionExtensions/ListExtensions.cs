using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EC.CollectionExtensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Converter uma listagem para uma matriz de valores.
        /// <para>Caso a listagem seja nula ou vazia, será criado uma matriz vazia.</para>
        /// </summary>
        /// <typeparam name="T">Tipo definido para retorno.</typeparam>
        /// <param name="list">Listagem de valores.</param>
        /// <returns>Matriz de valores.</returns>
        public static T[][] ToMatriz<T>(this IList list)
        {
            if (list.IsEmpty())
                return new T[0][];

            IEnumerable<T[]> res = null;

            if (list[0] is Array)
                res = list.OfType<T[]>();
            else
                res = list.OfType<T>().Select(r => new T[1] { r });

            return res.ToArray();
        }
    }
}