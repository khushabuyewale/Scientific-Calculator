using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace AdvancedScientificCalculations
{
    public class ScientificCalculator
    {
        private static readonly string ConnectionString = "server=localhost;database=calc_history;user=root;password=khushi";
        private const int HistoryLimit = 50;

        // Trigonometric Functions
        public double Sin(double angle) => Math.Sin(angle);
        public double Cos(double angle) => Math.Cos(angle);
        public double Tan(double angle) => Math.Tan(angle);

        // Logarithms
        public double Log(double value) => Math.Log10(value);
        public double Ln(double value) => Math.Log(value);

        // Exponential Functions
        public double Exp(double value) => Math.Exp(value);
        public double Power(double baseValue, double exponent) => Math.Pow(baseValue, exponent);

        // Complex Number Operations
        public (double, double) AddComplex((double, double) a, (double, double) b) => (a.Item1 + b.Item1, a.Item2 + b.Item2);
        public (double, double) SubtractComplex((double, double) a, (double, double) b) => (a.Item1 - b.Item1, a.Item2 - b.Item2);

        // Statistical Functions
        public double Mean(List<double> values) => values.Count == 0 ? 0 : values.Sum() / values.Count;
        public double Median(List<double> values)
        {
            values.Sort();
            int n = values.Count;
            return n % 2 == 0 ? (values[n / 2 - 1] + values[n / 2]) / 2.0 : values[n / 2];
        }
        public double StandardDeviation(List<double> values)
        {
            double mean = Mean(values);
            return Math.Sqrt(values.Sum(v => Math.Pow(v - mean, 2)) / values.Count);
        }

        // History Management
        public void LogCalculation(string operation, double result)
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    var command = new MySqlCommand("INSERT INTO CalculationHistory (Operation, Result, Timestamp) VALUES (@operation, @result, @timestamp)", connection);
                    command.Parameters.AddWithValue("@operation", operation);
                    command.Parameters.AddWithValue("@result", result);
                    command.Parameters.AddWithValue("@timestamp", DateTime.Now);
                    command.ExecuteNonQuery();
                    MaintainHistoryLimit(connection);
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log the error or display a message)
                Console.WriteLine($"Error logging calculation: {ex.Message}");
            }
        }

        private void MaintainHistoryLimit(MySqlConnection connection)
        {
            var command = new MySqlCommand("DELETE FROM CalculationHistory WHERE id NOT IN (SELECT id FROM (SELECT id FROM CalculationHistory ORDER BY id DESC LIMIT @limit) temp)", connection);
            command.Parameters.AddWithValue("@limit", HistoryLimit);
            command.ExecuteNonQuery();
        }
    }
}
