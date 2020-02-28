using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp2
{
    class DBStorage : IDisposable
    {
        private readonly FileStream _textdb;
        public DBStorage()
        {
            string path = @"C:\Users\oleg.suprun\source\INTERN ASSIGNMENTS\16.Encoding Disposal GarbageCollection\textdb.txt";
            _textdb = File.OpenWrite(path);
        }

        public void WriteToDb(Advert ad)
        {
            _textdb.Seek(_textdb.Length, 0);                        
            _textdb.Write(Encoding.UTF8.GetBytes(ad.ToString()));
        }

        public void Dispose()
        {
            Console.WriteLine("****************************************Dispose");
            _textdb.Close();
        }

        ~DBStorage()
        {
            Console.WriteLine("*****************************************Finalizer");
            _textdb.Close();
        }
    }
}
