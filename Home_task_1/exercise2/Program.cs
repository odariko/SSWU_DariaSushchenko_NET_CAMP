namespace Home_task._1._2
{
    internal class Program
    {
        static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void FindLongestLine(int[,] matrix) 
        {
            int longestColor = 0;
            int longestStartRow = 0;
            int longestStartCol = 0;
            int longestEndRow = 0;
            int longestEndCol = 0;
            int longestLineLength = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int currentColor = 0;
                int currentStartRow = 0;
                int currentStartCol = 0;
                int currentLength = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int color = matrix[i, j];
                    if (color == currentColor)
                    {
                        currentLength++;
                    }
                    else
                    {
                        if (currentLength > longestLineLength)
                        {
                            longestColor = currentColor;
                            longestStartRow = currentStartRow;
                            longestStartCol = currentStartCol;
                            longestEndRow = i;
                            longestEndCol = j - 1;
                            longestLineLength = currentLength;
                        }
                        currentColor = color;
                        currentStartRow = i;
                        currentStartCol = j;
                        currentLength = 1;
                    }
                }

                if (currentLength > longestLineLength)
                {
                    longestColor = currentColor;
                    longestStartRow = currentStartRow;
                    longestStartCol = currentStartCol;
                    longestEndRow = i;
                    longestEndCol = matrix.GetLength(1) - 1;
                    longestLineLength = currentLength;
                }
            }
            // метод не повинен роздруковувати результат, а повертати його через параметри...
            Console.WriteLine("Color: " + longestColor + " Start: " + longestStartRow + "," + longestStartCol + " End: " + longestEndRow + "," + longestEndCol + " Length: " + longestLineLength);
        }

        static void Main(string[] args)
        {
            int nRows = 4;
            int nCols = 8;
            int[,] matrix = new int[nRows, nCols];

            Random rand = new Random();

            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nCols; j++)
                {
                    matrix[i, j] = rand.Next(0, 17);
                }
            }

            Print(matrix);
            FindLongestLine(matrix);

        }
    }
}
