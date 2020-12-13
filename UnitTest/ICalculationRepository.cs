using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp
{
    public interface ICalculationRepository
    {
        bool SaveCalculation(int Result);

        int GetCalculationById(Guid calcId);

        int[] GetallCalculations(); 
    }
}
