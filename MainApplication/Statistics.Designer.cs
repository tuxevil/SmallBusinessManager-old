namespace MainApplication
{
    partial class Statistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chNewCustomers = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chQuotesAndSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chNewCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chQuotesAndSales)).BeginInit();
            this.SuspendLayout();
            // 
            // chNewCustomers
            // 
            this.chNewCustomers.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chNewCustomers.BackSecondaryColor = System.Drawing.Color.DarkGray;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Name = "ChartArea1";
            this.chNewCustomers.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chNewCustomers.Legends.Add(legend1);
            this.chNewCustomers.Location = new System.Drawing.Point(0, 300);
            this.chNewCustomers.Name = "chNewCustomers";
            this.chNewCustomers.Size = new System.Drawing.Size(800, 300);
            this.chNewCustomers.TabIndex = 7;
            this.chNewCustomers.Text = "chart2";
            // 
            // chQuotesAndSales
            // 
            this.chQuotesAndSales.BackColor = System.Drawing.Color.DarkGray;
            this.chQuotesAndSales.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.Name = "ChartArea1";
            this.chQuotesAndSales.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chQuotesAndSales.Legends.Add(legend2);
            this.chQuotesAndSales.Location = new System.Drawing.Point(0, 0);
            this.chQuotesAndSales.Name = "chQuotesAndSales";
            this.chQuotesAndSales.Size = new System.Drawing.Size(800, 300);
            this.chQuotesAndSales.TabIndex = 6;
            this.chQuotesAndSales.Text = "chart1";
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.chNewCustomers);
            this.Controls.Add(this.chQuotesAndSales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Statistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.chNewCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chQuotesAndSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chNewCustomers;
        private System.Windows.Forms.DataVisualization.Charting.Chart chQuotesAndSales;
    }
}