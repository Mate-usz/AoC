namespace Day01.Solutions {
    public static class Part1
    {
        public static int MAX_NUMBER = 99;
        public static int MIN_NUMBER = 0;

        public static int Solve(string[] puzzle)
        {
            int dialPointer = 50;
            int password = 0;

            foreach (string line in puzzle)
            {
                string firstChar = line.Substring(0,1);
                int amount = Int32.Parse(line.Substring(1));

                if (firstChar == "R")
                {
                    MoveDial(amount, ref dialPointer);
                } 
                else if (firstChar == "L")
                {
                    MoveDial(-amount, ref dialPointer);
                }

                if (dialPointer == 0)
                {
                    password++;
                }
            }

            return password;
        }

        private static void MoveDial(int amount, ref int dialPointer)
        {
            
            int actualMove = Math.Sign(amount) * (Math.Abs(amount) % (MAX_NUMBER + 1));
            int finalValue = dialPointer + actualMove;

            if (finalValue > MAX_NUMBER)
            {
                dialPointer = MIN_NUMBER + (finalValue - MAX_NUMBER) - 1;
            }
            else if (finalValue < MIN_NUMBER)
            {
                dialPointer = MAX_NUMBER + finalValue + 1;
            }
            else
            {
                dialPointer = finalValue;
            }

            // Console.WriteLine($"After moving dial by: {amount} | {actualMove} | {finalValue} | {dialPointer}");
        }
    }

    
}