using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Advent2019.Problems.Day18
{
    public class Map
    {
        private HashSet<Point> walkable;
        private Dictionary<Point, Key> keys;
        private Dictionary<Key, Point> keysByPoint = new Dictionary<Key, Point>();
        private Dictionary<Point, Key> doors;
        private Point start;

        public Map(HashSet<Point> walkable, Dictionary<Point, Key> keys, Dictionary<Point, Key> doors, Point start)
        {
            foreach (KeyValuePair<Point,Key> keyValuePair in keys)
            {
                keysByPoint.Add(keyValuePair.Value, keyValuePair.Key);
            }

            this.walkable = walkable;
            this.keys = keys;
            this.doors = doors;
            this.start = start;
        }

        private float CompareCost(PathNode a, PathNode b)
        {
            return (a.Steps + a.Heuristic < b.Steps + b.Heuristic) ? -1 : 1;
        }

        private int ManhattanDistance(Point a, Point b)
        {
            return Math.Abs(b.X - a.X) + Math.Abs(b.Y - a.Y);
        }

        public KeyPath FindStartingKeys()
        {
            Heap<PathNode> heap = new Heap<PathNode>(this.CompareCost);
            heap.Insert(new PathNode(start, 0, 0, Key.None));
            HashSet<Point> visitedLocations = new HashSet<Point>();
            Dictionary<Key, int> keysFound = new Dictionary<Key,int>();
            while (heap.Count > 0)
            {
                PathNode currentNode = heap.Pop();
                if (!visitedLocations.Add(currentNode.Point))
                {
                    // visited before
                    continue;
                }

                Key key;
                if (this.keys.TryGetValue(currentNode.Point, out key))
                {
                    keysFound.Add(key, currentNode.Steps);
                }

                if (this.IsWalkable(currentNode.Point))
                {
                    Point[] neighbours =
                    {
                        new Point(currentNode.Point.X + 1, currentNode.Point.Y),
                        new Point(currentNode.Point.X - 1, currentNode.Point.Y),
                        new Point(currentNode.Point.X, currentNode.Point.Y + 1),
                        new Point(currentNode.Point.X, currentNode.Point.Y - 1),
                    };

                    foreach (Point neighbour in neighbours)
                    {

                    }
                }
            }
        }
        public KeyPath FindPathBetweenKeys(Point a, Point b)
        {
            Heap<PathNode> heap = new Heap<PathNode>(this.CompareCost);
            heap.Insert(new PathNode(a, 0, this.ManhattanDistance(a, b), Key.None));
            HashSet<Point> visitedLocations = new HashSet<Point>();
            while (heap.Count > 0)
            {
                PathNode currentNode = heap.Pop();
                if (!visitedLocations.Add(currentNode.Point))
                {
                    // visited before
                    continue;
                }

                // is it the goal?
                if (currentNode.Point.Equals(b))
                {
                    return new KeyPath(currentNode.Steps, currentNode.KeysRequired);
                }

                Point[] neighbours =
                {
                    new Point(currentNode.Point.X + 1, currentNode.Point.Y),
                    new Point(currentNode.Point.X - 1, currentNode.Point.Y),
                    new Point(currentNode.Point.X, currentNode.Point.Y + 1),
                    new Point(currentNode.Point.X, currentNode.Point.Y - 1),
                };

                foreach (Point neighbour in neighbours)
                {
                    // Is it a door?
                    Key door;
                    if (this.IsDoor(currentNode.Point, out door))
                    {
                        // next node
                        heap.Insert(new PathNode(neighbour, currentNode.Steps + 1, this.ManhattanDistance(neighbour, b), currentNode.KeysRequired | door));
                        continue;
                    }

                    // Is it walkable?
                    if (this.IsWalkable(currentNode.Point))
                    {
                        heap.Insert(new PathNode(neighbour, currentNode.Steps + 1, this.ManhattanDistance(neighbour, b), currentNode.KeysRequired));
                    }
                }
            }

            return null;
        }

        public bool IsWalkable(Point point)
        {
            return this.walkable.Contains(point) || this.keys.ContainsKey(point) || start.Equals(point);
        }

        public bool IsDoor(Point point, out Key door)
        {
            return this.doors.TryGetValue(point, out door);
        }

        public Point GetKeyPoint(Key key)
        {
            return this.keysByPoint[key];
        }
    }
}
