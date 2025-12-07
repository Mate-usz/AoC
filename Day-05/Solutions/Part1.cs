namespace Day05.Solutions
{
    public static class Part1
    {
        public static long Solve(string[] puzzle)
        {
            long result = 0;

            var (ranges, foodList) = SplitPuzzle(puzzle);

            // Console.WriteLine($"RANGE: {String.Join(" ", ranges)}\nLIST: {String.Join(" ", foodList)}");
            List<long[]> freshList = CreateListFreshFood(ranges);

            foreach(string food in foodList)
            {
                long id = Int64.Parse(food);
                if (IsFresh(id, ref freshList))
                {
                    result++;
                }
            }

            return result;
        }

        private static (string[] ranges, string[] foodList) SplitPuzzle(string[] input)
        {
            int indexSeparator = Array.FindIndex(input, el => el.Equals(""));

            return (input.Take(indexSeparator).ToArray(), input.Skip(indexSeparator+1).ToArray());
        }

        private static bool IsFresh(long id, ref List<long[]> freshList)
        {
            foreach(long[] rangeIDs in freshList)
            {
                if (id >= rangeIDs[0] && id <= rangeIDs[1])
                {
                    return true;
                }
            }

            return false;
        }

        private static List<long[]> CreateListFreshFood(string[] input)
        {
            List<long[]> list = new List<long[]>();
            
            // Console.WriteLine($"[START] Create Fresh List for {input.Length} values");
            for(int i = 0; i < input.Length; i++)
            {
                string[] ranges = input[i].Split("-");
                long startValue = Int64.Parse(ranges[0]);
                long endValue = Int64.Parse(ranges[1]);

                long[] addValue = [startValue, endValue]; 

                list.Add(addValue);
            }
            // Console.WriteLine("[END] Create Fresh List");
            return list;
        }
    }

}