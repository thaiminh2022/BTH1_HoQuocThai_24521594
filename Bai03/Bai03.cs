using System.Diagnostics;

namespace Bai03
{
    public class Bai03
    {
        static int GetNumber(string message)
        {
            Console.Write(message);
            var nStr = Console.ReadLine();

            bool success = int.TryParse(nStr, out int n);
            while (!success)
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

        static bool IsValidDate(int day, int month, int year)
        {
            if (day < 1 || day > 31) return false;
            if (month < 1 || month > 12) return false;
            if (year < 0) return false;

            switch (month)
            {
                case 2:
                    if (IsLeap(year)) return day <= 29;
                    return day <= 28;
                case 1 or 3 or 5 or 7 or 8 or 10 or 12:
                    return day <= 31;
                case 4 or 6 or 9 or 11:
                    return day <= 30;
                default:
                    throw new UnreachableException("Cant reach");
            }

            throw new UnreachableException("Cant reach");
        }
        static void Main(string[] args)
        {
            int day = GetNumber("Nhap ngay: ");
            int month = GetNumber("Nhap thang: ");
            int year = GetNumber("Nhap nam: ");


            string msg = IsValidDate(day, month, year) ? "hop le" : "khong hop le";
            Console.WriteLine($"Ngay thang nam {msg}");
        }
    }
}
