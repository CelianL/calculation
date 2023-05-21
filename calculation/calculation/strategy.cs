using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculation
{
    public interface ICalculationStrategy
    {
        int Calculate(int a, int b);
    }

    public class AdditionStrategy : ICalculationStrategy
    {
        public int Calculate(int a, int b)
        {
            return a + b;
        }
    }

    public class SubtractionStrategy : ICalculationStrategy
    {
        public int Calculate(int a, int b)
        {
            return a - b;
        }
    }

    public class MultiplicationStrategy : ICalculationStrategy
    {
        public int Calculate(int a, int b)
        {
            return a * b;
        }
    }

    public class DivisionStrategy : ICalculationStrategy
    {
        public int Calculate(int a, int b)
        {
            return a / b;
        }
    }
}
