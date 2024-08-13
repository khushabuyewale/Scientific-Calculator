using System;
using System.Collections.Generic;
using AdvancedScientificCalculations;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            var calculator = new ScientificCalculator();

            Console.WriteLine("Welcome to the Scientific Calculator!");
            Console.WriteLine("Select an operation:");
            Console.WriteLine("1. Trigonometric Functions");
            Console.WriteLine("2. Logarithms");
            Console.WriteLine("3. Exponential Functions");
            Console.WriteLine("4. Complex Number Operations");
            Console.WriteLine("5. Statistical Functions");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformTrigonometricFunctions(calculator);
                    break;

                case "2":
                    PerformLogarithms(calculator);
                    break;

                case "3":
                    PerformExponentialFunctions(calculator);
                    break;

                case "4":
                    PerformComplexNumberOperations(calculator);
                    break;

                case "5":
                    PerformStatisticalFunctions(calculator);
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void PerformTrigonometricFunctions(ScientificCalculator calculator)
        {
            Console.WriteLine("Enter angle in radians for trigonometric functions:");
            double angle = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Sin({angle}) = {calculator.Sin(angle)}");
            Console.WriteLine($"Cos({angle}) = {calculator.Cos(angle)}");
            Console.WriteLine($"Tan({angle}) = {calculator.Tan(angle)}");
        }

        static void PerformLogarithms(ScientificCalculator calculator)
        {
            Console.WriteLine("Enter a number for logarithms:");
            double number = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Log({number}) = {calculator.Log(number)}");
            Console.WriteLine($"Ln({number}) = {calculator.Ln(number)}");
        }

        static void PerformExponentialFunctions(ScientificCalculator calculator)
        {
            Console.WriteLine("Enter a number for exponential functions:");
            double number = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Exp({number}) = {calculator.Exp(number)}");

            Console.WriteLine("Enter base and exponent for power function:");
            double baseValue = Convert.ToDouble(Console.ReadLine());
            double exponent = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Power({baseValue}, {exponent}) = {calculator.Power(baseValue, exponent)}");
        }

        static void PerformComplexNumberOperations(ScientificCalculator calculator)
        {
            Console.WriteLine("Enter real and imaginary parts of the first complex number (a b):");
            double a1 = Convert.ToDouble(Console.ReadLine());
            double b1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter real and imaginary parts of the second complex number (c d):");
            double a2 = Convert.ToDouble(Console.ReadLine());
            double b2 = Convert.ToDouble(Console.ReadLine());

            var resultAdd = calculator.AddComplex((a1, b1), (a2, b2));
            Console.WriteLine($"({a1} + {b1}i) + ({a2} + {b2}i) = ({resultAdd.Item1} + {resultAdd.Item2}i)");

            var resultSubtract = calculator.SubtractComplex((a1, b1), (a2, b2));
            Console.WriteLine($"({a1} + {b1}i) - ({a2} + {b2}i) = ({resultSubtract.Item1} + {resultSubtract.Item2}i)");
        }

        static void PerformStatisticalFunctions(ScientificCalculator calculator)
        {
            Console.WriteLine("Enter a list of numbers separated by spaces:");
            string[] inputs = Console.ReadLine().Split(' ');
            List<double> numbers = new List<double>();

            foreach (string input in inputs)
            {
                if (double.TryParse(input, out double number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine($"Invalid number: {input}");
                }
            }

            Console.WriteLine($"Mean = {calculator.Mean(numbers)}");
            Console.WriteLine($"Median = {calculator.Median(numbers)}");
            Console.WriteLine($"Standard Deviation = {calculator.StandardDeviation(numbers)}");
        }
    }
}
