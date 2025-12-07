namespace Day05.Solutions
{
    public static class Part2
    {
        public static long[] LOW_RESULTS = [258398955933174, 334310694412781, 343505220601980];

        public static long Solve(string[] puzzle)
        {
            long result = 0;

            var (ranges, foodList) = SplitPuzzle(puzzle);

            List<long[]> freshList = CreateListFreshFood(ranges);
            List<long[]> cleanList = CleanUpRanges(freshList);

            result = GetNumberAllFreshFood(ref cleanList);

            string hint = LOW_RESULTS.Any(x => x == result) ? "=== [LOW] ===" : "=== [MAYBE] ===";

            Console.WriteLine(hint);
            
            return result;
        }

        private static (string[] ranges, string[] foodList) SplitPuzzle(string[] input)
        {
            int indexSeparator = Array.FindIndex(input, el => el.Equals(""));

            return (input.Take(indexSeparator).ToArray(), input.Skip(indexSeparator+1).ToArray());
        }

        private static List<long[]> CleanUpRanges(List<long[]> freshList)
        {
            Console.WriteLine("[START] Cleaning Ranges");

            List<long[]> cleanedList = new List<long[]>();
            List<long[]> tmpList = new List<long[]>();

            for(int i = 0; i < freshList.Count(); i++)
            {
                long startCounting = freshList[i][0];
                long endCounting = freshList[i][1];

                int listLength = cleanedList.Count();

                for(int j = 0; j < listLength; j++)
                {
                    long currentMin = cleanedList[j][0];
                    long currentMax = cleanedList[j][1];
                    if (startCounting >= currentMin && startCounting <= currentMax)
                    {
                        startCounting = currentMin;
                        tmpList.Add([currentMin, currentMax]);
                    } 
                    else if (currentMin >= startCounting && currentMin <= endCounting)
                    {
                        tmpList.Add([currentMin, currentMax]);
                    }

                    if (endCounting >= currentMin && endCounting <= currentMax)
                    {
                        endCounting = currentMax;
                        tmpList.Add([currentMin, currentMax]);
                    }
                }

                if(tmpList.Count() > 0)
                {
                    foreach(long[] el in tmpList)
                    {
                        cleanedList.RemoveAll(e => e[0] == el[0] && e[1] == el[1]);
                    }
                    tmpList.Clear();
                }

                // Console.WriteLine($"ADDING RANGE {startCounting} to {endCounting}");

                long[] newValues = [ startCounting, endCounting ];
                cleanedList.Add(newValues);
            }
            Console.WriteLine("[END] Cleaning Ranges");
            
            return cleanedList;
        }

        private static long GetNumberAllFreshFood(ref List<long[]> freshList)
        {
            long result = 0;

            for(int i = 0; i < freshList.Count(); i++)
            {
                long startCounting = freshList[i][0];
                long endCounting = freshList[i][1];
                
                // Console.WriteLine($"BOUNDS {startCounting} to {endCounting} = {endCounting-startCounting}");

                result += endCounting - startCounting + 1;
            }
            return result;
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
    // LOW => 258398955933174
    // LOW => 334310694412781
    // LOW => 343505220601980
}