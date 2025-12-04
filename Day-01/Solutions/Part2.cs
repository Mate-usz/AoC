namespace Day01.Solutions {
    public static class Part2
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
                    MoveDial(amount, ref dialPointer, ref password);
                } 
                else if (firstChar == "L")
                {
                    MoveDial(-amount, ref dialPointer, ref password);
                }
            }

            return password;
        }

        private static void MoveDial(int amount, ref int dialPointer, ref int password)
        {
            int move = Math.Abs(amount);

            while (move > MAX_NUMBER)
            {
                password++;
                move -= MAX_NUMBER + 1;
            }

            int actualMove = Math.Sign(amount) * move;
            int finalValue = dialPointer + actualMove;

            if (finalValue > MAX_NUMBER)
            {
                password++;
                dialPointer = MIN_NUMBER + (finalValue - MAX_NUMBER) - 1;
            }
            else if (finalValue < MIN_NUMBER)
            {
                if(dialPointer != MIN_NUMBER)
                {
                    password++;
                }

                dialPointer = MAX_NUMBER + finalValue + 1;
            }
            else
            {
                dialPointer = finalValue;
                if(dialPointer == 0)
                {
                    password++;
                }
            }
            

            // Console.WriteLine($"After moving dial by: {amount} | {actualMove} | {finalValue} | {dialPointer}");
        }
    }

    // 6496
}