using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup.CreatePointAlgorythm
{
    public class CreateFullPointAlgorithm : ICreatePointAlgorythm
    {
        public RestorePoint Create(List<FullPoint> fullPoints, List<string> filePaths)
        {
            FullPoint restorePoint = new FullPoint(filePaths);
            fullPoints.Add(restorePoint);

            return restorePoint;
        }
    }
}
