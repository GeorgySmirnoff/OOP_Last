using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup.ClearAlgorythm
{
    public interface IClearPoint
    {
        TypeResult Execute(List<FullPoint> restorePoints);
    }
}
