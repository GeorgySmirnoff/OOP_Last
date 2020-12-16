using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup.CreatePointAlgorythm
{
    public class CreateIncrementPointAlgorithm : ICreatePointAlgorithm
    {
        public RestorePoint Create(List<FullPoint> fullPoints, List<string> filePaths)
        {
            if (fullPoints.Count == 0)
                throw new ArgumentException("Прежде чем создать инкрементальную точку нужно чтобы была полная точка");

            FullPoint fullPoint = fullPoints.Last();
            IncrementPoint restorePoint = new IncrementPoint(fullPoint, filePaths);
            fullPoint.IncrementPoints.Add(restorePoint);
            return restorePoint;
        }
    }
}

