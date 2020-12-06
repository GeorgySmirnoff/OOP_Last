using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup.ClearAlgorythm
{
    public class ClearPointByCount : IClearPoint
    {
        private int n;

        public ClearPointByCount(int n)
        {
            this.n = n;
        }

        public TypeResult Execute(List<FullPoint> restorePoints)
        {
            int countTotal = 0;

            for (int i = restorePoints.Count - 1; i >= 0; i--)
            {
                countTotal += 1 + restorePoints[i].IncrementPoints.Count;

                if (countTotal >= n)
                {
                    for (int j = 0; j < i; j++)
                    {
                        restorePoints.RemoveAt(0);
                    }
                    break;
                }
            }

            if (countTotal == n)
                return TypeResult.Success;
            else if (countTotal > n)
                return TypeResult.Warning;
            return TypeResult.Error;
        }
    }
}

