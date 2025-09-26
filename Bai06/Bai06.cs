namespace Bai06
{
    public class Bai06
    {
        // Get a number while trying to verify its validity
        static int GetNumber(string message, Predicate<int> cond)
        {
            Console.Write(message);
            var nStr = Console.ReadLine();

            // Get number with special condition
            bool success = int.TryParse(nStr, out int n);
            while (!success || !cond(n))
            {
                Console.Write($"Khong hop le, {message}");
                nStr = Console.ReadLine();
                success = int.TryParse(nStr, out n);
            }
            return n;
        }


        static void OutputMatrix(int[,] matrix)
        {
            if (matrix.Length == 0)
            {
                Console.WriteLine("Empty");
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        // Find the max and min value in the matrix
        static (int max, int min) GetMaxMin(int[,] matrix)
        {
            int max = matrix[0, 0];
            int min = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
            }
            return (max, min);
        }

        // Returns the row indexes whose sum of its elements is the largest
        static List<int> FindMaxSumRowIndexes(int[,] matrix)
        {
            // Find the row that have the largest sum of its elements
            int maxRowSum = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int rowSum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    rowSum += matrix[i, j];
                }

                if (rowSum > maxRowSum)
                {
                    maxRowSum = rowSum;
                }
            }

            // Find the indexes of rows that have the same max sum
            List<int> maxIndexes = [];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int rowSum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    rowSum += matrix[i, j];
                }

                if (rowSum == maxRowSum)
                {
                    maxIndexes.Add(i);
                }
            }
            return maxIndexes;
        }
        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        // Get the sum of all elements in the matrix that is not a prime number
        static int GetSumNotPrime(int[,] matrix)
        {
            int s = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (!IsPrime(matrix[i, j]))
                        s += matrix[i, j];
                }
            }
            return s;
        }

        // Delete the row with index of k
        static int[,] DelRowK(int[,] matrix, int k)
        {

            // if matrix is empty, ignore
            if (matrix.Length == 0)
            {
                return matrix;
            }


            // If the matrix have 1 row, return an empty matrix
            if (matrix.GetLength(0) == 1)
            {
                return new int[0, 0];
            }

            int[,] newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];

            // Copy before deleted row
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }

            // Copy after deleted row
            for (int i = k + 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[i - 1, j] = matrix[i, j];
                }
            }
            return newMatrix;
        }

        // Delete column k of the matrix
        static int[,] DelColK(int[,] matrix, int k)
        {
            // if matrix is empty, ignore
            if (matrix.Length == 0)
            {
                return matrix;
            }

            // If the matrix only have 1 col, returns empty matrix
            if (matrix.GetLength(1) == 1)
            {
                return new int[0, 0];
            }

            int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                // Copy from 0 to before deleted col
                for (int j = 0; j < k; j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }

                // Copy after deleted col to end
                for (int j = k + 1; j < matrix.GetLength(1); j++)
                {
                    newMatrix[i, j - 1] = matrix[i, j];
                }
            }
            return newMatrix;
        }

        // Delete the columns that contain the max element
        static int[,] DelMaxElCol(int[,] matrix)
        {
            // if matrix is empty, ignore
            if (matrix.Length == 0)
            {
                return matrix;
            }

            // Find the max column indexes
            var (max, _) = GetMaxMin(matrix);
            List<int> maxColIndexes = [];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == max)
                    {
                        maxColIndexes.Add(j);
                    }
                }
            }

            // Do it in reverse to prevent recalculating when shifting columns
            var newMatrix = matrix;
            maxColIndexes.Sort();
            for (int i = maxColIndexes.Count - 1; i >= 0; i--)
            {
                newMatrix = DelColK(newMatrix, maxColIndexes[i]);
            }

            return newMatrix;
        }

        static void Main(string[] args)
        {
            int n = GetNumber("Nhap n: ", n => n > 0);
            int m = GetNumber("Nhap m: ", n => n > 0);

            Random rnd = new();
            int[,] matrix = new int[n, m];

            //Generate a matrix with n rows, m columns and n* m random values
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // for easier testing
                    // Random value being small to promote duplicate elements
                    matrix[i, j] = rnd.Next(-20, 20);
                }
            }

            // test case when there are duplicate elements
            // very unlikely to happen due to elements being randomize
            //matrix = new int[3, 4] {
            //    {5, 6, 6, 12},
            //    {6, 5, 6, 12},
            //    {1, 7, 12, 5},
            //};

            // a)
            OutputMatrix(matrix);

            // b)
            var (max, min) = GetMaxMin(matrix);
            Console.WriteLine($"Max: {max}, min: {min}");

            // c)
            var maxRowIndexes = FindMaxSumRowIndexes(matrix);
            var displayRowIndexes = String.Join(", ", maxRowIndexes);
            Console.WriteLine($"Max row idx: {displayRowIndexes}");

            // d)
            Console.WriteLine($"Sum not prime: {GetSumNotPrime(matrix)}");

            // e)
            int k = GetNumber("Nhap dong k de xoa: ", (v) => v >= 0 && v < n);
            var newMatrix = DelRowK(matrix, k);
            Console.WriteLine("\nMatrix after delete row k");
            OutputMatrix(newMatrix);

            // f)
            Console.WriteLine("\nMatrix after delete max el's cols");
            var newMatrix2 = DelMaxElCol(newMatrix);
            OutputMatrix(newMatrix2);
        }
    }
}
