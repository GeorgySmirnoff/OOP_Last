using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup.CopyAlgorytms
{
    public class FileCopySeparateAlgorithm : IFileCopyCreateAlgorithm
    {
        private string nameDirectory;

        public FileCopySeparateAlgorithm(string nameDirectory)
        {
            this.nameDirectory = nameDirectory;
        }

        public void CreateFor(Backup backup)
        {

        }
    }
}
