using Day02.Solutions;

string inputFile = File.ReadAllText("Input/input.txt");
string[] inputPuzzle = inputFile.Split(',');

Console.WriteLine("=== Day 2 ===");
Console.WriteLine($"Puzzle: {inputPuzzle.Length}");
Console.WriteLine($"Solution 1: {Part1.Solve(inputPuzzle)}");
Console.WriteLine($"Solution 2: {Part2.Solve(inputPuzzle)}");