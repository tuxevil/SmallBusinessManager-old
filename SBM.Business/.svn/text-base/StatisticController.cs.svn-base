using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using SBM.Core;

namespace SBM.Business
{
    public class StatisticController
    {
        #region Statistical Data
        public Series GetStatisticalData(List<Quote> lst)
        {
            Series statisticData = new Series("Cotizaciones por Meses");
            statisticData.IsXValueIndexed = true;
            int initialYear = DateTime.Now.AddYears(-1).Year;
            int initialMonth = DateTime.Now.AddMonths(-11).Month;

            for (int i = 1; i <= 12; i++)
            {
                statisticData.Points.Add(new DataPoint(initialMonth, lst.FindAll(e => e.ModificationDate.Year == initialYear && e.ModificationDate.Month == initialMonth).Count));
                initialMonth++;
                if (initialMonth == 13)
                {
                    initialMonth = 1;
                    initialYear++;
                }
            }
            return statisticData;
        }

        public Series GetStatisticalData(List<Sale> lst)
        {
            Series statisticData = new Series("Ventas por Meses");
            statisticData.IsXValueIndexed = true;
            int initialYear = DateTime.Now.AddYears(-1).Year;
            int initialMonth = DateTime.Now.AddMonths(-11).Month;

            for (int i = 1; i <= 12; i++)
            {
                statisticData.Points.Add(new DataPoint(initialMonth, lst.FindAll(e => e.ModificationDate.Year == initialYear && e.ModificationDate.Month == initialMonth && e.Locked).Count));
                initialMonth++;
                if (initialMonth == 13)
                {
                    initialMonth = 1;
                    initialYear++;
                }
            }
            return statisticData;
        }

        public Series GetStatisticalData(List<Customer> lst)
        {
            Series statisticData = new Series("Clientes nuevos por Meses");
            statisticData.IsXValueIndexed = true;
            int initialYear = DateTime.Now.AddYears(-1).Year;
            int initialMonth = DateTime.Now.AddMonths(-11).Month;

            for (int i = 1; i <= 12; i++)
            {
                statisticData.Points.Add(new DataPoint(initialMonth, lst.FindAll(e => e.CreationDate.Year == initialYear && e.CreationDate.Month == initialMonth).Count));
                initialMonth++;
                if (initialMonth == 13)
                {
                    initialMonth = 1;
                    initialYear++;
                }
            }
            return statisticData;
        }

        #endregion
    }
}
