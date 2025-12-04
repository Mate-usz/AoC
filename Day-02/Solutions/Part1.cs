namespace Day02.Solutions
{
    public static class Part1
    {
        public static long Solve(string[] puzzle)
        {
            long result = 0;

            for (int i = 0; i < puzzle.Length; i++)
            {
                string[] range = puzzle[i].Split('-');
                long range1 = Int64.Parse(range[0]);
                long range2 = Int64.Parse(range[1]);

                long diff = range2 - range1;

                Console.WriteLine($"Range {range1} - {range2} || DIFF: {diff}");

                for (int j = 0; j < diff+1; j++)
                {
                    long currentId = range1 + j;
                    if (CheckValidId(currentId))
                        continue;
                    
                    result += currentId;
                }
            }

            return result;
        }

        private static bool CheckValidId(long id)
        {
            bool valid = false;

            string stringId = id.ToString();

            if (stringId.Length % 2 != 0) 
                return true;

            string part1 = stringId.Substring(0, stringId.Length/2);
            string part2 = stringId.Substring(stringId.Length/2);

            // Console.WriteLine($"ID is Valid: {part1 != part2} => {part1} - {part2}"); 

            return part1 != part2;
        }
    }
}