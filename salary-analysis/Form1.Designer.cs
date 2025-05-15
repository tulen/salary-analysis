using System.Windows.Forms.DataVisualization.Charting;

namespace salary_analysis
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Grafic_btn = new Button();
            Prognoz_btn = new Button();
            numericUpDown1 = new NumericUpDown();
            Download_btn = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            this.chart1 = new Chart();
            this.chart1.Location = new Point(28, 430); // ниже кнопок
            this.chart1.Size = new Size(933, 230);     // подходящий размер 
            this.chart1.ChartAreas.Add(new ChartArea("MainArea"));
            this.Controls.Add(this.chart1);
            // 
            // Grafic_btn
            // 
            Grafic_btn.BackColor = Color.LightGreen;
            Grafic_btn.Location = new Point(729, 126);
            Grafic_btn.Name = "Grafic_btn";
            Grafic_btn.Size = new Size(216, 55);
            Grafic_btn.TabIndex = 0;
            Grafic_btn.Text = "Построить график";
            Grafic_btn.UseVisualStyleBackColor = false;
            Grafic_btn.Click += Grafic_btn_Click;
            // 
            // Prognoz_btn
            // 
            Prognoz_btn.BackColor = Color.LimeGreen;
            Prognoz_btn.Location = new Point(728, 304);
            Prognoz_btn.Name = "Prognoz_btn";
            Prognoz_btn.Size = new Size(217, 57);
            Prognoz_btn.TabIndex = 1;
            Prognoz_btn.Text = "Прогнозировать";
            Prognoz_btn.UseVisualStyleBackColor = false;
            Prognoz_btn.Click += Prognoz_btn_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(729, 271);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(216, 27);
            numericUpDown1.TabIndex = 2;
            // 
            // Download_btn
            // 
            Download_btn.Location = new Point(23, 126);
            Download_btn.Name = "Download_btn";
            Download_btn.Size = new Size(176, 55);
            Download_btn.TabIndex = 3;
            Download_btn.Text = "Загрузить файл";
            Download_btn.UseVisualStyleBackColor = true;
            Download_btn.Click += Download_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 19.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(210, 22);
            label1.Name = "label1";
            label1.Size = new Size(562, 45);
            label1.TabIndex = 4;
            label1.Text = "Статистика зарплат в России";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(229, 126);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(468, 235);
            dataGridView1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(229, 98);
            label2.Name = "label2";
            label2.Size = new Size(121, 20);
            label2.TabIndex = 6;
            label2.Text = "Вывод таблицы:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(728, 248);
            label3.Name = "label3";
            label3.Size = new Size(217, 20);
            label3.TabIndex = 7;
            label3.Text = "Количество лет для прогноза:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightYellow;
            ClientSize = new Size(990, 683);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(Download_btn);
            Controls.Add(numericUpDown1);
            Controls.Add(Prognoz_btn);
            Controls.Add(Grafic_btn);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Grafic_btn;
        private Button Prognoz_btn;
        private NumericUpDown numericUpDown1;
        private Button Download_btn;
        private Label label1;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label3;
        //private Chart chart1;
    }
}
