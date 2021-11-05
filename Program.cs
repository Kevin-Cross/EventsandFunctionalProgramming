using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            PointList points = new PointList();

            points.Changed += delegate (object sender, PointListChangedEventArgs e) 
            {
                Console.WriteLine($"Points changed: {e.Operation}");
            };

            points.Add(new Point(-4, -7)); 
            points.Add(new Point(0, 0)); 
            points.Add(new Point(1, 2)); 
            points.Add(new Point(-4, 5)); 
            points.Insert(2, new Point(3, 1)); 
            points.Add(new Point(7, -2)); 
            points[0] = new Point(2, 1); 
            points.RemoveAt(2);
            
            //Any() method to determine if points on the origin    
            Console.WriteLine(points.Any(p => p.X == 0 && p.Y == 0) ? "There are one or more points on the origin." : "There are no points on the origin");

            //Points in quadrant 1 (x and y positive)
            Console.WriteLine("Points in quadrant 1:");
            IEnumerable<Point> w = points.Where(p => p.X > 0 && p.Y > 0);
            foreach(Point p in w)
                Console.WriteLine(p);

            //GroupBy
            //I ordered the list before I grouped it because it bothered me more than it should have that the groups weren't printed in ascending order.
            var x = points.OrderBy(p => Math.Sqrt((p.X * p.X + p.Y * p.Y)));
            var d = x.GroupBy(p => Math.Floor(Math.Sqrt((p.X * p.X + p.Y * p.Y))), p => p.ToString());
            foreach (IGrouping<double, string> pointGroup in d)
            {
                Console.WriteLine($"Points with distance from origin between {pointGroup.Key} and {pointGroup.Key+1}. ");
                foreach (string p in pointGroup)
                {
                    Console.WriteLine("  {0}", p.ToString());
                }
            }

            Console.WriteLine("Press <ENTER> to quit...");
            Console.ReadLine();

        }
    }
}
