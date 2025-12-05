namespace Day04.Solutions
{
    
    public static class Part1
    {
        public static int Solve(string[] puzzle)
        {
            int result = 0;
            
            char[,] matrix = CreateMatrix(puzzle);

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == '@')
                    {
                        result += IsAccessible(i, j, ref matrix) ? 1 : 0;
                    }
                }
            }
            // IsAccessible(0,9,ref matrix);

            return result;
        }

        private static char[,] CreateMatrix(string[] input)
        {
            int rows = input.Length;
            int cols = input[0].Length;

            char[,] matrix = new char[rows,cols];

            for(int i = 0; i < rows; i++)
            {
                char[] rowPapers = input[i].ToCharArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i,j] = rowPapers[j];
                }
            }

            return matrix;
        }

        private static bool IsAccessible(int row, int col, ref char[,] matrix)
        {
            int neighbors = 0;

            int startingRow = Math.Max(row-1, 0);
            int startingCol = Math.Max(col-1, 0);
            int endRow = Math.Min(row+1,matrix.GetLength(0)-1);
            int endCol = Math.Min(col+1,matrix.GetLength(1)-1);

            for(int i = startingRow; i <= endRow; i++)
            {
                for(int j = startingCol; j <= endCol; j++)
                {
                    if (i==row && j==col) continue;

                    // Console.WriteLine($"CHECK {i} {j} => {matrix[i,j]}");
                    if (matrix[i,j] == '@')
                    {
                        neighbors++;
                    }

                }
            }

            // if (neighbors < 4)
            // {
            //     Console.WriteLine($"Accessible {row} {col} => ['{matrix[row,col]}'x{neighbors}]");
            // }

            return neighbors < 4;
        }
    }
}