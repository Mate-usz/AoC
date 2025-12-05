namespace Day03.Solutions
{
    public static class Part2
    {
        public static int NUM_JOLTAGE_DIGITS = 12;

        public static long Solve(string[] banks)
        {
            long maxJoltage = 0;

            foreach(string bank in banks)
            {
                maxJoltage += GetMaxJoltageInBank(bank);    
            }

            return maxJoltage;
        }

        private static long GetMaxJoltageInBank(string bank)
        {
            Console.WriteLine($"Checking bank: {bank}");

            int[] joltages = bank.Select(ch => ch - '0').ToArray();

            int[] result = GetMaxJoltageInSubbank(joltages, 0, joltages.Length-1);
            string val = String.Join("", result);
            Console.WriteLine($"Found {val}");

            return Int64.Parse(val);
        }

        private static int[] GetMaxJoltageInSubbank(int[] bank, int min_index, int max_index)
        {
            List<int> res = new List<int>();
            res.AddRange(bank.Skip(max_index-(NUM_JOLTAGE_DIGITS-1)));

            int leftBound = min_index;
            int rightBound = max_index-NUM_JOLTAGE_DIGITS;

            // Console.WriteLine($"[{NUM_JOLTAGE_DIGITS} - {bank.Length}]");

            for(int i = 0; i < res.Count(); i++)
            {
                bool changed = false;
                int newLBound = leftBound;
                int newRBound = rightBound;
                // Console.WriteLine($"BOUNDS L: {leftBound} | R: {rightBound} === {String.Join("", res)} ===");

                for(int j = newLBound; j <= newRBound; j++)
                {
                    if (bank[j] > res[i])
                    {
                        res[i] = bank[j];
                        leftBound = j+1;
                        changed = true;
                    }
                    if (bank[j] == res[i] && !changed)
                    {
                        leftBound = j+1;
                        changed = true;
                    }
                }

                if (changed)
                {
                    ++rightBound;
                    // Console.WriteLine($"New value [{i}] = {res[i]} L: {leftBound} | R: {rightBound} | {String.Join("", res)}");
                } else
                {
                    break;
                }
            }

            return res.ToArray();
        }
    }
}