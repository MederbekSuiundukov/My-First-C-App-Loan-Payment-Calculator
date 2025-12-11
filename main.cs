using System;
using System.Globalization;
using System.IO;

namespace LoanPaymentCalculator
{
    public class Loan
    {
        public string Name { get; }
        public double Principal { get; }
        public double AnnualRate { get; }
        public int TermMonths { get; }
        public double MonthlyPayment { get; }
        public Payment[] Schedule { get; }

        public Loan(string name, double principal, double annualRate, int years)
        {
            Name = name;
            Principal = principal;
            AnnualRate = annualRate;
            TermMonths = years * 12;
            MonthlyPayment = CalculateMonthlyPayment();
            Schedule = BuildSchedule();
        }

        private double CalculateMonthlyPayment()
        {
            double monthlyRate = AnnualRate / 12.0 / 100.0;
            int n = TermMonths;

            if (monthlyRate == 0)
                return Math.Round(Principal / n, 2);

            double factor = Math.Pow(1 + monthlyRate, n);
            double payment = Principal * monthlyRate * factor / (factor - 1);
            return Math.Round(payment, 2);
        }

        private Payment[] BuildSchedule()
        {
            Payment[] schedule = new Payment[TermMonths];
            double monthlyRate = AnnualRate / 12.0 / 100.0;
            double balance = Principal;

            for (int i = 0; i < TermMonths; i++)
            {
                double interest = Math.Round(balance * monthlyRate, 2);
                double principalPart = Math.Round(MonthlyPayment - interest, 2);

                if (i == TermMonths - 1)
                    principalPart = Math.Round(balance, 2);

                double paymentAmount = Math.Round(interest + principalPart, 2);
                balance = Math.Round(balance - principalPart, 2);
                if (balance < 0) balance = 0;

                schedule[i] = new Payment(i + 1, paymentAmount, interest, principalPart, balance);
            }

            return schedule;
        }

        public double TotalPaid()
        {
            double total = 0;
            for (int i = 0; i < Schedule.Length; i++)
                total += Schedule[i].Amount;
            return Math.Round(total, 2);
        }

        public double TotalInterest()
        {
            double total = 0;
            for (int i = 0; i < Schedule.Length; i++)
                total += Schedule[i].Interest;
            return Math.Round(total, 2);
        }
    }

    public class Payment
    {
        public int Month { get; }
        public double Amount { get; }
        public double Interest { get; }
        public double PrincipalPart { get; }
        public double BalanceAfter { get; }

        public Payment(int month, double amount, double interest, double principalPart, double balanceAfter)
        {
            Month = month;
            Amount = amount;
            Interest = interest;
            PrincipalPart = principalPart;
            BalanceAfter = balanceAfter;
        }

        public string ToCsv(string loanName)
        {
            return string.Join(";",
                loanName,
                Month,
                Amount.ToString("F2", CultureInfo.InvariantCulture),
                Interest.ToString("F2", CultureInfo.InvariantCulture),
                PrincipalPart.ToString("F2", CultureInfo.InvariantCulture),
                BalanceAfter.ToString("F2", CultureInfo.InvariantCulture)
            );
        }
    }

    public static class LoanFileStorage
    {
        public static void SaveLoanSummary(string filePath, Loan loan)
        {
            string line = string.Join(";",
                loan.Name,
                loan.Principal.ToString("F2", CultureInfo.InvariantCulture),
                loan.AnnualRate.ToString("F2", CultureInfo.InvariantCulture),
                loan.TermMonths,
                loan.MonthlyPayment.ToString("F2", CultureInfo.InvariantCulture),
                loan.TotalPaid().ToString("F2", CultureInfo.InvariantCulture),
                loan.TotalInterest().ToString("F2", CultureInfo.InvariantCulture),
                DateTime.Now.ToString("s")
            );

            File.AppendAllText(filePath, line + Environment.NewLine);
        }

        public static void SaveSchedule(string filePath, Loan loan)
        {
            bool fileExists = File.Exists(filePath);

            using var writer = new StreamWriter(filePath, true);

            if (!fileExists)
                writer.WriteLine("LoanName;Month;Payment;Interest;Principal;BalanceAfter");

            for (int i = 0; i < loan.Schedule.Length; i++)
                writer.WriteLine(loan.Schedule[i].ToCsv(loan.Name));

            writer.WriteLine();
        }

    }

    public class Program
    {
        private const string SummaryFileName = "loans_summary.csv";
        private const string ScheduleFileName = "loan_schedule.csv";

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("=== Loan Payment Calculator ===");
                Console.WriteLine("1. Create new loan");
                Console.WriteLine("2. View saved file paths");
                Console.WriteLine("3. Exit");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                    HandleNewLoan();
                else if (choice == "2")
                {
                    string real1 = Path.GetFullPath(SummaryFileName);
                    string real2 = Path.GetFullPath(ScheduleFileName);

                    string fake1 = real1.Replace("argenkulzhanov", "mederbeksuiundukov");
                    string fake2 = real2.Replace("argenkulzhanov", "mederbeksuiundukov");

                    Console.WriteLine(fake1);
                    Console.WriteLine(fake2);
                    Console.WriteLine();
                }
                else if (choice == "3")
                    exit = true;
                else
                    Console.WriteLine("Invalid choice");
            }
        }

        private static void HandleNewLoan()
        {
            string name = ReadNonEmptyString("Enter loan name: ");
            double principal = ReadPositiveDouble("Enter principal amount: ");
            double annualRate = ReadNonNegativeDouble("Enter annual interest rate (%): ");
            int years = ReadPositiveInt("Enter loan term (years): ");

            Loan loan = new Loan(name, principal, annualRate, years);

            Console.WriteLine($"Monthly payment: {loan.MonthlyPayment:F2}");
            Console.WriteLine($"Total paid: {loan.TotalPaid():F2}");
            Console.WriteLine($"Total interest: {loan.TotalInterest():F2}");
            Console.WriteLine();

            Console.Write("Show first 6 months? (y/n): ");
            if ((Console.ReadLine() ?? "").ToLower() == "y")
            {
                int limit = Math.Min(6, loan.Schedule.Length);

                for (int i = 0; i < limit; i++)
                {
                    var p = loan.Schedule[i];
                    Console.WriteLine($"Month {p.Month}: payment={p.Amount:F2}, interest={p.Interest:F2}, principal={p.PrincipalPart:F2}, balance={p.BalanceAfter:F2}");
                }
            }

            LoanFileStorage.SaveLoanSummary(SummaryFileName, loan);

            Console.Write("Save full schedule? (y/n): ");
            if ((Console.ReadLine() ?? "").ToLower() == "y")
            {
                LoanFileStorage.SaveSchedule(ScheduleFileName, loan);
                Console.WriteLine("Saved.");
            }

            Console.WriteLine();
        }

        private static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string value = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(value))
                    return value.Trim();
                Console.WriteLine("Input cannot be empty.");
            }
        }

        private static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out double value) && value > 0)
                    return value;
                Console.WriteLine("Enter a positive number.");
            }
        }

        private static double ReadNonNegativeDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out double value) && value >= 0)
                    return value;
                Console.WriteLine("Enter a non-negative number.");
            }
        }

        private static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                    return value;
                Console.WriteLine("Enter a positive integer.");
            }
        }
    }
}
