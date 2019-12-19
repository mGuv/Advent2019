using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Advent2019.Problems.Day18
{
    public class Problem : IProblem
    {
        string input =
            "################################################################################# #.....#........q..#...........#.........#.#...#.......#.#...#...#.....P...#.....# ###E#.#####.#######.###G#####.#########.#.#.#.#.###.#.#.#.#.#.#.#.#######.#.#.#.# #...#.....#...#.....#.#.#i..#.#...J.....#...#.....#.#...#.#...#.#.......#...#.#.# #.#######.###.#.#####.#.#.###.#.#######.#.#########.###.#.#####.#####.#######.#.# #.......#.....#.#.....#.#...#...#.....#.#.#.....#...#...#.#...#.#...#.#.......#.# #.#####.###.###.#.#.###.###.#########.#.#.###.#.#.#.#####.#.###.#.#.#.#.######### #.....#.#.#.#...#.#...#...#.....#.....#.#...#.#.#.#t#.....#...#...#.#.#.#.......# #####.#.#.#.#.#######.###.#.###.#.###.#.###.#.###.###.#######.#####.#.#.#.#####.# #...#.#.#...#.........#...#.#.....#.#.#.#.#...#...#...#...........#.#.#.#.#...#.# #.#.#.#.###.#########.#.###.#######.#.#.#.#.###.#.#.#######.#####.#.###.#.###.#.# #.#p#.#...#...#...#...#.#.#.......#...#.#.#.#...#.#.....#...#...#.#.#...#.....#.# #.#.#.###.###.#.###.###.#.#.#####.#.###.#.#.#.#########.#.###.#.###.#.#####.###.# #.#...#...#...#...#.#...#...#.#...#.#...#...#.#.......#...#...#.....#.#...#.#...# #####.#.###.#####.#.#.###.###.#.###.#.###.###.#.###.#####.#.#########.#.#.#.#.#.# #...#.#r#...#.....#.#...#.....#.#...#...#.#.#.#.#.#.....#.#.#.......#...#...#.#.# #.#.###.#.#####.#.#.###.#####.#.#.#####.#.#.#.#.#.###.#.#.#.###.###.#.#######.#.# #.#.....#.#...#.#.#.#.#.....#.#.#...#...#...#...#...#.#.#.#...#.#...#...#.....#.# #.#######.#.#.#.#.#.#.#####.###.###.#.#####.#####.#.#.#.#.###.#.#.#####.#.#####.# #.....#.#...#...#.#.......#...#...#.#.#.#.#.#.....#.#.#.#.#.#.#.#.#.....#.#...#.# #####.#.#####.#####.#####.###Y#.#.#.#.#.#.#.###.#.#.#.###.#.#.#.###.#####.#.#.#.# #.....#.#.....#...#.#...#...#.#.#.#.#.#.#.#...#.#.#.#...#...#.#.#...#...#.#.#.#.# #.#####.#.#####.#.#.###.#.###.#.#.###.#.#.###.###.#.###.###.###.#.#####.#.###.#.# #...#.......#.#.#.....#.#.#...#.#...#...#...#..b..#.#.#.#...#...........#...#...# #.#.#######.#.#.#######.###.#######.###.#.#########.#.#.#.#####.#######.###.###.# #.#.#...#.D...#v#.....#...#.#.....#.....#.#.......#...#.#.#...#.#...#.....#...#.# #.#.#L#.#######.#.###.###.#.#.###.#.#####.#.#.#######.#.#.#.#.#.#.#.#########.#.# #.#...#.#.....#.#...#.....#.....#.#...#.#.#.#.........#...#.#.#.#.#.#.......#.#.# #.#####.#.###.#.###.#############.###.#.#.#.###############.#.###.#.#.#####.#.#.# #.#...#...#.#...#.#.........#.....#...#.#.#.#.#.......#.....#...#.#.#.#.....V.#.# #.#.#.#####.#####.#########.#.#######.#.#.#.#.#.###X#.#.#.#####.#.#.#.#########.# #...#.#...#.........#.....#.#.......#...#...#.#...#.#.#.#.#...#.#.#.#.....#.R.#.# #####.#.###.#.#####.#.#####.#.#####.#####.###.###.#.#.###.#.###.#.#.#.###.#.###.# #...#.#.....#.....#.#.....#.#.....#.....#.#.......#.#....y#.#...#.#.#.#...#.#...# #.###.#.#########.#.#####.#.#####.#####.#.###.#####.#######.#.###.#.###.###.#.### #.....#...#.......#.#.....#...#.....#.#.#...#.....#.#.....#...#...#...#.#.....#.# #.#########.#######.#.#######.#####.#.#.###.#######.#.###.#.#####.###.#.#.#####.# #.........#.#.#...#.#.......#.#...#...#.#...#.....#.#.#...#.#...#...#...#.....#.# #########.#.#.#.#.#.#####.#.#.#.#.#####.#.###.###.#.#.#.###.#.#.###.#########.#.# #...........#...#.........#.#...#.............#.....#.#.......#.....#...........# #######################################.@.####################################### #.........#.....#...#...........#.............#.......#.......#.............#...# #.#.#######.#.###.#.###.#######.###.###.###.#.#.#####.#.#.###.#####.#####.#.#.#.# #.#m#z......#.....#..o#.....#.......#...#...#...#.....#.#...#.#...#...#...#.#.#.# #.#.#.###############.#####.#########.###.#########.#######.#.#.#.#.###.###.#.#.# #.#.#.....#.........#.....#.#...#...#.#.#.........#.#.......#...#.#.#...#.#.#.#.# #.#.#####.###.###.#.#####.#.#.#.#.#.#.#.#.#######.#.###.#########.###.###.#.###.# #.#.#...#...#...#.#...#...#...#...#.#...#.....#...#.....#...#.....#...#...#...#.# #.###.#.###.###.#.###.#.###########.###.#######.#########.###.#####.###.#.###.#.# #.....#.....#...#.#...#...#.....W.#...#.#.......#.........#...#.....#...#...#...# #.###########.###.#.#####.#.#####.###.#.#.#######.###.#####.###.#.###.###.#####.# #.....#.........#.#...#...#.#.....#...#.#.#...#.....#.....#.#...#.#...#.#.....#.# #####.###########.#.###.###.#.#####.###.#.#.#.#.#####.###.#.#####.#.###.#####.#.# #...#.....#.......#.#...#...#..n#.....#x#.#.#.#.#...#...#.......#.#.#...#...#...# #.#######.#.#######.#.#.#.#####.#####.#.#.#.#.###.#.###########.#.#.#.#.#.#.##### #...........#c....#.#.#.#...#.#.#.....#.#...#.#...#...#.......#...#l..#...#.....# #.###########.###.#.#.#.###.#.#.#.#####.#####.#.#####.#.#####.#################.# #.........#.F.#.#.#.#.#...#.#.#.#.....#.#...#.#.....#.#...#.#.#.....#.#.......#.# #########.#.###.#.#.#H###.#.#.#.#.###.###.#.#.#####.#.###.#.#.###.#.#.#.#####.#.# #.......#.#.....#.#.#...#.#...#.#...#...#.#.......#.#...#.#.#...#.#...#.#...#...# #.###.###.#####.#.#####.#.###.#.###.###.#.#####.###.#.###T#.###.#.#####.###.##### #...#.........#.#...#.#.#...#.#.#...#...#...#...#...#.....#.#...#.#.....#.......# #.#############.###.#C#.#####.#.###.#.#####.#.###.#########.#####.#.#####.####### #.#........f....#.#...#.......#...#g#...#...#...#.#...............#.#...#......u# #.#K#############.#######.#######N#.###.#.#####B#.###########.###.#.#.#.#####.#.# #.#.....#.....A.#....a..#.#.U...#.#...#.#.#.....#...#.........#...#...#.....#.#.# #.#####.###.###.###.###.#.#.###.#.#.###.#.#########.#.#########.###########.###.# #.#...#..k..#.#.....#.#.#...#w..#.#.#...#...........#.#...#...#.......#.....#...# #.#.#########.#######.#.#########.#.#.#.#############.#.#.#.#.#######.#.#####.### #.#.........#.........#.#......s..#.#.#.#.#.......#...#.#...#.......#.#.#.#.....# #.#.###.###.#####.###.#S#.#########.#.###.#.#.###.#.###.###########.###.#.#.###.# #.#...#.#.#.#...#.#...#...#...#...#.#...#.#.#.#.....#...#.....#...#...#.#...#...# #.#####.#.#.#.#.#.#.#######.#.#.###.###.#.#.#.###.###.###.#.#.###.###.#.#.###.### #..e....#.#.#.#...#...#.....#.#.......#.#...#...#.#...#...#.#.......#...#...#...# #########.#.#.#######.#####.#.#.#######.#.#####.#M#.#####.#.#######.###########.# #.......I.#.#.#.......#.....#.#..j#...#.#...#...#.#.#...#.#...#...#.#...#.......# #.#########.#.#.#######.#####.#####.#.#.#####.#####Q#.#.#####.###.#.#.#.#.#####.# #.....#...#...#.......#.#...#.......#.#.#.....#.....#.#.....#...#.#.Z.#.#.O.#.#.# #.###.#.#.###########.#.#.###########.#.#.#####.#####.#####.###.#.#####.###.#.#.# #...#...#...............#...............#..d..........#.........#...........#..h# #################################################################################";

        public int Day => 18;
        public string Title => "Many-Worlds Interpretation";
        public string Part1Title { get; }
        public string Part2Title { get; }

        public Task RunPart1Async(CancellationToken cancellationToken)
        {
            HashSet<Point> walkable = new HashSet<Point>();
            Dictionary<Point, char> keys = new Dictionary<Point, char>();
            Dictionary<Point, char> doors = new Dictionary<Point, char>();
            Point? start = null;

            string[] lines = input.Split(" ");

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
                        keys.Add(new Point(x, y), token);
                    }

                    if (token >= 'A' && token <= 'Z')
                    {
                        doors.Add(new Point(x, y), token);
                    }
                }
            }

            if (start is null)
            {
                throw new Exception("Could not find start point in map");
            }

            Func<PathNode, PathNode, float> comparison = (node, pathNode) =>
            {
                return node.Steps < pathNode.Steps ? -1 : 1;
            };
            Heap<PathNode> stack = new Heap<PathNode>(comparison);
            stack.Insert(new PathNode(start.Value, 0));

            while (stack.Count > 0)
            {
                PathNode node = stack.Pop();
                if (node.Keys.Count == keys.Count)
                {
                    // goal
                    Console.WriteLine($"Found a point??? {node.Steps} steps");
                    break;
                }

                Point[] neighbours = new[]
                {
                    new Point(node.Location.X, node.Location.Y + 1),
                    new Point(node.Location.X, node.Location.Y - 1),
                    new Point(node.Location.X + 1, node.Location.Y),
                    new Point(node.Location.X - 1, node.Location.Y)
                };

                foreach (Point point in neighbours)
                {
                    // Don't step there if have already?
                    if (node.closedSet.Contains(point))
                    {
                        continue;
                    }

                    node.closedSet.Add(point);
                    // is it a key?
                    if (keys.ContainsKey(point))
                    {
                        PathNode newNode = new PathNode(point, node.Steps + 1, node.Keys, node.closedSet);
                        if (newNode.Keys.Add(keys[point]))
                        {
                            newNode.closedSet.Clear();
                            newNode.closedSet.Add(point);
                        }

                        stack.Insert(newNode);
                        continue;
                    }

                    // is it a door I can open?
                    if (doors.ContainsKey(point) && node.Keys.Contains(char.ToLower(doors[point])))
                    {
                        PathNode newNode = new PathNode(point, node.Steps + 1, node.Keys, node.closedSet);
                        stack.Insert(newNode);
                        continue;
                    }

                    // Is it just walkable
                    if (walkable.Contains(point))
                    {
                        PathNode newNode = new PathNode(point, node.Steps + 1, node.Keys, node.closedSet);
                        stack.Insert(newNode);
                        continue;
                    }
                }
            }


            return Task.CompletedTask;
        }

        public Task RunPart2Async(CancellationToken cancellationToken)
        {
            HashSet<Point> walkable = new HashSet<Point>();
            Dictionary<Point, char> keys = new Dictionary<Point, char>();
            Dictionary<Point, char> doors = new Dictionary<Point, char>();
            Point? start = null;

            string[] lines = input.Split(" ");

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
                        keys.Add(new Point(x, y), token);
                    }

                    if (token >= 'A' && token <= 'Z')
                    {
                        doors.Add(new Point(x, y), token);
                    }
                }
            }

            if (start is null)
            {
                throw new Exception("Could not find start point in map");
            }

            Func<Run, Run, float> comparison = (node, pathNode) =>
            {
                return node.StepsSoFar < pathNode.StepsSoFar ? -1 : 1;
            };
            // From node, find all available keys, per key, create a new start
            Run initialRun = new Run(start.Value, 0, new HashSet<char>());
            Heap<Run> runs = new Heap<Run>(comparison);
            runs.Insert(initialRun);
            HashSet<Run> closedRuns = new HashSet<Run>();

            while (runs.Count > 0)
            {
                Run run = runs.Pop();
                if (!closedRuns.Add(run))
                {
                    continue;
                }
//                Console.WriteLine($"Starting at ({run.Start.X}, {run.Start.Y}) with {run.Keys.Count} keys after {run.StepsSoFar} steps");

                if (run.Keys.Count == keys.Count)
                {
                    Console.WriteLine($"Found all keys with {run.StepsSoFar} steps");
                    break;
                }

                // Flood out to all keys
                HashSet<Point> closedSet = new HashSet<Point>();
                Func<Step, Step, float> stepComparison = (node, pathNode) =>
                {
                    return node.Steps < pathNode.Steps ? -1 : 1;
                };
                Heap<Step> steps = new Heap<Step>(stepComparison);
                steps.Insert(new Step(run.Start, run.StepsSoFar));

                while (steps.Count > 0)
                {
                    Step step = steps.Pop();
                    if (!closedSet.Add(step.Location))
                    {
                        continue;
                    }

                    closedSet.Add(step.Location);

                    Point[] neighbours = new[]
                    {
                        new Point(step.Location.X, step.Location.Y + 1),
                        new Point(step.Location.X, step.Location.Y - 1),
                        new Point(step.Location.X + 1, step.Location.Y),
                        new Point(step.Location.X - 1, step.Location.Y)
                    };

                    foreach (Point point in neighbours)
                    {
                        // is it a key
                        if (keys.ContainsKey(point))
                        {
                            // Is it a key I don't have
                            if(!run.Keys.Contains(keys[point]))
                            {
                                // Only start a new run if it hasn't already?
                                if (!closedSet.Contains(point))
                                {
                                    string keyString = string.Concat(run.Keys.OrderBy(c => c).ToArray());
//                                    Console.WriteLine($"Found {keys[point]} with keys {keyString}");
                                    Run newRun = new Run(point, step.Steps + 1, run.Keys);
                                    newRun.Keys.Add(keys[point]);
                                    if (!closedRuns.Contains(newRun))
                                    {
                                        runs.Insert(newRun);
                                    }
                                    continue;
                                }
                            }
                            else
                            {
                                Step newStep = new Step(point, step.Steps + 1);
                                steps.Insert(newStep);
                                continue;
                            }

                        }

                        // is it a door I can open?
                        if (doors.ContainsKey(point) && run.Keys.Contains(char.ToLower(doors[point])))
                        {
                            Step newStep = new Step(point, step.Steps + 1);
                            steps.Insert(newStep);
                            continue;
                        }

                        // Is it just walkable
                        if (walkable.Contains(point))
                        {
                            Step newStep = new Step(point, step.Steps + 1);
                            steps.Insert(newStep);
                            continue;
                        }
                    }
                }

            }



            return Task.CompletedTask;
        }
    }
}
