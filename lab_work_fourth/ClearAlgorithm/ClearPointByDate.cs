using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup.ClearAlgorythm
{
    public class ClearPointByDate : IClearPoint
    {
        private DateTime date;

        public ClearPointByDate(DateTime date)
        {
            this.date = date;
        }

        public TypeResult Execute(List<FullPoint> restorePoints)
        {
            TypeResult typeResult = TypeResult.Success;

            for (int i = 0; i < restorePoints.Count; i++)
            {
                if (restorePoints[i].CreateDate < date)
                {
                    bool check = true;

                    if (restorePoints[i].IncrementPoints.Count > 0)
                    {
                        //дата самой свежей инкрементальной точки
                        DateTime maxDate = restorePoints[i].IncrementPoints.Max(t => t.CreateDate);
                        if (maxDate > date)
                        {
                            check = false;
                            typeResult = TypeResult.Warning;
                        }
                    }

                    if (check)
                    {
                        restorePoints.RemoveAt(i);
                        i--;
                    }
                }
            }
            return typeResult;
        }
    }
}
