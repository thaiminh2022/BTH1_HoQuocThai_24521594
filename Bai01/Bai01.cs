namespace Bai01
{
    public class Bai01
    {
        static bool IsNguyenTo(int n)
        {
            if (n < 2) return false;

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        static bool IsChinhPhuong(int n)
        {
            for (int i = 1; i * i <= n; i++)
            {
                if (n == i * i)
                    return true;
            }
            return false;
        }

        static int GetSumOdd(int[] arr)
        {
            int sOdd = 0;
            foreach (var v in arr)
            {
                if (v % 2 == 0)
                {
                    sOdd += v;
                }
            }
            return sOdd;
        }

        static int GetSumNguyenTo(int[] arr)
        {
            int sPrime = 0;
            foreach (var v in arr)
            {
                if (IsNguyenTo(v))
                {
                    sPrime += v;
                }
            }
            return sPrime;
        }
        static int FindMinChinhPhuong(int[] arr)
        {
            int minChinhPhuong = -1;
            foreach (var v in arr)
            {
                if (IsChinhPhuong(v))
                {
                    if (minChinhPhuong == -1)
                    {
                        minChinhPhuong = v;
                    }
                    else if (minChinhPhuong > v)
                    {
                        minChinhPhuong = v;
                    }
                }
            }
            return minChinhPhuong;
        }

        static void Main(string[] args)
        {
            Console.Write("Nhap so luong so ngau nhien: ");
            var nStr = Console.ReadLine();

            // Try to validate, whether input is a valid number
            bool success = int.TryParse(nStr, out int n);
            while (!success || n < 0)
            {
                Console.Write("Khong hop le, nhap mot so nguyen duong: ");
                nStr = Console.ReadLine();
                success = int.TryParse(nStr, out n);
            }

            Random rand = new();
            int[] ints = new int[n];

            Console.WriteLine("Cac so nguyen la: ");
            for (int i = 0; i < n; i++)
            {
                // for easy testing
                int v = rand.Next(-1000, 1000);
                ints[i] = v;

                Console.Write($"{v} ");
            }

            // a)
            Console.WriteLine($"\nTong so le trong mang: {GetSumOdd(ints)}");
            // b)
            Console.WriteLine($"Tong so nguyen to trong mang: {GetSumNguyenTo(ints)}");
            // c)
            Console.WriteLine($"So chinh phuong nho nhat: {FindMinChinhPhuong(ints)}");
        }

    }
}
