using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace salary_analysis
{
    public class SalaryData
    {
        public int Year { get; set; }
        public double MaleSalary { get; set; }
        public double FemaleSalary { get; set; }
    }

    public class SalaryGraphBuilder
    {
        private List<SalaryData> salaryData;

        public SalaryGraphBuilder(List<SalaryData> data)
        {
            salaryData = data;
        }

        public void BuildChart(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Main"));

            //Добавляем подписи к осям
            chart.ChartAreas[0].AxisX.Title = "Год";
            chart.ChartAreas[0].AxisY.Title = "Зарплата";

            var maleSeries = new System.Windows.Forms.DataVisualization.Charting.Series("Мужчины")
            {
                ChartType = SeriesChartType.Line
            };
            var femaleSeries = new System.Windows.Forms.DataVisualization.Charting.Series("Женщины")
            {
                ChartType = SeriesChartType.Line
            };

            foreach (var item in salaryData)
            {
                maleSeries.Points.AddXY(item.Year, item.MaleSalary);
                femaleSeries.Points.AddXY(item.Year, item.FemaleSalary);
            }

            chart.Series.Add(maleSeries);
            chart.Series.Add(femaleSeries);
        }

        public (double value, int year) GetMaxGrowth(bool forMale)
        {
            double maxGrowth = double.MinValue;
            int yearOfMax = 0;

            for (int i = 1; i < salaryData.Count; i++)
            {
                double prev = forMale ? salaryData[i - 1].MaleSalary : salaryData[i - 1].FemaleSalary;
                double curr = forMale ? salaryData[i].MaleSalary : salaryData[i].FemaleSalary;

                if (prev != 0)
                {
                    double growth = (curr - prev) / prev * 100;
                    if (growth > maxGrowth)
                    {
                        maxGrowth = growth;
                        yearOfMax = salaryData[i].Year;
                    }
                }
            }

            return (Math.Round(maxGrowth, 2), yearOfMax);
        }

        public (double value, int year) GetMaxDrop(bool forMale)
        {
            double maxDrop = double.MaxValue;
            int yearOfDrop = 0;

            for (int i = 1; i < salaryData.Count; i++)
            {
                double prev = forMale ? salaryData[i - 1].MaleSalary : salaryData[i - 1].FemaleSalary;
                double curr = forMale ? salaryData[i].MaleSalary : salaryData[i].FemaleSalary;

                if (prev != 0)
                {
                    double drop = (curr - prev) / prev * 100;
                    if (drop < maxDrop)
                    {
                        maxDrop = drop;
                        yearOfDrop = salaryData[i].Year;
                    }
                }
            }

            return (Math.Round(maxDrop, 2), yearOfDrop);
        }

        public List<(int year, double change)> GetYearlyChanges(bool forMale)
        {
            var changes = new List<(int year, double change)>();

           
        for (int i = 1; i < salaryData.Count; i++)
            {
                double prev = forMale ? salaryData[i - 1].MaleSalary : salaryData[i - 1].FemaleSalary;
                double curr = forMale ? salaryData[i].MaleSalary : salaryData[i].FemaleSalary;

                if (prev != 0)
                {
                    double change = (curr - prev) / prev * 100;
                    changes.Add((salaryData[i].Year, Math.Round(change, 2)));
                }
            }

            return changes;
        }

        public string GetFormattedMaxGrowth(bool forMale)
        {
            var result = GetMaxGrowth(forMale);
            string gender = forMale ? "мужчин" : "женщин";
            return $"Максимальный прирост зарплаты у {gender} составил {result.value}% в {result.year} году.";
        }
    }


}