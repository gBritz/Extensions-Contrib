using System;
using System.Collections;

namespace EC.CollectionExtensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Indicar se a coleção está nula ou vazia.
        /// </summary>
        /// <typeparam name="T">Tipo da coleção.</typeparam>
        /// <param name="input">Coleção de valores.</param>
        /// <returns>True caso a coleção esteja nula ou vazia.</returns>
        /*public static Boolean IsEmpty<T>(this ICollection<T> input)
        {
            return input == null || input.Count == 0;
        }*/

        /// <summary>
        /// Indicar se a coleção está nula ou vazia.
        /// </summary>
        /// <param name="input">Coleção de valores.</param>
        /// <returns>True caso a coleção esteja nula ou vazia.</returns>
        public static Boolean IsEmpty(this ICollection input)
        {
            return input == null || input.Count == 0;
        }
    }
}