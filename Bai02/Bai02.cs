namespace Bai02
{
    internal class Bai02
    {
        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.Write("Nhap mot so nguyen duong: ");
            var nStr = Console.ReadLine();


            bool success = int.TryParse(nStr, out int n);
            while (!success || n <= 0)
            {
                Console.Write("Khong hop le, nhap mot so nguyen duong: ");
                nStr = Console.ReadLine();
                success = int.TryParse(nStr, out n);
            }

            int sPrime = 0;
            for (int i = 2; i < n; i++)
            {
                if (IsPrime(i))
                {
                    sPrime += i;
                }
            }
            Console.WriteLine($"Tong cac so nguyen to < {n}: {sPrime}");
        }
    }
}
