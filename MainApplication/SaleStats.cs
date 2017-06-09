using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SBM.Business;
using SBM.Core;

namespace MainApplication
{
    public partial class SaleStats : Form
    {
        private SaleController saleController;
        private StatisticController statisticController;
        public SaleStats()
        {
            InitializeComponent();
            saleController = new SaleController();
            statisticController = new StatisticController();
            List<Sale> lst = saleController.GetAll();
            dgvSales.DataSource = lst;
            chSales.Series.Add(statisticController.GetStatisticalData(lst));
        }

        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                Sales s = new Sales((Sale)dgvSales.Rows[e.RowIndex].DataBoundItem);
                s.MdiParent = this.MdiParent;
                s.Show();
                this.Dispose();
            }
        }
    }
}
