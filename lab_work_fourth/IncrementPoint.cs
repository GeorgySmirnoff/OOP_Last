using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup
{
    public class IncrementPoint : RestorePoint
    {
        private List<FileBackupInfo> newFileBackupInfos = new List<FileBackupInfo>();
        private List<FileBackupInfo> deleteFileBackupInfos = new List<FileBackupInfo>();
        private List<FileBackupInfo> changeFileBackupInfos = new List<FileBackupInfo>();
        private FullPoint fullPoint;

        public IncrementPoint(FullPoint fullPoint, List<string> filePaths) : base(filePaths)
        {
            this.fullPoint = fullPoint;
        }

        public override long Size
        {
            get
            {
                long size = 0;
                foreach (var item in newFileBackupInfos)
                    size += item.Size;
                foreach (var item in deleteFileBackupInfos)
                    size += item.Size;
                foreach (var item in changeFileBackupInfos)
                    size += item.Size;
                return size;
            }
        }

        protected override void Execute(List<string> filePaths)
        {
            //собираем файлы с полной точки
            var files = new List<FileBackupInfo>(fullPoint.FileBackupInfos);

            //собираем файлы с инкремент точек
            foreach (var incrementPoint in fullPoint.IncrementPoints)
            {
                foreach (var item in incrementPoint.newFileBackupInfos)
                    files.Add(item);
                foreach (var item in incrementPoint.deleteFileBackupInfos)
                    files.Remove(item);
                foreach (var item in incrementPoint.changeFileBackupInfos)
                {
                    int pos = files.IndexOf(item);
                    files[pos] = item;
                }
            }

            var newFiles = filePaths.Except(files.Select(t => t.FilePath));
            foreach (var item in newFiles)
                newFileBackupInfos.Add(CreateFileBackupInfo(item));

            var deleteFiles = files.Select(t => t.FilePath).Except(filePaths);
            foreach (var item in deleteFiles)
                newFileBackupInfos.Add(CreateFileBackupInfo(item));

            //получить измененные
            foreach (var item in filePaths)
            {
                FileBackupInfo backupInfo = files.FirstOrDefault(t => t.FilePath == item);
                if (backupInfo != null)
                {
                    long size = new FileInfo(item).Length;
                    if (size != backupInfo.Size)
                    {
                        FileBackupInfo change = new FileBackupInfo(item, size);
                        changeFileBackupInfos.Add(change);
                    }
                }
            }
        }
    }
}
