using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using SBM.Business;

namespace MainApplication
{
    public partial class Admin : Form
    {
        private MainController mainController;

        public Admin()
        {
            InitializeComponent();
            mainController = new MainController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseController baseController = new BaseController();
            baseController.className = comboBox1.Text;
            baseController.LoadDecryptedFile();
            baseController.Save();
        }

        private void btnGetLicenced_Click(object sender, EventArgs e)
        {
            RegistryKey regKeyAppRoot = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography");
            string strWindowsState = (string)regKeyAppRoot.GetValue("MachineGuid");
            txtMachineGuid.Text = strWindowsState;

            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(strWindowsState);
            data = x.ComputeHash(data);
            string ret = "";
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            txtClientHash.Text = ret;

            Guid g = new Guid(ret);
            txtServerGuid.Text = g.ToString();

            data = System.Text.Encoding.ASCII.GetBytes(g.ToString());
            data = x.ComputeHash(data);
            ret = "";
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            txtServerHash.Text = ret;
        }

        private void btnGetAppData_Click(object sender, EventArgs e)
        {
            txtLicense.Text = mainController.License;
            txtInstalationDate.Text = mainController.InstalationDate.ToString("yyyyMMdd");
            txtLastDate.Text = mainController.LastDateOpened.ToString("yyyyMMdd");
            txtRunTimes.Text = mainController.StartedTimes.ToString();
        }

        private void btnSaveAppData_Click(object sender, EventArgs e)
        {
            mainController.License = txtLicense.Text;
            mainController.InstalationDate = DateTime.ParseExact(txtInstalationDate.Text, "yyyyMMdd", CultureInfo.InvariantCulture);
            mainController.LastDateOpened = DateTime.ParseExact(txtLastDate.Text, "yyyyMMdd", CultureInfo.InvariantCulture);
            mainController.StartedTimes = Convert.ToInt32(txtRunTimes.Text);
        }

    }
}
