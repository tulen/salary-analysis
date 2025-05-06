using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace salary_analysis
{
    public partial class Form1 : Form
    {
        private List<SalaryRecord> salaryRecords = new List<SalaryRecord>();
        public Form1()
        {
            InitializeComponent();

            
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 10;
            chart1.ChartAreas.Add(new ChartArea("MainArea"));
        }
        
        
        private void Download_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    salaryRecords = DataLoader.LoadFromExcel(openFileDialog.FileName);
                    DataTable table = DataLoader.ToDataTable(salaryRecords);
                    dataGridView1.DataSource = table;
                    MessageBox.Show("Ôàéë çàãðóæåí óñïåøíî!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Îøèáêà çàãðóçêè: " + ex.Message);
                }
            }
        }

        private void Grafic_btn_Click(object sender, EventArgs e)
        {
            if (salaryRecords.Count == 0)
            {
                MessageBox.Show("Ñíà÷àëà çàãðóçèòå äàííûå.");
                return;
            }

            chart1.Series.Clear();

            var maleSeries = new Series("Ìóæ÷èíû")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Blue
            };

            var femaleSeries = new Series("Æåíùèíû")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red
            };

            foreach (var rec in salaryRecords)
            {
                maleSeries.Points.AddXY(rec.Year, rec.MaleSalary);
                femaleSeries.Points.AddXY(rec.Year, rec.FemaleSalary);
            }

            chart1.Series.Add(maleSeries);
            chart1.Series.Add(femaleSeries);

            CalculateMinMaxChanges();
        }

        private void CalculateMinMaxChanges()
        {
            double maxGrowthM = double.MinValue;
            double minGrowthM = double.MaxValue;
            double maxGrowthF = double.MinValue;
            double minGrowthF = double.MaxValue;

            for (int i = 1; i < salaryRecords.Count; i++)
            {
                double changeM = (salaryRecords[i].MaleSalary - salaryRecords[i - 1].MaleSalary) / salaryRecords[i - 1].MaleSalary * 100.0;
                double changeF = (salaryRecords[i].FemaleSalary - salaryRecords[i - 1].FemaleSalary) / salaryRecords[i - 1].FemaleSalary * 100.0;

                maxGrowthM = Math.Max(maxGrowthM, changeM);
                minGrowthM = Math.Min(minGrowthM, changeM);

                maxGrowthF = Math.Max(maxGrowthF, changeF);
                minGrowthF = Math.Min(minGrowthF, changeF);
            }

            MessageBox.Show(
                $"Ìàêñ. ðîñò ó ìóæ÷èí: {maxGrowthM:F2}%\nÌèí. ðîñò/ïàäåíèå ó ìóæ÷èí: {minGrowthM:F2}%\n" +
                $"Ìàêñ. ðîñò ó æåíùèí: {maxGrowthF:F2}%\nÌèí. ðîñò/ïàäåíèå ó æåíùèí: {minGrowthF:F2}%"
            );
        }

        private void Prognoz_btn_Click(object sender, EventArgs e)
        {
            if (salaryRecords.Count < 3)
            {
                MessageBox.Show("Íåäîñòàòî÷íî äàííûõ äëÿ ïðîãíîçà (íóæíî ìèíèìóì 3 ãîäà).");
                return;
            }

            int forecastYears = (int)numericUpDown1.Value;

            var forecastM = MovingAverageForecast(salaryRecords.Select(r => r.MaleSalary).ToList(), forecastYears);
            var forecastF = MovingAverageForecast(salaryRecords.Select(r => r.FemaleSalary).ToList(), forecastYears);
            int startYear = salaryRecords.Last().Year + 1;

            var forecastMale = new Series("Ïðîãíîç (Ì)")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.LightBlue,
                BorderDashStyle = ChartDashStyle.Dash
            };

            var forecastFemale = new Series("Ïðîãíîç (Æ)")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Pink,
                BorderDashStyle = ChartDashStyle.Dash
            };

            for (int i = 0; i < forecastYears; i++)
            {
                forecastMale.Points.AddXY(startYear + i, forecastM[i]);
                forecastFemale.Points.AddXY(startYear + i, forecastF[i]);
            }

            chart1.Series.Add(forecastMale);
            chart1.Series.Add(forecastFemale);
        }

        private List<double> MovingAverageForecast(List<double> data, int years)
        {
            List<double> extended = new List<double>(data);
            int window = 3;

            for (int i = 0; i < years; i++)
            {
                double average = extended.Skip(extended.Count - window).Average();
                extended.Add(average);
            }

            return extended.Skip(data.Count).ToList();
        }
    }
}
// [Общие комментарии] Русские симолы ломаются - необходимо изменить кодировку на UTF8 - От Насти
