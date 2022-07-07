using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCommands.Calculator
{
    public interface ISimpleCalculator
    {
        int Add(int start, int amount);
        int Subtract(int start, int amount);
        int Multiply(int start, int by);
        float Divide(int start, int by);
    }
    public class SimpleCalculator : ISimpleCalculator
    {

        private readonly ILogger<SimpleCalculator> _logger;

        public SimpleCalculator(ILogger<SimpleCalculator> logger)
        {
            _logger = logger;
        }

        public int Add(int start, int amount)
        {
            int result = start + amount;
            _logger.LogInformation("Adding {0} and {1}. Result: {2}", start.ToString(), amount.ToString(), result.ToString());

            return result;
        }

        public float Divide(int start, int by)
        {
            if (by == 0)
                throw new ArithmeticException("Cannot divide by zero");

            float result = (float)start / by;
            _logger.LogInformation("Dividing {0} by {1}. Result: {2}", start.ToString(), by.ToString(), result.ToString());

            return result;
        }

        public int Multiply(int start, int by)
        {
            int result = start * by;
            _logger.LogInformation("Multiplying {0} by {1}. Result: {2}", start.ToString(), by.ToString(), result.ToString());

            return result;
        }

        public int Subtract(int start, int amount)
        {
            int result = start - amount;
            _logger.LogInformation("Subtracting {0} and {1}. Result: {2}", start.ToString(), amount.ToString(), result.ToString());

            return result;
        }
    }
}
