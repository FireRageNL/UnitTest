using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApp
{
    public class CalculationLogic
    {
        private ICalculationRepository _calculationRepository;
        public CalculationLogic(ICalculationRepository repository)
        {
            _calculationRepository = repository;
        }

        public int[] GetAllCalculations()
        {
            return _calculationRepository.GetallCalculations();
        }

        public int[] GetCalculationsLargerThen1()
        {
            var calculations = _calculationRepository.GetallCalculations().ToList();

            return calculations.Select(x => x).Where(x => x > 1).ToArray();
        }

        public int CreateNewCalculation(int x, int y)
        {
            if (y <= 0 || x <= 0)
            {
                throw new DivideByZeroException("You might be possibly dividing by zero :O");
            }
            var calculationResult = x / y;
            var calculationsDone = _calculationRepository.GetallCalculations();
            if (calculationsDone.Contains(calculationResult))
            {
                throw new ArgumentException("Calculation already exists!");
            }
            var res = _calculationRepository.SaveCalculation(calculationResult);
            if (!res)
            {
                throw new Exception("Something went wrong with the database!");
            }
            return calculationResult;
        }
    }
}
