using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:\Users\oleg.suprun\source\INTERN ASSIGNMENTS\14. FilesAndStreams\lorem.txt";
            //byte[] data = OpenWithFileStream(filename);
            OpenWithStreamReader(filename);

        }

        public static void OpenWithStreamReader(string filename)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(filename);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(sr != null)
                    sr.Close();
            }
            
        }



        public static byte[] OpenWithFileStream(string filename)
        {

            
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            int length = (int)fs.Length;
            byte[] buffer = new byte[length];
            try
            {
                int count;
                int sum = 0;
                while ((count = fs.Read(buffer, sum, length - sum)) > 0)
                {
                    sum += count;
                }
            }
            catch (Exception)
            {


            }
            finally { fs.Close(); }

            foreach (var item in buffer)
            {
                Console.Write((char)item);
            }
            return buffer;
        }

    }
}
