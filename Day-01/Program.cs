using Day01.Solutions;

string[] input = File.ReadAllLines("Input/input.txt");

Console.WriteLine("=== Day 1 ===");
Console.WriteLine($"Puzzle: {input.Length}");
Console.WriteLine($"Solution 1: {Part1.Solve(input)}");
Console.WriteLine($"Solution 2: {Part2.Solve(input)}");