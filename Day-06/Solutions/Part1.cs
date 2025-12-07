namespace Day06.Solutions
{
    public static class Part1
    {
        public static long Solve(string[] puzzle)
        {
            long answer = 0;

            List<string[]> problems = UnwrapPuzzle(puzzle);
            
            int numCols = problems.First().Length;

            Console.WriteLine($"Problem length => {problems.Count()} {numCols}");

            for(int i = 0; i < numCols; i++)
            {
                answer += ResolveProblemByIndex(i, ref problems); 
                Console.WriteLine($"Solved answer is now => {answer}");   
            }

            return answer;
        }

        private static List<string[]> UnwrapPuzzle(string[] input)
        {
            List<string[]> list = new List<string[]>();

            for(int i = 0; i < input.Length; i++)
            {
                string[] row = input[i].Trim().Split(" ").Where(x => x != "").ToArray();
                // Console.WriteLine($"[{i}] => {String.Join("--", row)}");
                list.Add(row);
            }

            return list;
        }

        private static long ResolveProblemByIndex(int index, ref List<string[]> problems)
        {
            int listLength = problems.Count();
            string operation = problems[listLength-1][index];

            long result = operation == "*" ? 1 : 0;

            Console.WriteLine($"Solving col {index} with [{operation}] operation");

            for (int i = 0; i < problems.Count()-1; i++)
            {
                Console.WriteLine($"NUM [{problems[i][index]}]");

                long num = Int64.Parse(problems[i][index]);

                if (operation == "*")
                {
                    result *= num;
                }
                else
                {
                    result += num;
                }
            }

            return result;
        }
    }
}