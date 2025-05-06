using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

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
        //[Обработка ошибок] В методе LoadFromExcel стоит добавить обработку возможных ошибок при парсинге данных 
        //(например, если в ячейках будут пустые или некорректные значения), чтобы избежать пропуска записей - От Насти
        
        // Загружаем данные из Excel-файла
        // Добавление обработки ошибок при парсинге данных
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

                    int year = 0;
                    double maleSalary = 0;
                    double femaleSalary = 0;

                    bool yearValid = int.TryParse(yearCell.GetValue<string>(), out year);
                    bool maleSalaryValid = double.TryParse(maleSalaryCell.GetValue<string>(), out maleSalary);
                    bool femaleSalaryValid = double.TryParse(femaleSalaryCell.GetValue<string>(), out femaleSalary);

                    // Проверка на корректность данных в ячейках
                    if (yearValid && maleSalaryValid && femaleSalaryValid)
                    {
                        records.Add(new SalaryRecord
                        {
                            Year = year,
                            MaleSalary = maleSalary,
                            FemaleSalary = femaleSalary
                        });
                    }
                    else
                    {
                        // Логирование ошибки (можно сделать вывод в лог или просто пропустить запись)
                        MessageBox.Show(
                        $"Ошибка в строке {row}: Некорректные данные. Год: {yearCell.GetValue<object>()} | Мужская зарплата: {maleSalaryCell.GetValue<object>()} | Женская зарплата: {femaleSalaryCell.GetValue<object>()}",
                        "Ошибка загрузки данных",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
);
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
//[Общие замечания] Рекомендуется провести тестирование этого кода с различными файлами Excel, 
//чтобы убедиться, что метод корректно работает с разными типами данных и не вызывает ошибок - От Насти
