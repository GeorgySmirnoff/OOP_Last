using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup.CopyAlgorytms
{
    public class FileCopyArchiveAlgorithm : IFileCopyCreateAlgorithm
    {
        private string nameArchive;

        public FileCopyArchiveAlgorithm(string nameArchive)
        {
            this.nameArchive = nameArchive;
        }

        public void CreateFor(Backup backup)
        {

        }
    }
}