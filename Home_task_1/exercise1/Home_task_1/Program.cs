namespace Home_task_1
{
    internal class Program
    {
        static void Print(int[,] matrix, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void FillMatrixСounterclock(int[,] matrix, int n, int m)
        {
            Console.WriteLine("Matrix Сounterclock-wise");
            int i = 0, j = 0, p = 1;

            while (i < n * m)
            {
                for (j = i; j <= n - 2 - i; j++)
                {
                    matrix[j, i] = p++;
                }

                for (j = i; j <= m - 2 - i; j++)
                {
                    matrix[n - i - 1, j] = p++;
                }

                for (j = n - 1 - i; j >= i + 1; j--)
                {
                    matrix[j, m - 1 - i] = p++;
                }

                for (j = m - 1 - i; j >= i + 1; j--)
                {
                    matrix[i, j] = p++;
                }

                i++;
            }

            if (i % 2 != 0)
            {
                matrix[(n - 1) / 2, (m - 1) / 2] = p;
            }
        }

        static void FillMatrixClockwise(int[,] matrix, int n, int m)
        {
            Console.WriteLine("Matrix Clockwise");
            int i = 0, j = 0, p = 1;

            while (i < n * m)
            {
                for (j = i; j <= n - 2 - i; j++)
                {
                    matrix[i, j] = p++;
                }

                for (j = i; j <= m - 2 - i; j++)
                {
                    matrix[j, m - i - 1] = p++;
                }

                for (j = m - 1 - i; j >= i + 1; j--)
                {
                    matrix[n - 1 - i, j] = p++;
                }

                for (j = n - 1 - i; j >= i + 1; j--)
                {
                    matrix[j, i] = p++;
                }

                i++;
            }

            if (i % 2 != 0)
            {
                matrix[(n - 1) / 2, (m - 1) / 2] = p;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of rows and columns");
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, m];

            FillMatrixСounterclock(matrix, n, m);
            Console.WriteLine();
            Print(matrix, n, m);

            FillMatrixClockwise(matrix, n, m);
            Console.WriteLine();
            Print(matrix, n, m);
        }
    }
}