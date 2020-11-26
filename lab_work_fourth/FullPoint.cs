using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup
{
    public class FullPoint : RestorePoint
    {
        private List<FileBackupInfo> fileBackupInfos = new List<FileBackupInfo>();
        private List<IncrementPoint> incrementPoints = new List<IncrementPoint>();

        public FullPoint(List<string> filePaths) : base(filePaths)
        {
        }

        public List<IncrementPoint> IncrementPoints
        {
            get
            {
                return incrementPoints;
            }
        }

        public List<FileBackupInfo> FileBackupInfos
        {
            get
            {
                return fileBackupInfos;
            }
        }

        public override long Size
        {
            get
            {
                long size = 0;
                foreach (var item in fileBackupInfos)
                    size += item.Size;
                return size;
            }
        }

        protected override void Execute(List<string> filePaths)
        {
            foreach (var item in filePaths)
            {
                if (File.Exists(item))
                    fileBackupInfos.Add(CreateFileBackupInfo(item));
                else
                {
                    string[] files = Directory.GetFiles(item, "*.*", SearchOption.AllDirectories);
                    foreach (var file in files)
                    {
                        CreateFileBackupInfo(file);
                    }
                }
            }
        }

        
    }
}
