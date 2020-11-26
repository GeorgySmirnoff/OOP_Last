using Lab4_Backup.ClearAlgorythm;
using System;
using System.Collections.Generic;
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

        public Backup(string[] filePaths)
        {
            this.filePaths.AddRange(filePaths);

            Id = Guid.NewGuid();
            CreationTime = DateTime.Now;
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
            if (isfullPoint)
            {
                FullPoint restorePoint = new FullPoint(filePaths);
                restorePoints.Add(restorePoint);

                return restorePoint;
            }
            else
            {
                if (restorePoints.Count == 0)
                    throw new ArgumentException("Прежде чем создать инкрементальную точку нужно чтобы была полная точка");

                FullPoint fullPoint = (FullPoint)restorePoints.Last();
                IncrementPoint restorePoint = new IncrementPoint(fullPoint, filePaths);
                fullPoint.IncrementPoints.Add(restorePoint);
                return restorePoint;
            }
        }

        public TypeResult Clear(IClearPoint clearPoint)
        {
            return clearPoint.Execute(restorePoints);
        }
    }
}
