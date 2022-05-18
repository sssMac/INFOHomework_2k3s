namespace MatStat
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.Label label2;
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ValueBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Интервал = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xiavg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sigma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SigmaSqu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            label1.Location = new System.Drawing.Point(604, 587);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 30);
            label1.TabIndex = 35;
            label1.Text = "GAMMA";
            label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.button1.Location = new System.Drawing.Point(91, 599);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 65);
            this.button1.TabIndex = 30;
            this.button1.Text = "Lets GOOO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValueBox,
            this.Интервал,
            this.ni,
            this.Xiavg,
            this.Sigma,
            this.SigmaSqu});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(750, 556);
            this.dataGridView1.TabIndex = 31;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ValueBox
            // 
            this.ValueBox.HeaderText = "Value";
            this.ValueBox.Name = "ValueBox";
            // 
            // Интервал
            // 
            this.Интервал.HeaderText = "Интервал";
            this.Интервал.Name = "Интервал";
            // 
            // ni
            // 
            this.ni.HeaderText = "ni";
            this.ni.Name = "ni";
            // 
            // Xiavg
            // 
            this.Xiavg.HeaderText = "Xi avg";
            this.Xiavg.Name = "Xiavg";
            // 
            // Sigma
            // 
            this.Sigma.HeaderText = "Sigma";
            this.Sigma.Name = "Sigma";
            // 
            // SigmaSqu
            // 
            this.SigmaSqu.HeaderText = "X^2";
            this.SigmaSqu.Name = "SigmaSqu";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(768, 35);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Gista";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(768, 533);
            this.chart1.TabIndex = 32;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.button2.Location = new System.Drawing.Point(333, 599);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 65);
            this.button2.TabIndex = 33;
            this.button2.Text = "REFRESH";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(573, 620);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 20);
            this.textBox1.TabIndex = 34;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(768, 620);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(186, 20);
            this.textBox2.TabIndex = 36;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged_1);
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            label2.Location = new System.Drawing.Point(810, 587);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(113, 30);
            label2.TabIndex = 37;
            label2.Text = "COLUMN";
            label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 821);
            this.Controls.Add(label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Интервал;
        private System.Windows.Forms.DataGridViewTextBoxColumn ni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Xiavg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sigma;
        private System.Windows.Forms.DataGridViewTextBoxColumn SigmaSqu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

