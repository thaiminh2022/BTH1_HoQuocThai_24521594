using System.Diagnostics;

namespace Bai05
{
    public class Bai05
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
        static void Main(string[] args)
        {
            int day = GetNumber("Nhap ngay: ");
            int month = GetNumber("Nhap thang: ");
            int year = GetNumber("Nhap nam: ");

            bool success = DateTime.TryParse($"{day}/{month}/{year}", out var date);
            while (!success)
            {
                Console.WriteLine("Ngay thang nam khong hop le, nhap lai");
                day = GetNumber("Nhap ngay: ");
                month = GetNumber("Nhap thang: ");
                year = GetNumber("Nhap nam: ");

                success = DateTime.TryParse($"{day}/{month}/{year}", out date);
            }
            // translate to vietnamese
            string thu = date.DayOfWeek switch
            {
                DayOfWeek.Monday => "Thu hai",
                DayOfWeek.Tuesday => "Thu ba",
                DayOfWeek.Wednesday => "Thu tu",
                DayOfWeek.Thursday => "Thu nam",
                DayOfWeek.Friday => "Thu sau",
                DayOfWeek.Saturday => "Thu bay",
                DayOfWeek.Sunday => "Chu nhat",
                _ => throw new UnreachableException("Unreachable"),
            };
            Console.WriteLine($"Thu trong tuan la: {thu}");
        }
    }
}
