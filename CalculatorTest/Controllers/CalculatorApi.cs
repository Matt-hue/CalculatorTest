using CalculatorCommands.Calculator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorTest.Controllers
{
    [Route("api/calculator")]
    [ApiController]
    public class CalculatorApi : ControllerBase
    {
        private readonly ISimpleCalculator _calculator;

        public CalculatorApi(ISimpleCalculator calculator)
        {
            _calculator = calculator;
        }


        [HttpGet("Add")]
        public IActionResult Add(int first, int second)
        {
            return Ok(_calculator.Add(first, second));
        }

        [HttpGet("Subtract")]
        public IActionResult Subtract(int first, int second)
        {
            return Ok(_calculator.Subtract(first, second));
        }

        [HttpGet("Multiply")]
        public IActionResult Multiply(int first, int second)
        {
            return Ok(_calculator.Multiply(first, second));
        }

        [HttpGet("Divide")]
        public IActionResult Divide(int first, int second)
        {
            if (second == 0)
                return BadRequest("Cannot divide by zero");

            return Ok(_calculator.Divide(first, second));
        }

    }
}
