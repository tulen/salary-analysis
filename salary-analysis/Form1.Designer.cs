namespace salary_analysis
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // Grafic_btn
            // 
            Grafic_btn.Location = new Point(347, 210);
            Grafic_btn.Name = "Grafic_btn";
            Grafic_btn.Size = new Size(203, 56);
            Grafic_btn.TabIndex = 0;
            Grafic_btn.Text = "Построить график";
            Grafic_btn.UseVisualStyleBackColor = true;
            // 
            // Prognoz_btn
            // 
            Prognoz_btn.Location = new Point(329, 91);
            Prognoz_btn.Name = "Prognoz_btn";
            Prognoz_btn.Size = new Size(164, 77);
            Prognoz_btn.TabIndex = 1;
            Prognoz_btn.Text = "Прогнозировать";
            Prognoz_btn.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(329, 36);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(160, 27);
            numericUpDown1.TabIndex = 2;
            // 
            // Download_btn
            // 
            Download_btn.Location = new Point(351, 296);
            Download_btn.Name = "Download_btn";
            Download_btn.Size = new Size(138, 53);
            Download_btn.TabIndex = 3;
            Download_btn.Text = "Загрузить файл";
            Download_btn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Download_btn);
            Controls.Add(numericUpDown1);
            Controls.Add(Prognoz_btn);
            Controls.Add(Grafic_btn);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button Grafic_btn;
        private Button Prognoz_btn;
        private NumericUpDown numericUpDown1;
        private Button Download_btn;
    }
}
