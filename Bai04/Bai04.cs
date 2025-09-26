namespace Bai04
{
    public class Bai04
    {
        // Them cond vao cho fancy, khoi check tay
        static int GetNumber(string message, Predicate<int> cond)
        {
            Console.Write(message);
            var nStr = Console.ReadLine();

            bool success = int.TryParse(nStr, out int n);
            while (!success || !cond(n))
            {
                Console.Write($"Khong hop le, {message}");
                nStr = Console.ReadLine();
                success = int.TryParse(nStr, out n);
            }
            return n;
        }
        static bool IsLeap(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    return year % 400 == 0;
                }
                return true;
            }
            return false;
        }


        static void Main(string[] args)
        {
            int month = GetNumber("Nhap thang: ", (n) => n >= 1 && n <= 12);
            int year = GetNumber("Nhap nam: ", (n) => n >= 0);

            int dayCount;
            switch (month)
            {
                case 2:
                    if (IsLeap(year)) dayCount = 29;
                    else dayCount = 28;
                    break;
                case 1 or 3 or 5 or 7 or 8 or 10 or 12:
                    dayCount = 31;
                    break;
                case 4 or 6 or 9 or 11:
                    dayCount = 30;
                    break;
                default:
                    throw new NotImplementedException("Cant reach");
            }
            Console.WriteLine($"So ngay cua thang {month} nam {year} la: {dayCount}");
        }
    }
}
