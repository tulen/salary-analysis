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
            //this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Grafic_btn
            // 
            Grafic_btn.BackColor = Color.LightGreen;
            Grafic_btn.Location = new Point(301, 382);
            Grafic_btn.Name = "Grafic_btn";
            Grafic_btn.Size = new Size(176, 58);
            Grafic_btn.TabIndex = 0;
            Grafic_btn.Text = "Построить график";
            Grafic_btn.UseVisualStyleBackColor = false;
            this.Grafic_btn.Click += new System.EventHandler(this.Grafic_btn_Click);
            //
            // Chart1
            //
            this.chart1 = new Chart();
            this.chart1.Location = new Point(28, 430); // ниже кнопок
            this.chart1.Size = new Size(933, 230);     // подходящий размер
            this.chart1.ChartAreas.Add(new ChartArea("MainArea"));
            this.Controls.Add(this.chart1);
            // 
            // Prognoz_btn
            // 
            Prognoz_btn.Location = new Point(483, 382);
            Prognoz_btn.Name = "Prognoz_btn";
            Prognoz_btn.Size = new Size(176, 60);
            Prognoz_btn.TabIndex = 1;
            Prognoz_btn.Text = "Прогнозировать";
            Prognoz_btn.UseVisualStyleBackColor = true;
            this.Prognoz_btn.Click += new System.EventHandler(this.Prognoz_btn_Click);
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(28, 101);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(176, 27);
            numericUpDown1.TabIndex = 2;
            // 
            // Download_btn
            // 
            Download_btn.Location = new Point(28, 37);
            Download_btn.Name = "Download_btn";
            Download_btn.Size = new Size(176, 58);
            Download_btn.TabIndex = 3;
            Download_btn.Text = "Загрузить файл";
            Download_btn.UseVisualStyleBackColor = true;
            this.Download_btn.Click += new System.EventHandler(this.Download_btn_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(258, 37);
            label1.Name = "label1";
            label1.Size = new Size(475, 41);
            label1.TabIndex = 4;
            label1.Text = "Статистика зарплат в России";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(28, 150);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(933, 209);
            dataGridView1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightYellow;
            ClientSize = new Size(990, 683);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(Download_btn);
            Controls.Add(numericUpDown1);
            Controls.Add(Prognoz_btn);
            Controls.Add(Grafic_btn);
            //Controls.Add(this.chart1);
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
        //private Chart chart1;
    }
}
