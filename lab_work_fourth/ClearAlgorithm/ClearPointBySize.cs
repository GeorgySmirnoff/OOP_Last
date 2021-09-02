using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup.ClearAlgorythm
{
    public class ClearPointBySize : IClearPoint
    {
        private long maxSize;

        public ClearPointBySize(long maxSize)
        {
            this.maxSize = maxSize;
        }

        public TypeResult Execute(List<FullPoint> restorePoints)
        {
            long totalSize = 0;

            for (int i = restorePoints.Count - 1; i >= 0; i--)
            {
                totalSize += restorePoints[i].Size + restorePoints[i].IncrementPoints.Sum(t => t.Size);

                if (totalSize >= maxSize)
                {
                    for (int j = 0; j < i; j++)
                    {
                        restorePoints.RemoveAt(0);
                    }
                    break;
                }
            }

            if (totalSize == maxSize)
                return TypeResult.Success;
            else if (totalSize > maxSize)
                return TypeResult.Warning;
            return TypeResult.Error;
        }
    }
}
