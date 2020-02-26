using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename1 = @"C:\Users\oleg.suprun\source\INTERN ASSIGNMENTS\14. FilesAndStreams\Filesync\Dir1";
            string filename2 = @"C:\Users\oleg.suprun\source\INTERN ASSIGNMENTS\14. FilesAndStreams\Filesync\Dir2";
            //EmptryFiles(filename1, filename2);

            var dirinfo = new DirectoryInfo(filename1);
            
            //string[] directories1 = Directory.GetDirectories(filename1, "*" ,SearchOption.AllDirectories);
            //string[] files1 = Directory.GetFiles(filename1, "*", SearchOption.AllDirectories);

            //string[] directories2 = Directory.GetDirectories(filename2, "*", SearchOption.AllDirectories);
            //string[] files2 = Directory.GetFiles(filename2, "*", SearchOption.AllDirectories);
            

            SyncFolders(filename1, filename2);
            SyncFiles(filename1,filename2);
           

        }

        //public static void EmptryFiles(string dir, string dir2)
        //{
        //    DirectoryInfo dirinfo = new DirectoryInfo(dir);
        //    DirectoryInfo dirinfo2 = new DirectoryInfo(dir2);

        //    if (dirinfo.Exists)
        //        dirinfo.Delete(true);
        //    dirinfo.Create();

        //    if (dirinfo2.Exists)
        //        dirinfo2.Delete(true);
        //    dirinfo2.Create();
        //    Console.WriteLine("Deleted");
        //}

        public static void SyncFolders(string dir, string dir2)
        {
            string[] directories1 = Directory.GetDirectories(dir, "*", SearchOption.AllDirectories);
            foreach (var direcoryfromdir1 in directories1)
            {
                var directoryfromdir2 = direcoryfromdir1.Replace("Dir1", "Dir2");
                if (!Directory.Exists(directoryfromdir2))
                {
                    Directory.CreateDirectory(directoryfromdir2);
                    Console.WriteLine(directoryfromdir2 + " Folder  in Dir2 Created");
                }
            }


            string[] directories2 = Directory.GetDirectories(dir2, "*", SearchOption.AllDirectories);
            foreach (var direcoryfromdir2 in directories2)
            {
                var direcoryfromdir1 = direcoryfromdir2.Replace("Dir2", "Dir1");
              
                if (!Directory.Exists(direcoryfromdir1))
                {
                    Directory.Delete(direcoryfromdir2,true);
                    Console.WriteLine(direcoryfromdir1 + " Folder  in Dir2 Deleted");
                }
            }

        }

        public static void SyncFiles(string dir, string dir2)
        {
            string[] files1 = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);
            foreach (var file in files1)
            {
                var filefromdir2 = file.Replace("Dir1", "Dir2");
                if (!File.Exists(filefromdir2))
                {
                    CopyFile(file, filefromdir2);
                    Console.WriteLine(filefromdir2 + " File  in Dir2 Created");
                }
                else
                {               
                    if(!CompareFiles(filefromdir2, file))
                    {
                       CopyFile(file, filefromdir2);
                        Console.WriteLine(filefromdir2 + " File  in Dir2 Replaced");
                    }        
                }
            }


            string[] files2 = Directory.GetFiles(dir2, "*", SearchOption.AllDirectories);
            foreach (var filedir2 in files2)
            {
                var filefromdir1 = filedir2.Replace("Dir2", "Dir1");
                if (!File.Exists(filefromdir1))
                {
                    File.Delete(filedir2);
                    Console.WriteLine(filedir2 + " File  in Dir2 Deleted");
                }
            }
        }

        public static bool CompareFiles(string filename , string filename2)
        {
            var finfo = new FileInfo(filename);
            var finfo2 = new FileInfo(filename2);
            
            return (Encoding.Default.GetString(GetHashSha256(filename)) == Encoding.Default.GetString(GetHashSha256(filename2)));            

            // Compute the file's hash.
        }
        public static byte[] GetHashSha256(string filename)
        {
            SHA256 Sha256 = SHA256.Create();
            using (FileStream stream = File.OpenRead(filename))
            {
                //Console.WriteLine(Encoding.Default.GetString(Sha256.ComputeHash(stream)));
               return Sha256.ComputeHash(stream);
            }
        }



        public static async void CopyFile(string filepath1, string filepath2)
        {
            FileStream fs = File.OpenRead(filepath1);
            int len = (int)fs.Length;
            byte[] buffer = new byte[len];

            int sum = 0, count;
            try
            {
                while ((count = fs.Read(buffer, sum, len - sum)) > 0)
                {
                    sum += count;
                }

            }
            catch (Exception)
            {

                
            }
            finally
            {
                fs.Close();
            }

            //var fs2 =  File.Create(filepath2);
            

     
           await File.WriteAllBytesAsync(filepath2, buffer);
                //await fs2.WriteAsync(buffer);
        
   
            
        }

        
    }
}
