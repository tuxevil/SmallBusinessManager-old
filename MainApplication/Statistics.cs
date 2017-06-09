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
    public partial class Statistics : Form
    {
        private StatisticController statisticController;
        private QuoteController quoteController;
        private SaleController saleController;
        private CustomerController customerController;

        public Statistics()
        {
            InitializeComponent();
            quoteController = new QuoteController();
            saleController = new SaleController();
            customerController = new CustomerController();
            statisticController = new StatisticController();
            LoadStatisticalData();
        }

        private void LoadStatisticalData()
        {
            chQuotesAndSales.Series.Add(statisticController.GetStatisticalData(quoteController.GetAll()));
            chQuotesAndSales.Series.Add(statisticController.GetStatisticalData(saleController.GetAll()));
            chNewCustomers.Series.Add(statisticController.GetStatisticalData(customerController.GetAll()));
        }
    }
}
