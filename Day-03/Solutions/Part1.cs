namespace Day03.Solutions
{
    public static class Part1
    {
        public static int Solve(string[] banks)
        {
            int maxJoltage = 0;

            foreach(string bank in banks)
            {
                maxJoltage += GetMaxJoltageInBank(bank);    
            }

            return maxJoltage;
        }

        private static int GetMaxJoltageInBank(string bank)
        {
            // Console.WriteLine($"Checking bank: {bank}");

            int[] joltages = bank.Select(ch => ch - '0').ToArray();

            var (a1, b1) = GetMaxJoltageInSubbank(joltages, 0, joltages.Length-1);

            Console.WriteLine($"Found {a1}{b1}");

            return a1*10+b1;
        }

        private static (int left, int right) GetMaxJoltageInSubbank(int[] bank, int min_index, int max_index)
        {
            int leftIndex = -1;
            int rightIndex = -1;

            for(int i = min_index; i < max_index; i++)
            {
                if (leftIndex == -1 || bank[i] > bank[leftIndex])
                {
                    leftIndex = i;
                    rightIndex = i+1;
                    continue;
                }
                if (bank[i] >= bank[rightIndex])
                {
                    rightIndex = i;
                }
            }

            if (bank[max_index] > bank[rightIndex])
            {
                rightIndex = max_index;
            }

            return (bank[leftIndex],bank[rightIndex]);
        }
    }
}