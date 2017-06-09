namespace MainApplication
{
    partial class QuoteStats
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.dgvQuotes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.chQuotes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ViewCustomer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modificationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validToDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lockedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.selledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.quoteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chQuotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quoteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQuotes
            // 
            this.dgvQuotes.AllowUserToAddRows = false;
            this.dgvQuotes.AllowUserToDeleteRows = false;
            this.dgvQuotes.AutoGenerateColumns = false;
            this.dgvQuotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerNameDataGridViewTextBoxColumn,
            this.modificationDateDataGridViewTextBoxColumn,
            this.validToDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.lockedDataGridViewCheckBoxColumn,
            this.selledDataGridViewCheckBoxColumn,
            this.ViewCustomer});
            this.dgvQuotes.DataSource = this.quoteBindingSource;
            this.dgvQuotes.Location = new System.Drawing.Point(12, 49);
            this.dgvQuotes.MultiSelect = false;
            this.dgvQuotes.Name = "dgvQuotes";
            this.dgvQuotes.ReadOnly = true;
            this.dgvQuotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuotes.Size = new System.Drawing.Size(776, 258);
            this.dgvQuotes.TabIndex = 0;
            this.dgvQuotes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuotes_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(312, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "COTIZACIONES";
            // 
            // chQuotes
            // 
            this.chQuotes.BackColor = System.Drawing.SystemColors.Control;
            this.chQuotes.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chQuotes.BackSecondaryColor = System.Drawing.Color.Gray;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Name = "ChartArea1";
            this.chQuotes.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chQuotes.Legends.Add(legend1);
            this.chQuotes.Location = new System.Drawing.Point(-1, 313);
            this.chQuotes.Name = "chQuotes";
            this.chQuotes.Size = new System.Drawing.Size(800, 286);
            this.chQuotes.TabIndex = 2;
            this.chQuotes.Text = "chart1";
            // 
            // ViewCustomer
            // 
            this.ViewCustomer.HeaderText = "Ver";
            this.ViewCustomer.Name = "ViewCustomer";
            this.ViewCustomer.ReadOnly = true;
            this.ViewCustomer.Text = "VER";
            this.ViewCustomer.UseColumnTextForButtonValue = true;
            this.ViewCustomer.Width = 50;
            // 
            // customerNameDataGridViewTextBoxColumn
            // 
            this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
            this.customerNameDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
            this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerNameDataGridViewTextBoxColumn.Width = 250;
            // 
            // modificationDateDataGridViewTextBoxColumn
            // 
            this.modificationDateDataGridViewTextBoxColumn.DataPropertyName = "ModificationDate";
            this.modificationDateDataGridViewTextBoxColumn.HeaderText = "Ultima Modificación";
            this.modificationDateDataGridViewTextBoxColumn.Name = "modificationDateDataGridViewTextBoxColumn";
            this.modificationDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.modificationDateDataGridViewTextBoxColumn.Width = 110;
            // 
            // validToDataGridViewTextBoxColumn
            // 
            this.validToDataGridViewTextBoxColumn.DataPropertyName = "ValidTo";
            this.validToDataGridViewTextBoxColumn.HeaderText = "Valida hasta";
            this.validToDataGridViewTextBoxColumn.Name = "validToDataGridViewTextBoxColumn";
            this.validToDataGridViewTextBoxColumn.ReadOnly = true;
            this.validToDataGridViewTextBoxColumn.Width = 110;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lockedDataGridViewCheckBoxColumn
            // 
            this.lockedDataGridViewCheckBoxColumn.DataPropertyName = "Locked";
            this.lockedDataGridViewCheckBoxColumn.HeaderText = "Enviada";
            this.lockedDataGridViewCheckBoxColumn.Name = "lockedDataGridViewCheckBoxColumn";
            this.lockedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lockedDataGridViewCheckBoxColumn.Width = 50;
            // 
            // selledDataGridViewCheckBoxColumn
            // 
            this.selledDataGridViewCheckBoxColumn.DataPropertyName = "Selled";
            this.selledDataGridViewCheckBoxColumn.HeaderText = "Vendida";
            this.selledDataGridViewCheckBoxColumn.Name = "selledDataGridViewCheckBoxColumn";
            this.selledDataGridViewCheckBoxColumn.ReadOnly = true;
            this.selledDataGridViewCheckBoxColumn.Width = 50;
            // 
            // quoteBindingSource
            // 
            this.quoteBindingSource.DataSource = typeof(SBM.Core.Quote);
            // 
            // QuoteStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.chQuotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvQuotes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuoteStats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "QuoteStats";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chQuotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quoteBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQuotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chQuotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modificationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn validToDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lockedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ViewCustomer;
        private System.Windows.Forms.BindingSource quoteBindingSource;
    }
}