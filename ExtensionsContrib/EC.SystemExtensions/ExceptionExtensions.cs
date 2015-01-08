using System;
using System.Text;

namespace EC.SystemExtensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Retornar todas as mensagens de erro concatenadas
        /// </summary>
        /// <param name="ex">Início da exceção.</param>
        /// <returns></returns>
        public static String ConcatAll(this Exception ex)
        {
            return ConcatAll(ex, " >>> ");
        }

        /// <summary>
        /// Retornar todas as mensagens de erro concatenadas
        /// </summary>
        /// <param name="ex">Início da exceção.</param>
        /// <returns></returns>
        public static String ConcatAll(this Exception ex, String separator)
        {
            if (ex == null)
                throw new ArgumentNullException("ex");

            var sep = separator ?? String.Empty;
            var result = new StringBuilder();

            while (ex != null)
            {
                result.Append(ex.Message);

                if (ex.InnerException != null)
                    result.Append(sep);

                ex = ex.InnerException;
            }

            return result.ToString();
        }
    }
}