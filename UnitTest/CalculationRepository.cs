using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApp
{
    public class CalculationRepository : ICalculationRepository
    {
        public int timesCalled = 0; 
        public int[] GetallCalculations()
        {
            timesCalled++;
            var rand = new Random();
            return Enumerable.Repeat(0, 20).Select(i => rand.Next(1, 200)).ToArray();
        }

        public int GetCalculationById(Guid calcId)
        {
            timesCalled++;
            var rand = new Random();
            return rand.Next(0, 20);
        }

        public bool SaveCalculation(int Result)
        {
            timesCalled++;
            var rand = new Random();
            return true;
        }
    }
}
