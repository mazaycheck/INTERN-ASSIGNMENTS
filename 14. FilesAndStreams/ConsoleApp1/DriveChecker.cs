using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp1
{
    class DriveChecker
    {

        public static void CheckDrives()
        {
            DriveInfo[] myDrives = DriveInfo.GetDrives();
            foreach (var item in myDrives)
            {
                try
                {
                    DriveInfo dr = new DriveInfo(item.Name);
                    Console.WriteLine($"Free Space on {item} {dr.AvailableFreeSpace / 1024 / 1024 / 1024} GB");
                }
                catch (Exception)
                {

                    Console.WriteLine($"Could not detect free space on {item.Name}");
                }

            }

            Console.WriteLine();

        }
    }
}
