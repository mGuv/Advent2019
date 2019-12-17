using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Advent2019.Problems
{
    public class Day10 : IProblem
    {
        public int Day => 10;
        public string Title => "Monitoring Station";
        public string Part1Title { get; }
        public string Part2Title { get; }
        public Task RunPart1Async(CancellationToken cancellationToken)
        {
            string input =
                "#..#.#.#.######..#.#...## ##.#..#.#..##.#..######.# .#.##.#..##..#.#.####.#.. .#..##.#.#..#.#...#...#.# #...###.##.##..##...#..#. ##..#.#.#.###...#.##..#.# ###.###.#.##.##....#####. .#####.#.#...#..#####..#. .#.##...#.#...#####.##... ######.#..##.#..#.#.#.... ###.##.#######....##.#..# .####.##..#.##.#.#.##...# ##...##.######..##..#.### ...###...#..#...#.###..#. .#####...##..#..#####.### .#####..#.#######.###.##. #...###.####.##.##.#.##.# .#.#.#.#.#.##.#..#.#..### ##.#.####.###....###..##. #..##.#....#..#..#.#..#.# ##..#..#...#..##..####..# ....#.....##..#.##.#...## .##..#.#..##..##.#..##..# .##..#####....#####.#.#.# #..#..#..##...#..#.#.#.##";
            string[] rows = input.Split(" ");
            
            HashSet<(int,int)> asteroids = new HashSet<(int, int)>(); 
                

            for (int x = 0; x < rows[0].Length; x++)
            {
                for (int y = 0; y < rows.Length; y++)
                {
                    if (rows[y][x] == '#')
                    {
                        asteroids.Add((x, y));
                    }
                }
            }
            
            // now go through every coordinate and check it against every asteroid, only one per angle
            int bestAsteroids = 0;
            int coordX = 0;
            int coordY = 0;
            foreach ((int, int) asteroid in asteroids)
            {
                HashSet<double> anglesUsed = new HashSet<double>();
                foreach ((int, int) otherAsteroid in asteroids)
                {
                    anglesUsed.Add(Math.Atan2((otherAsteroid.Item2 - asteroid.Item2),
                        (otherAsteroid.Item1 - asteroid.Item1)));
                }

                if (anglesUsed.Count > bestAsteroids)
                {
                    bestAsteroids = anglesUsed.Count;
                    coordX = asteroid.Item1;
                    coordY = asteroid.Item2;
                }
            }
            
            Console.WriteLine($"Best station ({coordX}, {coordY}) can see {bestAsteroids} asteroids");

            return Task.CompletedTask;
        }

        public Task RunPart2Async(CancellationToken cancellationToken)
        {
            int coordX = 11;
            int coordY = 19;
            
            
            string input =
                "#..#.#.#.######..#.#...## ##.#..#.#..##.#..######.# .#.##.#..##..#.#.####.#.. .#..##.#.#..#.#...#...#.# #...###.##.##..##...#..#. ##..#.#.#.###...#.##..#.# ###.###.#.##.##....#####. .#####.#.#...#..#####..#. .#.##...#.#...#####.##... ######.#..##.#..#.#.#.... ###.##.#######....##.#..# .####.##..#.##.#.#.##...# ##...##.######..##..#.### ...###...#..#...#.###..#. .#####...##..#..#####.### .#####..#.#######.###.##. #...###.####.##.##.#.##.# .#.#.#.#.#.##.#..#.#..### ##.#.####.###....###..##. #..##.#....#..#..#.#..#.# ##..#..#...#..##..####..# ....#.....##..#.##.#...## .##..#.#..##..##.#..##..# .##..#####....#####.#.#.# #..#..#..##...#..#.#.#.##";
            string[] rows = input.Split(" ");
            
            HashSet<(int,int)> asteroids = new HashSet<(int, int)>(); 
                

            for (int x = 0; x < rows[0].Length; x++)
            {
                for (int y = 0; y < rows.Length; y++)
                {
                    if (rows[y][x] == '#')
                    {
                        asteroids.Add((x, y));
                    }
                }
            }
            
            // now go through every coordinate and find all asteroids on that angle
            List<double> angles = new List<double>();
            Dictionary<double, List<(int, int)>> asteroidsByAngle = new Dictionary<double, List<(int, int)>>();
            asteroidsByAngle.Add(-1d, new List<(int, int)>());
            foreach ((int, int) asteroid in asteroids)
            {
                if (asteroid.Item1 == coordX && asteroid.Item2 == coordY)
                {
                    continue;
                }

                double angle = Math.Atan2((asteroid.Item2 - coordY),
                    (asteroid.Item1 - coordX));
                if (angle < 0)
                {
                    angle = (2*Math.PI) + angle;
                }
                angles.Add(angle);

                if (!asteroidsByAngle.ContainsKey(angle))
                {
                    asteroidsByAngle.Add(angle, new List<(int, int)>());
                }
                
                asteroidsByAngle[angle].Add(asteroid);
            }

            angles.Sort();

            int asteroidsDestroyed = 0;
            double lastAngle = -1000;
            Dictionary<double, int> destructionsPerAngle = new Dictionary<double, int>();
            while (asteroidsDestroyed < 200)
            {
                if (angles[asteroidsDestroyed] == lastAngle)
                {
                    angles.RemoveAt(asteroidsDestroyed);
                    angles.Add(lastAngle);
                }
                else
                {
                    lastAngle = angles[asteroidsDestroyed];
                    if (!destructionsPerAngle.ContainsKey(lastAngle))
                    {
                        destructionsPerAngle.Add(lastAngle, 0);
                    }

                    destructionsPerAngle[lastAngle] = destructionsPerAngle[lastAngle] + 1;
                    asteroidsDestroyed++;
                }
            }

            
            // last angle holds who was last destroyed
            foreach ((int, int) asteroid in asteroidsByAngle[lastAngle])
            {
                int distance = ((asteroid.Item1 - coordX) * (asteroid.Item1 - coordX)) + ((asteroid.Item2 - coordY) * (asteroid.Item2 - coordY));
                Console.WriteLine($"Candidate ({asteroid.Item1}, {asteroid.Item2}): {(asteroid.Item1 * 100) + asteroid.Item2} at distance {distance}");
                
                
            }
            
            
            
            Console.WriteLine($"Destructions on that angle: {destructionsPerAngle[lastAngle]}");
            
            
            
            

            return Task.CompletedTask;
        }
    }
}