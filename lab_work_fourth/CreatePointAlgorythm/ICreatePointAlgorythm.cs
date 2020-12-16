using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup.CreatePointAlgorythm
{
    public interface ICreatePointAlgorythm
    {
        RestorePoint Create(List<FullPoint> fullPoints, List<string> filePaths);
    }
}
