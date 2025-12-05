using Day04.Solutions;

string[] inputPuzzle = File.ReadAllLines("Input/input.txt");

Console.WriteLine("=== Day 4 ===");
Console.WriteLine($"Input Length: {inputPuzzle.Length}");
Console.WriteLine($"Solution 1: {Part1.Solve(inputPuzzle)}");
Console.WriteLine($"Solution 2: {Part2.Solve(inputPuzzle)}");