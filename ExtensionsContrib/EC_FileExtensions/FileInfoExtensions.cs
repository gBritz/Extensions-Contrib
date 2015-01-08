using System;
using System.IO;
using System.Runtime.InteropServices;

namespace EC.FileExtensions
{
    /// <summary>
    /// http://stackoverflow.com/questions/876473/is-there-a-way-to-check-if-a-file-is-in-use
    /// </summary>
    public static class FileInfoExtensions
    {
        private const Int32 ERROR_SHARING_VIOLATION = 32;
        private const Int32 ERROR_LOCK_VIOLATION = 33;

        public static Boolean IsFileLocked(this String filePath)
        {
            if (String.IsNullOrEmpty(filePath))
                throw filePath == null ? new ArgumentNullException("filePath") : new ArgumentException("Parameter is empty.", "filePath");

            var info = new FileInfo(filePath);
            return info.IsLocked();
        }

        public static Boolean IsLocked(this FileInfo file)
        {
            if (file == null)
                throw new ArgumentNullException("file");

            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
            catch (IOException ex)
            {
                return IsFileLocked(ex);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private static Boolean IsFileLocked(Exception exception)
        {
            var errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
            return errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION;
        }

        /// <summary>
        /// Indica se encontra pasta pelo nome navegando para cima.
        /// <para>Caso não encontre, irá subir na navegação de acordo com o número de tentativas definido.</para>
        /// </summary>
        /// <param name="startFolder">Pasta inicial para começar a busca.</param>
        /// <param name="searchFolder">Nome da pasta a ser encontrada.</param>
        /// <param name="attempts">Número de tentativas que irá subir na navegação.</param>
        /// <param name="fullPath">Caminho completo da pasta, caso encontre.</param>
        /// <returns>Retorna True caso encontre a pasta.</returns>
        public static Boolean TrySearchDirectoryUpwards(String startFolder, String searchFolder, UInt16 attempts, out String fullPath)
        {
            if (String.IsNullOrEmpty(startFolder))
            {
                throw new ArgumentNullException("startFolder");
            }

            if (String.IsNullOrEmpty(searchFolder))
            {
                throw new ArgumentNullException("searchFolder");
            }

            var directory = new DirectoryInfo(startFolder);
            var searchFolderPath = String.Empty;
            var countAttempts = 1;
            fullPath = null;

            do
            {
                searchFolderPath = Path.Combine(directory.FullName, searchFolder);

                if (Directory.Exists(searchFolderPath))
                {
                    fullPath = searchFolderPath;
                }

                directory = directory.Parent;
                countAttempts++;
            }
            while (fullPath == null && countAttempts <= attempts);

            return !String.IsNullOrEmpty(fullPath);
        }
    }
}