namespace salary_analysis
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dataGridView1;

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
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // Grafic_btn
            // 
            Grafic_btn.BackColor = Color.PaleGreen;
            Grafic_btn.Location = new Point(224, 397);
            Grafic_btn.Name = "Grafic_btn";
            Grafic_btn.Size = new Size(226, 54);
            Grafic_btn.TabIndex = 0;
            Grafic_btn.Text = "Построить график";
            Grafic_btn.UseVisualStyleBackColor = false;
            // 
            // Prognoz_btn
            // 
            Prognoz_btn.Location = new Point(456, 397);
            Prognoz_btn.Name = "Prognoz_btn";
            Prognoz_btn.Size = new Size(226, 54);
            Prognoz_btn.TabIndex = 1;
            Prognoz_btn.Text = "Прогнозировать";
            Prognoz_btn.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(37, 85);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(140, 27);
            numericUpDown1.TabIndex = 2;
            // 
            // Download_btn
            // 
            Download_btn.Location = new Point(37, 44);
            Download_btn.Name = "Download_btn";
            Download_btn.Size = new Size(140, 35);
            Download_btn.TabIndex = 3;
            Download_btn.Text = "Загрузить файл";
            Download_btn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(246, 44);
            label1.Name = "label1";
            label1.Size = new Size(436, 35);
            label1.TabIndex = 4;
            label1.Text = "Заработная плата в России";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(898, 513);
            Controls.Add(label1);
            Controls.Add(Download_btn);
            Controls.Add(numericUpDown1);
            Controls.Add(Prognoz_btn);
            Controls.Add(Grafic_btn);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Grafic_btn;
        private Button Prognoz_btn;
        private NumericUpDown numericUpDown1;
        private Button Download_btn;
        private Label label1;
    }
}
