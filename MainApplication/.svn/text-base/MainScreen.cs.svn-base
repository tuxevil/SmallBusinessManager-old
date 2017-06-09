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
    public partial class MainScreen : Form
    {
        public bool HasValidLicense = true;

        public MainScreen()
        {
            InitializeComponent();
            MainController mainController = new MainController();
            mainController.StartedTimes++;

            if (!mainController.HasValidLicense)
            {
                if (mainController.DaysLeft >= 0 && mainController.RunsLeft >= 0)
                {
                    if (DateTime.Now >= mainController.LastDateOpened)
                        mainController.LastDateOpened = DateTime.Today;
                    else
                    {
                        MessageBox.Show(string.Format("Se ha detectado un intento de violación del periodo de prueba provisto de forma gratuita con este sistema.\r\nEsta aplicacion tomo su tiempo y trabajo para poder brindarle a usted una herramienta para un mejor control y desempeño en sus negocios.\r\nEn consecuencia de dicho suceso su información sera eliminada ya que usted no posee concideración hacia el verdadero valor del trabajo.\r\nMucha suerte y cualquier queja o duda no dude en comunicarse con\r\nquejas@realware.com.ar"));
                        MessageBox.Show("No se asuste, todo el cuento de la eliminacion de la informacion es mentira\r\nPero no va a poder acceder a la misma si no adquiere la licencia respectiva.");
                    }
                }
                else
                    MessageBox.Show("Su periodo de pruebas ha concluido.\r\nSi desea seguir utilizando Small Business Manager comuniquese con\r\ninfo@realware.com.ar");

                License l = new License(this);
                l.ShowDialog();
            }
            Statistics s = new Statistics();
            s.MdiParent = this;
            s.Show();
            return;
        }

        private void CloseChildrens()
        {
            foreach (Form child in this.MdiChildren)
                child.Dispose();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseChildrens();
            if (!HasValidLicense)
                this.Close();
            else
            {
                Quotes q = new Quotes();
                q.MdiParent = this;
                q.Show();
            }
            
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseChildrens();
            if (!HasValidLicense)
                this.Close();
            else
            {
                Sales s = new Sales();
                s.MdiParent = this;
                s.Show();
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseChildrens();
            if (!HasValidLicense)
                this.Close();
            else
            {
                Customers c = new Customers();
                c.MdiParent = this;
                c.Show();
            }
        }

        private void producToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseChildrens();
            if (!HasValidLicense)
                this.Close();
            else
            {
                Providers p = new Providers();
                p.MdiParent = this;
                p.Show();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }

        private void consultarModificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseChildrens();
            if (!HasValidLicense)
                this.Close();
            else
            {
                QuoteStats qs = new QuoteStats();
                qs.MdiParent = this;
                qs.Show();
            }
        }

        private void consultarModificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseChildrens();
            if (!HasValidLicense)
                this.Close();
            else
            {
                SaleStats ss = new SaleStats();
                ss.MdiParent = this;
                ss.Show();
            }
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseChildrens();
            if (!HasValidLicense)
                this.Close();
            else
            {
                Statistics s = new Statistics();
                s.MdiParent = this;
                s.Show();
            }
        }

        private void licenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            License l = new License(this);
            l.ShowDialog();
        }

        private void componentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseChildrens();
            if (!HasValidLicense)
                this.Close();
            else
            {
                Parts p = new Parts();
                p.MdiParent = this;
                p.Show();
            }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseChildrens();
            if (!HasValidLicense)
                this.Close();
            else
            {
                Products p = new Products();
                p.MdiParent = this;
                p.Show();
            }
        }

        private void cargarBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> classes = new List<string>();
            classes.Add("Customer");
            classes.Add("Part");
            classes.Add("PartByProvider");
            classes.Add("PartForSubProduct");
            classes.Add("Product");
            classes.Add("Provider");
            classes.Add("Quote");
            classes.Add("Sale");
            //classes.Add("Stat");
            classes.Add("SubProduct");
            classes.Add("SubProductForTransaction");

            foreach (string s in classes)
            {
                BaseController baseController = new BaseController();
                baseController.className = s;
                baseController.LoadDecryptedFile();
                baseController.Save();
            }
        }

        private void enviarBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> classes = new List<string>();
            classes.Add("Customer");
            classes.Add("Part");
            classes.Add("PartByProvider");
            classes.Add("PartForSubProduct");
            classes.Add("Product");
            classes.Add("Provider");
            classes.Add("Quote");
            classes.Add("Sale");
            //classes.Add("Stat");
            classes.Add("SubProduct");
            classes.Add("SubProductForTransaction");

            foreach (string s in classes)
            {
                BaseController baseController = new BaseController();
                baseController.className = s;
                baseController.SaveDecryptedFile();
            }
        }
    }
}
