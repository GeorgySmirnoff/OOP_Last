using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup
{
    public class FileBackupInfo
    {
        public string FilePath { get; }
        public long Size { get; }

        public FileBackupInfo(string filePath, long size)
        {
            FilePath = filePath;
            Size = size;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if (obj is FileBackupInfo)
            {
                FileBackupInfo other = (FileBackupInfo)obj;
                return FilePath.Equals(other.FilePath);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return FilePath.GetHashCode();
        }
    }
}
