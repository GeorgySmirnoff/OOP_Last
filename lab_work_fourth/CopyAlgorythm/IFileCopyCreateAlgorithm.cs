using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup.CopyAlgorytms
{
    public interface IFileCopyCreateAlgorithm
    {
        void CreateFor(Backup backup);
    }
}
