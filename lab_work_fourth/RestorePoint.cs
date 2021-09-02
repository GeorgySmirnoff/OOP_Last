using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab4_Backup
{
    public abstract class RestorePoint
    {
        public abstract long Size { get; }
        public DateTime CreateDate { get; }

        public RestorePoint(List<string> filePaths)
        {
            Execute(filePaths);

            CreateDate = TimeManager.Instance.CurrentDate;
        }

        protected abstract void Execute(List<string> filePaths);

        protected FileBackupInfo CreateFileBackupInfo(string filename)
        {
            FileInfo fi = new FileInfo(filename);

            FileBackupInfo fileBackupInfo = new FileBackupInfo(filename, fi.Length);
            return fileBackupInfo;
        }
    }
}
