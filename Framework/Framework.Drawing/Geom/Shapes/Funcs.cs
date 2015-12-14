// ============================================================================
// Project: Framework
// Name/Class: dRect
// Author: João Carreiro (joao.carreiro@cybermap.pt)
//         Filipe Nunes (filipe.nunes@cybermap.pt)
// Create date: 17/Oct/2013
// Company: Cybermap Lta.
// Description: Functions ton shapes. Utils.
// ============================================================================

using System;
using System.Linq;
using System.Collections.Generic;
using Framework.Core.Extensions;

namespace Framework.Drawing.Geom.Shapes
{
    public static class Funcs
    {
        //
        // Checks if two shapes have a common area.
        // Returns true if the two shapes intersect, or 
        // false otherwise.
        //

        public static bool Intersects(dRect shapeA, dRect shapeB)
        {
            dRect newShape = Intersection(shapeA, shapeB);
            return !(newShape.W < 0 || newShape.H < 0);
        }

        //
        // Compute the intersection between two shapes.
        // Method will compute the intersection shape
        // between the two supplied shapes.
        //

        public static dRect Intersection(dRect shapeA, dRect shapeB)
        {
            double newX = Math.Max(shapeA.X, shapeB.X);
            double newW = Math.Min(shapeA.X + shapeA.W, shapeB.X + shapeB.W) - newX;
            double newY = Math.Max(shapeA.Y, shapeB.Y);
            double newH = Math.Min(shapeA.Y + shapeA.H, shapeB.Y + shapeB.H) - newY;
            return new dRect(newX, newY, newW, newH);
        }

        // 
        // Based on a list of shapes, this mwthod computes the 
        // bounding box for all  of them. Bounding box takes the 
        // smallest X and Y coordinates a,d the largest width and 
        // height for al shapes.
        // 

        public static dRect GetBoundingBox(IList<dRect> lst)
        {
            dRect box = new dRect();
            double minX = double.MaxValue;
            double minY = double.MaxValue;
            double maxX = 0.0;
            double maxY = 0.0;

            // 
            // Find the bounding box for the supplied regions.
            //

            foreach (dRect shape in lst)
            {
                minX = shape.X < minX ? shape.X : minX;
                minY = shape.Y < minY ? shape.Y : minY;

                double toX = shape.X + shape.W;
                double toY = shape.Y + shape.H;

                maxX = toX > maxX ? toX : maxX;
                maxY = toY > maxY ? toY : maxY;
            }

            // 
            // Change the final box.
            //

            box.Change(minX, minY, maxX - minX, maxY - minY);

            return box;
        }

        //
        // Reshape a list of shapes in such way that they will 
        // be stack vertically inside a bounding box. All shapes 
        // will have the same height. Note that this method will 
        // change the shapes inside the list.
        //

        public static IList<dRect> ReshapeVerticalGrid(dRect box, IList<dRect> lst)
        {
            // 
            // Start a new list of shapes.
            //

            List<dRect> newShapes = new List<dRect>();

            // 
            // Compute the size for each box.
            // 

            double boxH = box.H / lst.Count;

            // 
            // Compute and change list of shapes.
            //

            for (int i = 0; i < lst.Count; i++)
            {
                double boxY = box.Y + (i * boxH);
                newShapes.Add(new dRect(box.X, boxY, box.W, boxH));
            }

            // 
            // Return shapes.
            //

            return newShapes;
        }

        //
        // Reshape a list of shapes in such way that they will be stacked horizontally
        // inside a bounding box. All shapes will have the same width. Note that
        // this method will change the shapes inside the list.
        //

        public static IList<dRect> ReshapeHorizontalGrid(dRect box, IList<dRect> lst)
        {
            // 
            // Start a new list of shapes.
            //

            List<dRect> newShapes = new List<dRect>();

            // 
            // Compute the size for each box.
            //

            double boxW = box.W / lst.Count;

            // 
            // Compute the size for each box.
            // Compute and change list of shapes.
            //

            for (int i = 0; i < lst.Count; i++)
            {
                double boxX = box.X + (i * boxW);
                newShapes.Add(new dRect(boxX, box.Y, boxW, box.H));
            }

            // 
            // Return shapes.
            //

            return newShapes;
        }

        //
        // Construct a grid with a set of input rectangular shapes.
        // This algorithm tries to maximize the total white space.
        //

