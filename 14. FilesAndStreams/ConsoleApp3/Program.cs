using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {

            string filename1 = @"C:\Users\oleg.suprun\source\INTERN ASSIGNMENTS\14. FilesAndStreams\Filesync\Dir1";
            string filename2 = @"C:\Users\oleg.suprun\source\INTERN ASSIGNMENTS\14. FilesAndStreams\Filesync\Dir2";

            
            

            DirectoryInfo dirinfo = new DirectoryInfo(filename1);
            DirectoryInfo dirinfo2 = new DirectoryInfo(filename2);

            if (dirinfo.Exists)
                dirinfo.Delete(true);
            dirinfo.Create();

            if(dirinfo2.Exists)
                dirinfo2.Delete(true);
            dirinfo2.Create();
            Console.WriteLine("Deleted");
            Thread.Sleep(1000);

                  
      
            var watchThisFolder = new FileSystemWatcher(filename1);
            watchThisFolder.IncludeSubdirectories = true;                   
            //watchThisFolder.Changed += new FileSystemEventHandler(OnFolderChange);
            watchThisFolder.Renamed += new RenamedEventHandler(OnFolderRenamed);
            watchThisFolder.Deleted += new FileSystemEventHandler(OnFolderDeleted);
            watchThisFolder.Created += new FileSystemEventHandler(OnFolderCreated);
            watchThisFolder.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.DirectoryName;
            watchThisFolder.EnableRaisingEvents = true;

            var watchThisFolderFiles = new FileSystemWatcher(filename1);
            watchThisFolderFiles.Changed += OnFileChange;
            watchThisFolderFiles.Renamed += new RenamedEventHandler(OnFolderRenamed);
            watchThisFolderFiles.Deleted += new FileSystemEventHandler(OnFileDeleted);
            watchThisFolderFiles.Created += OnFileCreated;
            watchThisFolderFiles.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
            watchThisFolderFiles.EnableRaisingEvents = true;

            Console.WriteLine("Press 'q' to quit");
            while (Console.ReadLine() != "q") 
            {

            }                  
        }
        public static void OnFolderCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.FullPath} Created");
            DirectoryInfo dirinfo = new DirectoryInfo(e.FullPath.Replace("Dir1", "Dir2"));
            dirinfo.Create();
        }
        //public static void OnFolderChange(object sender, FileSystemEventArgs e)
        //{
        //    Console.WriteLine($"{e.FullPath} changed!");
        //}        
        public static void OnFolderRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"{e.OldFullPath} Renamed to {e.FullPath}");
            DirectoryInfo dirinfo = new DirectoryInfo(e.OldFullPath.Replace("Dir1", "Dir2"));
            dirinfo.MoveTo(e.FullPath.Replace("Dir1", "Dir2"));
        }        
 
        public static void OnFolderDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.FullPath} Deleted to");
        }



        public static void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.FullPath} File Created");
            FileInfo fileinfo = new FileInfo(e.FullPath.Replace("Dir1", "Dir2"));
            fileinfo.Create();
        }

        public static void OnFileChange(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.FullPath} File changed!");
        }        
        public static void OnFileRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"{e.OldFullPath} File Renamed to {e.FullPath}");
        }        
 
        public static void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.FullPath} File Deleted to");
        }

   
        
    }
}
