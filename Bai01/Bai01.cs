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
        static void Main(string[] args)
        {
            Console.Write("Nhap so luong so ngau nhien: ");
            var nStr = Console.ReadLine();

            bool success = int.TryParse(nStr, out int n);
            while (!success || n < 0)
            {
                Console.Write("Khong hop le, nhap mot so nguyen duong: ");
                nStr = Console.ReadLine();
                success = int.TryParse(nStr, out n);
            }

            Random rand = new();
            int[] ints = new int[n];
            int sOdd = 0, sPrime = 0;
            int minChinhPhuong = -1;

            Console.WriteLine("Cac so nguyen la: ");
            for (int i = 0; i < n; i++)
            {
                // for easy testing
                int v = rand.Next(-1000, 1000);
                ints[i] = v;

                Console.Write($"{v} ");
            }

            foreach (var v in ints)
            {
                if (v % 2 != 0)
                {
                    sOdd += v;
                }

                if (IsNguyenTo(v))
                {
                    sPrime += v;
                }

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
            Console.WriteLine($"\nTong so le trong mang: {sOdd}");
            Console.WriteLine($"Tong so nguyen to trong mang: {sPrime}");
            Console.WriteLine($"So chinh phuong nho nhat: {minChinhPhuong}");
        }

    }
}
