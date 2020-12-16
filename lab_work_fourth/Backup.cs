using Lab4_Backup.ClearAlgorythm;
using Lab4_Backup.CopyAlgorytms;
using Lab4_Backup.CreatePointAlgorythm;
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
            return restorePoints.Sum(item => item.Size);
            }
        }

        public List<FullPoint> RestorePoints { get; }

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

        public RestorePoint CreateRestore(ICreatePointAlgorythm createPointAlgorithm)
        {
            UpdateFileList();

            RestorePoint point = createPointAlgorithm.Create(restorePoints, filePaths);
            fileCopyCreateAlgorithm.CreateFor(this);
            return point;
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
