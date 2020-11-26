using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lab4_Backup.ClearAlgorythm;

namespace Lab4_Backup
{
    class Program
    {
        static void Case1()
        {
            string[] filePaths = { @"Files\FileIn.txt", @"Files\Input.txt" };

            TimeManager.Instance.CurrentDate = new DateTime(2020, 10, 10, 12, 0, 0);
            Backup backup = new Backup(filePaths);
            FullPoint restorePoint1 = (FullPoint)backup.CreateRestore(true);
            Console.WriteLine($"Expected 2 files. Actual {restorePoint1.FileBackupInfos.Count} files");

            TimeManager.Instance.CurrentDate = new DateTime(2020, 10, 12, 12, 0, 0);
            FullPoint restorePoint2 = (FullPoint)backup.CreateRestore(true);

            Console.WriteLine($"Before clear {backup.RestorePoints.Count}");

            ClearPointByCount clearPointByCount = new ClearPointByCount(1);
            backup.Clear(clearPointByCount);

            Console.WriteLine($"After clear {backup.RestorePoints.Count}");
        }

        static void Case2()
        {
            string[] filePaths = { @"Files\FileIn.txt", @"Files\Input.txt" };

            TimeManager.Instance.CurrentDate = new DateTime(2020, 10, 10, 12, 0, 0);
            Backup backup = new Backup(filePaths);
            FullPoint restorePoint1 = (FullPoint)backup.CreateRestore(true);

            TimeManager.Instance.CurrentDate = new DateTime(2020, 10, 12, 12, 0, 0);
            FullPoint restorePoint2 = (FullPoint)backup.CreateRestore(true);

            Console.WriteLine($"Count points = {backup.RestorePoints.Count}, Size = {backup.Size}");

            IClearPoint clearPoint = new ClearPointBySize(25);
            backup.Clear(clearPoint);

            Console.WriteLine($"Count points = {backup.RestorePoints.Count}, Size = {backup.Size}");
        }

        static void Main(string[] args)
        {
            //Case1();
            Case2();

            Console.ReadLine();
        }
    }
}
