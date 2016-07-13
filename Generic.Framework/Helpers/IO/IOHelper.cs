using System;
using System.IO;
using System.Text;

namespace Generic.Framework.Helpers.IO
{
    public static class IOHelper
    {
        public static string ReadStringContainingFile(FileInfo stringContainingFile)
        {
            var fileContents = new StringBuilder();
            
            using (StreamReader sr = File.OpenText(stringContainingFile.FullName))
            {
                string fileLine;
                while ((fileLine = sr.ReadLine()) != null)
                {
                    fileContents.AppendLine(fileLine);
                }
            }

            return fileContents.ToString();
        }

        public static void WriteStringContainingFile(FileInfo stringContainingFile, string fileContents)
        {
            using (var outfile = new StreamWriter(stringContainingFile.FullName))
            {
                outfile.Write(fileContents);
            }
        }
    }
}
