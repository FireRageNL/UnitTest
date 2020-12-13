using DemoApp;
using System;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new CalculationRepository();
            var calculation = new CalculationLogic(repo);

            Console.WriteLine("This is a very simple console app for demonstrating unit tests and such, the following is example outputs for the functions that the logic contains: ");
            Console.WriteLine(calculation.CreateNewCalculation(1, 2));
            Console.WriteLine(calculation.GetAllCalculations());
            Console.WriteLine(calculation.GetCalculationsLargerThen1());
            Console.WriteLine(calculation.GetSingleCalculation(Guid.NewGuid()));

        }
    }
}
