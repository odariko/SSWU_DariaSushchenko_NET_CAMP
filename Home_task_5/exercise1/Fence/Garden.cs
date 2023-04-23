using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fence
{
    internal class Garden
    {// порушення інкапсуляції
        public List<(int x, int y)> Trees { get; set; }

        public Garden(List<(int x, int y)> trees)
        {// тут мала б бути глибока копія
            Trees = trees;
        }

        public double CalculateFenceLength()
        {
            List<(int x, int y)> hull = CalculateConvexHull(Trees);

            double fenceLength = 0;
            for (int i = 0; i < hull.Count; i++)
            {
                int j = (i + 1) % hull.Count;
                double dx = hull[i].x - hull[j].x;
                double dy = hull[i].y - hull[j].y;
                fenceLength += Math.Sqrt(dx * dx + dy * dy);
            }
            return fenceLength;
        }

        private List<(int x, int y)> CalculateConvexHull(List<(int x, int y)> points)
        {
            List<(int x, int y)> sortedPoints = new List<(int x, int y)>(points);
            sortedPoints.Sort((p1, p2) =>
            {
                if (p1.x < p2.x)
                {
                    return -1;
                }
                else if (p1.x > p2.x)
                {
                    return 1;
                }
                else if (p1.y < p2.y)
                {
                    return -1;
                }
                else if (p1.y > p2.y)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });

            List<(int x, int y)> lowerHull = new List<(int x, int y)>();
            for (int i = 0; i < sortedPoints.Count; i++)
            {
                while (lowerHull.Count >= 2)
                {
                    int j = lowerHull.Count - 1;
                    double dx1 = lowerHull[j].x - lowerHull[j - 1].x;
                    double dy1 = lowerHull[j].y - lowerHull[j - 1].y;
                    double dx2 = sortedPoints[i].x - lowerHull[j].x;
                    double dy2 = sortedPoints[i].y - lowerHull[j].y;
                    if (dx1 * dy2 - dx2 * dy1 > 0)
                    {
                        break;
                    }
                    lowerHull.RemoveAt(j);
                }
                lowerHull.Add(sortedPoints[i]);
            }
// треба знайти лінійну оболонку для елементів. Точки можуть бути і внутрішніми мати дійсні координати
            List<(int x, int y)> upperHull = new List<(int x, int y)>();
            for (int i = sortedPoints.Count - 1; i >= 0; i--)
            {
                while (upperHull.Count >= 2)
                {
                    int j = upperHull.Count - 1;
                    double dx1 = upperHull[j].x - upperHull[j - 1].x;
                    double dy1 = upperHull[j].y - upperHull[j - 1].y;
                    double dx2 = sortedPoints[i].x - upperHull[j].x;
                    double dy2 = sortedPoints[i].y - upperHull[j].y;
                    if (dx1 * dy2 - dx2 * dy1 > 0)
                    {
                        break;
                    }
                    upperHull.RemoveAt(j);
                }
                upperHull.Add(sortedPoints[i]);
            }

            if (upperHull.Count > 0 && lowerHull.Count > 0)
            {
                upperHull.RemoveAt(upperHull.Count - 1);
                lowerHull.RemoveAt(lowerHull.Count - 1);
            }
            lowerHull.Reverse();
            lowerHull.AddRange(upperHull);

            return lowerHull;
        }

        public static bool operator <(Garden garden1, Garden garden2)
        {
            return garden1.CalculateFenceLength() < garden2.CalculateFenceLength();
        }

        public static bool operator >(Garden garden1, Garden garden2)
        {
            return garden1.CalculateFenceLength() > garden2.CalculateFenceLength();
        }

        public static bool operator <=(Garden garden1, Garden garden2)
        {
            return garden1.CalculateFenceLength() <= garden2.CalculateFenceLength();
        }

        public static bool operator >=(Garden garden1, Garden garden2)
        {
            return garden1.CalculateFenceLength() >= garden2.CalculateFenceLength();
        }
    }
}
