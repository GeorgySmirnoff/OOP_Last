using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup.ClearAlgorythm
{
    public class ClearPointHybrid : IClearPoint
    {
        private List<IClearPoint> clearAlgoritms = new List<IClearPoint>();
        private HybridType hybridType;

        public ClearPointHybrid(HybridType hybridType, params IClearPoint[] points)
        {
            clearAlgoritms.AddRange(points);
            this.hybridType = hybridType;
        }

        public TypeResult Execute(List<FullPoint> restorePoints)
        {
            List<FullPoint> res = new List<FullPoint>();
            TypeResult typeResult = TypeResult.Success;

            foreach (var item in clearAlgoritms)
            {
                List<FullPoint> copy = new List<FullPoint>(restorePoints);

                TypeResult typeRes = item.Execute(copy);
                if (typeRes != TypeResult.Success)
                    typeResult = typeRes;

                if (hybridType == HybridType.AllLimit)
                    res = res.Union(copy).ToList();
                else
                {
                    if (res.Count > 0)
                        res = res.Intersect(copy).ToList();
                    else
                        res.AddRange(copy);
                }
            }

            return typeResult;
        }
    }
}