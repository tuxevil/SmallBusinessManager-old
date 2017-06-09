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
    public partial class QuoteStats : Form
    {
        private QuoteController quoteController;
        private StatisticController statisticController;

        public QuoteStats()
        {
            InitializeComponent();
            quoteController = new QuoteController();
            statisticController = new StatisticController();
            List<Quote> lst = quoteController.GetAll();
            dgvQuotes.DataSource = lst;
            chQuotes.Series.Add(statisticController.GetStatisticalData(lst));
        }

        private void dgvQuotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                Quotes q = new Quotes((Quote)dgvQuotes.Rows[e.RowIndex].DataBoundItem);
                q.MdiParent = this.MdiParent;
                q.Show();
                this.Dispose();
            }
        }
    }
}
