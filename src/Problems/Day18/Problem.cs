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

        private MapFactory MapFactory;

        public Problem(MapFactory mapFactory)
        {
            this.MapFactory = mapFactory;
        }

        public Task RunPart1Async(CancellationToken cancellationToken)
        {
            Map map = this.MapFactory.Create(this.input);

            // Get shortest path between all keys
            Dictionary<Key, Dictionary<Key, KeyPath>> pathsByKey = new Dictionary<Key, Dictionary<Key, KeyPath>>();

            Key[] keysToCheck =
            {
                Key.a, Key.b, Key.c, Key.d, Key.e, Key.f, Key.g, Key.h, Key.i, Key.j, Key.k, Key.l, Key.m,
                Key.n, Key.o, Key.p, Key.q, Key.r, Key.s, Key.t, Key.u, Key.v, Key.w, Key.x, Key.y, Key.z
            };

            for (int i = 0; i < keysToCheck.Length; i++)
            {
                pathsByKey.Add(keysToCheck[i], new Dictionary<Key, KeyPath>());
            }

            for (int i = 0; i < keysToCheck.Length; i++)
            {
                for (int j = i + 1; j < keysToCheck.Length; j++)
                {
                    KeyPath path = map.FindPathBetweenKeys(map.GetKeyPoint(keysToCheck[i]), map.GetKeyPoint(keysToCheck[j]));
                    pathsByKey[keysToCheck[i]].Add(keysToCheck[j], path);
                    pathsByKey[keysToCheck[j]].Add(keysToCheck[i], path);
                }
            }

            // flood from start to find starting keys + distance

            // from those keys, find other keys they have access to, counting steps as they go

            return Task.CompletedTask;
        }

    public Task RunPart2Async(CancellationToken cancellationToken)
    {
    throw new NotImplementedException();
    }
}

}
