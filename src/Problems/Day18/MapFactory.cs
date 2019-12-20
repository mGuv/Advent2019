using System;
using System.Collections.Generic;
using System.Drawing;

namespace Advent2019.Problems.Day18
{
    public class MapFactory
    {
        public Map Create(string map)
        {
            HashSet<Point> walkable = new HashSet<Point>();
            Dictionary<Point, Key> keys = new Dictionary<Point, Key>();
            Dictionary<Point, Key> doors = new Dictionary<Point, Key>();
            Point? start = null;

            string[] lines = map.Split(" ");

            for (int x = 0; x < lines[0].Length; x++)
            {
                for (int y = 0; y < lines.Length; y++)
                {
                    char token = lines[y][x];
                    if (token == '#')
                    {
                        continue;
                    }

                    if (token == '.')
                    {
                        walkable.Add(new Point(x, y));
                        continue;
                    }

                    if (token == '@')
                    {
                        start = new Point(x, y);
                    }

                    if (token >= 'a' && token <= 'z')
                    {
                        keys.Add(new Point(x, y), Enum.Parse<Key>(token.ToString()));
                    }

                    if (token >= 'A' && token <= 'Z')
                    {
                        doors.Add(new Point(x, y), Enum.Parse<Key>(char.ToLower(token).ToString()));
                    }
                }
            }

            return new Map(walkable, keys, doors, start.Value);
        }
    }
}
