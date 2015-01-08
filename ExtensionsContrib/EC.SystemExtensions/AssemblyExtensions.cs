using System;
using System.IO;
using System.Reflection;

namespace EC.SystemExtensions
{
    public static class AssemblyExtensions
    {
        public static String GetResourceContentIn(this Assembly assembly, String fileName, params String[] folders)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }

            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            var hasFolders = folders != null && folders.Length > 0;
            var parts = new String[2 + (hasFolders ? folders.Length : 0)];
            parts[0] = assembly.GetName().Name;
            if (hasFolders)
            {
                Array.Copy(folders, 0, parts, 1, folders.Length);
            }
            parts[parts.Length - 1] = fileName;

            var resourceName = String.Join(".", parts);
            var content = String.Empty;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName)) // TODO: pode ser null caso não encontre.
            using (StreamReader reader = new StreamReader(stream))
            {
                content = reader.ReadToEnd();
            }

            return content;
        }
    }
}