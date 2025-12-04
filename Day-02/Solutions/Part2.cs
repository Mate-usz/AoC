using System.Linq;

namespace Day02.Solutions
{
    public static class Part2
    {
        public static long Solve(string[] puzzle)
        {
            List<long> invalidIDs = new List<long>();

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

                    if (!invalidIDs.Contains(currentId))
                    {
                        // Console.WriteLine($"Result ADD = {currentId}");
                        invalidIDs.Add(currentId);
                    }
                }
            }

            return invalidIDs.Sum();
        }

        private static bool CheckValidId(long id)
        {
            bool valid = true;

            string stringId = id.ToString();

            List<string> partList = new List<string>();

            for (int i = 1; i <= stringId.Length/2; i++)
            {
                partList.Clear();
                if ((stringId.Length % i) == 0)
                {
                    // Console.WriteLine($"ID: {stringId} group by -> [{i}]");
                    for (int j = 0; j < stringId.Length; j += i)
                    {
                        // Console.WriteLine($"Adding: {stringId.Substring(j,1)} [{i}-{j}]");
                        partList.Add(stringId.Substring(j,i));
                    }
                    // Console.WriteLine($"List: {String.Join(" ", partList.ToArray())}");
                    string firstVal = partList.First();
                    valid = !partList.Skip(1).All(p => p.Equals(firstVal));
                }

                if (!valid)
                    break;
            }
            // Console.WriteLine($"ID is Valid: {part1 != part2} => {part1} - {part2}"); 
    
            return valid;
        }
    }

    // TOO HIGH: 
    // 21932258689
}