        public static IList<dRect> Grid(dRect boundingBox, IList<dRect> rectList)
        {
            List<dRect> gridList = new List<dRect>();

            int N = rectList.Count();
            if (N == 1)
            {
                gridList.Add(boundingBox);
                return gridList;
            }

            bool hasPowder = false;
            if ((N & 1) != 0)
            {
                N -= 1;
                hasPowder = true;
            }

            double half = N / 2;

            int lastResult = (int)(N / half);
            int lastHalf = (int)half;
            int lastDifference = Math.Abs((int)(lastHalf - lastResult));

            --half;

            while (half > 1)
            {
                double result = N / half;

                if (result == (int)result)
                {
                    int thisDifference = Math.Abs((int)(half - result));
                    if (thisDifference <= lastDifference)
                    {
                        lastResult = (int)result;
                        lastHalf = (int)half;

                        lastDifference = thisDifference;
                    }
                    else
                    {
                        break;
                    }
                }
                half--;
            }

            int nColumns;
            int nRows;

            if (boundingBox.W >= boundingBox.H)
            {
                nColumns = lastResult;
                nRows = lastHalf;
            }
            else
            {
                nColumns = lastHalf;
                nRows = lastResult;
            }

            double rectW = boundingBox.W / nColumns;
            double rectH = boundingBox.H / nRows;



            for (int i = 0; i < nRows; ++i)
            {
                if (i == nRows - 1 && hasPowder) // last line and remaining rects don't fill whole row
                {
                    ++nColumns;
                    rectW = boundingBox.W / nColumns;
                }

                for (int j = 0; j < nColumns; ++j)
                {
                    dRect rect = new dRect(rectW * j, rectH * i, rectW, rectH);
                    gridList.Add(rect);
                }
            }

            return gridList;
        }

        //
        // Take a list of rectangular shapes, and a specific shape and
        // and try to expand the specified shape to ocupy all the available 
        // white space *WITHOUT* intersecting any shapes.
        //

        public static dRect ExpandToFill(dRect rectToExpand, dRect boundingBox, IList<dRect> rectList)
        {
            double Xinit = rectToExpand.X;
            double Yinit = rectToExpand.Y;
            double Xfinal = rectToExpand.X + rectToExpand.W;
            double Yfinal = rectToExpand.Y + rectToExpand.H;

            double Xnew = boundingBox.X;
            double Ynew = boundingBox.Y;
            double Wnew = boundingBox.W;
            double Hnew = boundingBox.H;

            //
            // X
            //

            List<dRect> aux = new List<dRect>();
            foreach (dRect rect in rectList)
            {
                // Check for intersections
                if (Funcs.Intersects(rectToExpand, rect))
                {
                    dRect intersectRect = Funcs.Intersection(rectToExpand, rect);
                    if (!(intersectRect.W == 0 || intersectRect.H == 0))
                    {
                        return null;
                    }
                }

                if (rect.X + rect.W <= Xinit)
                {
                    aux.Add(rect);
                }
            }

            foreach (dRect rect in aux)
            {
                if (rect.X + rect.W >= Xnew && !((Yinit > (rect.Y + rect.H)) || (Yfinal < (rect.Y))))
                {
                    Xnew = rect.X + rect.W;
                }
            }

            //
            // Y
            //

            aux.Clear();
            foreach (dRect rect in rectList)
            {
                if (rect.Y + rect.H <= Yinit)
                {
                    aux.Add(rect);
                }
            }

            foreach (dRect rect in aux)
            {
                if (rect.Y + rect.H >= Ynew && !((Xnew > (rect.X + rect.W)) || (Xfinal < (rect.X))))
                {
                    Ynew = rect.Y + rect.H;
                }
            }

            //
            // Width
            //

            aux = new List<dRect>();
            foreach (dRect rect in rectList)
            {
                if (rect.X >= Xfinal)
                {
                    aux.Add(rect);
                }
            }

            foreach (dRect rect in aux)
            {
                if (rect.X <= Wnew && !((Ynew > (rect.Y + rect.H)) || (Yfinal < (rect.Y))))
                {
                    Wnew = rect.X;
                }
            }

            Wnew = Wnew - Xnew;

            //
            // Height
            //

            aux = new List<dRect>();
            foreach (dRect rect in rectList)
            {
                if (rect.Y >= Yfinal)
                {
                    aux.Add(rect);
                }
            }

            foreach (dRect rect in aux)
            {
                if (rect.Y <= Hnew && !((Xnew > (rect.X + rect.W)) || (Wnew + Xnew < (rect.X))))
                {
                    Hnew = rect.Y;
                }
            }

            Hnew = Hnew - Ynew;

            return new dRect(Xnew, Ynew, Wnew, Hnew);
        }
    }
}
