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
    }
}