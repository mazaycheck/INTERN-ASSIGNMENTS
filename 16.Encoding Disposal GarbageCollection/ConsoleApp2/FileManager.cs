using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp2
{
    class FileManager
    {

        public static bool CreateFolder(string filename)
        {
            if (!Directory.Exists(filename)) {
                Directory.CreateDirectory(filename);
                return true;
            }
            return false;

        }

        public static bool CreateFile(string filename)
        {
            if (!File.Exists(filename)) {
                using (File.Create(filename))
                {
                    return true;
                }

            }
            return false;
        }


        public static void DeleteFile(string filename) {
            if(File.Exists(filename))
                File.Delete(filename);
        }

        public static void AppendData(string filename, byte[] data)
        {
            using (FileStream fs = File.OpenWrite(filename))
            {
                fs.Seek(fs.Length,SeekOrigin.Begin);
                fs.Write(data);
            }
        }

        public static void WriteToFile(string text, string filename, Encoding encoding)
        {
            byte[] data = encoding.GetBytes(text);
            if (!File.Exists(filename))
            {
                FileManager.CreateFile(filename); 
                File.SetAttributes(filename, FileAttributes.Normal);

            }

            FileManager.AppendData(filename, data);            
        }

        public static byte[] ReadDataFromFile(string filename)
        {
            
            if (File.Exists(filename))
            {
                byte[] buffer;
                int sum = 0, count = 0;
                using (FileStream fs = File.OpenRead(filename))
                {
                    buffer =  new byte[fs.Length];
                    while ((count = fs.Read(buffer, sum, (int)fs.Length - sum)) > 0)
                    {
                        sum += count;
                    }
                }
                return buffer;
            }
            return null;
        }

        public static byte[] ConvertEncoding(byte[] data, Encoding encodingFrom, Encoding encodingTo)
        {
            return Encoding.Convert(encodingFrom, encodingTo, data);
        }

        public static string ReadAndConvertEncoding(string filename , Encoding encodingFrom, Encoding encodingTo)
        {
            byte[] sourceBytes = FileManager.ReadDataFromFile(filename);
            byte[] convertedBytes = FileManager.ConvertEncoding(sourceBytes, encodingFrom, encodingTo);
            return encodingTo.GetString(convertedBytes);
        }









    }
}
