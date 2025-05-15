using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
namespace salary_analysis
{
    public class SalaryForecaster
    {
        public List<double> Forecast(List<double> values, int n = 3, int years = 5)
        {
            if (values.Count < n)
                throw new ArgumentException("Недостаточно данных для вычисления скользящей средней.");

            List<double> extended = new List<double>(values);

            for (int i = 0; i < years; i++)
            {
                double sum = 0;
                for (int j = extended.Count - n; j < extended.Count; j++)
                {
                    sum += extended[j];
                }
                double average = sum / n;
                extended.Add(average);
            }

            return extended.Skip(values.Count).ToList();
        }

        public (Series maleSeries, Series femaleSeries) BuildForecastSeries(
            List<SalaryData> salaryRecords, int n, int forecastYears)
        {
            if (salaryRecords.Count < n)
                throw new ArgumentException("Период скользящей средней не может превышать количество лет.");

            var maleSalaries = salaryRecords.Select(r => r.MaleSalary).ToList();
            var femaleSalaries = salaryRecords.Select(r => r.FemaleSalary).ToList();

            var forecastM = Forecast(maleSalaries, n, forecastYears);
            var forecastF = Forecast(femaleSalaries, n, forecastYears);

            int startYear = salaryRecords.Last().Year + 1;

            var maleSeries = new Series("Прогноз (М)")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.LightBlue,
                BorderDashStyle = ChartDashStyle.Dash
            };

            var femaleSeries = new Series("Прогноз (Ж)")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Pink,
                BorderDashStyle = ChartDashStyle.Dash
            };

            for (int i = 0; i < forecastYears; i++)
            {
                maleSeries.Points.AddXY(startYear + i, forecastM[i]);
                femaleSeries.Points.AddXY(startYear + i, forecastF[i]);
            }

            return (maleSeries, femaleSeries);
        }
    }
}

