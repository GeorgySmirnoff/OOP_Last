using Lab4_Backup.ClearAlgorythm;
using Lab4_Backup.CopyAlgorytms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup
{
    public class Backup
    {
        public Guid Id { get; }
        public DateTime CreationTime { get; }

        private List<string> filePaths = new List<string>();
        private List<FullPoint> restorePoints = new List<FullPoint>();
        private IFileCopyCreateAlgorithm fileCopyCreateAlgorithm;

        public long Size
        {
            get
            {
                long size = 0;
                foreach (var item in restorePoints)
                    size += item.Size;
                return size;
            }
        }

        public List<FullPoint> RestorePoints
        {
            get
            {
                return restorePoints;
            }
        }

        public Backup(string[] filePaths, IFileCopyCreateAlgorithm fileCopyCreateAlgorithm)
        {
            this.filePaths.AddRange(filePaths);

            Id = Guid.NewGuid();
            CreationTime = DateTime.Now;
            this.fileCopyCreateAlgorithm = fileCopyCreateAlgorithm;
        }

        public void Add(string filePath)
        {
            filePaths.Add(filePath);
        }

        public void Remove(string filePath)
        {
            filePaths.Remove(filePath);
        }

        public RestorePoint CreateRestore(bool isfullPoint)
        {
            UpdateFileList();

            if (isfullPoint)
            {
                FullPoint restorePoint = new FullPoint(filePaths);
                restorePoints.Add(restorePoint);

                fileCopyCreateAlgorithm.CreateFor(this);
                return restorePoint;
            }
            else
            {
                if (restorePoints.Count == 0)
                    throw new ArgumentException("Прежде чем создать инкрементальную точку нужно чтобы была полная точка");

                FullPoint fullPoint = restorePoints.Last();
                IncrementPoint restorePoint = new IncrementPoint(fullPoint, filePaths);
                fullPoint.IncrementPoints.Add(restorePoint);

                fileCopyCreateAlgorithm.CreateFor(this);
                return restorePoint;
            }

        }

        public TypeResult Clear(IClearPoint clearPoint)
        {
            return clearPoint.Execute(restorePoints);
        }

        private void UpdateFileList()
        {
            for (int i = 0; i < filePaths.Count; i++)
            {
                if (!File.Exists(filePaths[i]))
                {
                    filePaths.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
