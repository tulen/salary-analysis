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

            var builder = new SalaryGraphBuilder(
                salaryRecords.Select(r => new SalaryData
                {
                    Year = r.Year,
                    MaleSalary = r.MaleSalary,
                    FemaleSalary = r.FemaleSalary
                }).ToList());

            builder.BuildChart(chart1);

            MessageBox.Show(builder.GetFormattedMaxGrowth(true) + "\n" + builder.GetFormattedMaxGrowth(false));

        }
        

        private void Prognoz_btn_Click(object sender, EventArgs e)
        {
            if (salaryRecords.Count < 3)
            {
                MessageBox.Show("Íåäîñòàòî÷íî äàííûõ äëÿ ïðîãíîçà (íóæíî ìèíèìóì 3 ãîäà).");
                return;
            }

            int forecastYears = (int)numericUpDown1.Value;

            var forecaster = new SalaryForecaster();
            var result = forecaster.BuildForecastSeries(salaryRecords, 3, forecastYears);

            chart1.Series.Add(result.maleSeries);
            chart1.Series.Add(result.femaleSeries);
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
