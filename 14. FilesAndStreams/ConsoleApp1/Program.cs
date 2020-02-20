using System;
using System.IO;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveChecker.CheckDrives();
            FileInfo fs = new FileInfo(@"C:\Users\oleg.suprun\source\INTERN ASSIGNMENTS\14. FilesAndStreams\lorem.txt");
            DirectoryInfo fs2 = new DirectoryInfo(@"C:\Users\oleg.suprun\source\INTERN ASSIGNMENTS\");
            
            Console.WriteLine(fs.Name);
            Console.WriteLine(fs.CreationTime);
            Console.WriteLine(fs.Attributes);
            Console.WriteLine(fs.LastAccessTime);

            FileSystemWatcher fw = new FileSystemWatcher();
            ////fw.Path += @"C:\Users\oleg.suprun\source\INTERN ASSIGNMENTS\14. FilesAndStreams\lorem.txt";
            //var folders  = fs2.GetDirectories();
            //foreach (var item in folders)
            //{
            //    Console.WriteLine(item);
            //}
            var files2 = fs2.GetDirectories("*.*", SearchOption.AllDirectories);
            foreach (var item in files2)
            {
                Console.WriteLine(item);
            }


            
            //string[] files = Directory.GetFiles(@"C:\Users\oleg.suprun\source\INTERN ASSIGNMENTS\14. FilesAndStreams\", "*.*",SearchOption.AllDirectories);

            //foreach (var item in files)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
