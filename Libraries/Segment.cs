using System;
using System.Collections.Generic;
using System.Text;

namespace Libraries
{
    public class Segment
    {
        public Point FirstEdge { get; private set; }
        public Point SecondEdge { get; private set; }

        public double Slope { get; private set; }
        public double Interecept { get; private set; }

        public Segment(Point firstEdege,Point secondEdge)
        {
            FirstEdge = firstEdege;
            SecondEdge = secondEdge;
            SetSlopeAndInterecept();

        }
        private void SetSlopeAndInterecept()
        {
            Slope = (SecondEdge.Y - FirstEdge.Y) / (SecondEdge.X - FirstEdge.X);
            Interecept = (FirstEdge.Y*SecondEdge.X - FirstEdge.X*SecondEdge.Y)/ (SecondEdge.X - FirstEdge.X);
        }

        public bool IsPartOfLine(Point p)
        {
            return p.Y == Interecept + Slope * p.X; 
        }

        public bool IsPartOfSegment(Point p)
        {
            return IsBetweenEdges(p) && IsPartOfLine(p);
        }

        public bool IsBetweenEdges(Point p)
        {
            return ((FirstEdge.X <= p.X & p.X <= SecondEdge.X) | (FirstEdge.X >= p.X & p.X >= SecondEdge.X)) &&
                ((FirstEdge.Y <= p.Y & p.Y <= SecondEdge.Y) | (FirstEdge.Y >= p.Y & p.Y >= SecondEdge.Y));
        }

        public Point GetImageWithFunction(double abscissa)
        {
            return new Point(abscissa, Slope * abscissa + Interecept);
        }
    }
}
