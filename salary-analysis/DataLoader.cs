using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salary_analysis
{
    internal class SalaryRecord
    {
        public int Year { get; set; }
        public double MaleSalary { get; set; }
        public double FemaleSalary { get; set; }
    }
    internal class DataLoader
    {
        // Загружаем данные из Excel-файла
        public static List<SalaryRecord> LoadFromExcel(string filePath)
        {
            var records = new List<SalaryRecord>();

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Файл не найден", filePath);

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheets.Worksheet(1); // первая страница

                int row = 2; // предполагаем, что первая строка — заголовки
                while (!worksheet.Cell(row, 1).IsEmpty())
                {
                    var yearCell = worksheet.Cell(row, 1);
                    var maleSalaryCell = worksheet.Cell(row, 2);
                    var femaleSalaryCell = worksheet.Cell(row, 3);

                    if (int.TryParse(yearCell.GetValue<string>(), out int year) &&
                        double.TryParse(maleSalaryCell.GetValue<string>(), out double maleSalary) &&
                        double.TryParse(femaleSalaryCell.GetValue<string>(), out double femaleSalary))
                    {
                        records.Add(new SalaryRecord
                        {
                            Year = year,
                            MaleSalary = maleSalary,
                            FemaleSalary = femaleSalary
                        });
                    }

                    row++;
                }
            }

            return records;
        }

        // Преобразуем список записей в DataTable (для DataGridView)
        public static DataTable ToDataTable(List<SalaryRecord> records)
        {
            var table = new DataTable();
            table.Columns.Add("Год", typeof(int));
            table.Columns.Add("Мужчины", typeof(double));
            table.Columns.Add("Женщины", typeof(double));

            foreach (var rec in records)
            {
                table.Rows.Add(rec.Year, rec.MaleSalary, rec.FemaleSalary);
            }

            return table;
        }
    }
}
