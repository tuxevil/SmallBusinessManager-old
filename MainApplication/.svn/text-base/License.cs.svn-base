using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SBM.Business;

namespace MainApplication
{
    public partial class License : Form
    {
        private MainController mainController;
        private MainScreen mainScreen;

        public License(MainScreen mainScreen)
        {
            InitializeComponent();
            mainController = new MainController();
            this.mainScreen = mainScreen;
        }

        private void License_Load(object sender, EventArgs e)
        {
            if(mainController.HasValidLicense)
                txtInfo.Text = string.Format("Su licencia es valida y ahora puede disfrutar de toda la funcionalidad de la aplicación. Gracias.");
            else
                txtInfo.Text = string.Format("Todavia no cuenta con la licencia necesaria para poder utilizar libremente esta aplicación.\r\nLe quedan {0} dias o {1} ejecuciones restantes del programa .Para mas informacion pongase en contacto con info@realware.com.ar\r\nO si esta al tanto y de acuerdo con los precios y condiciones, envie el siguiente codigo a license@realware.com.ar\r\n\r\n{2}\r\n\r\nLe enviaremos su codigo de activación a la brevedad posible.\r\nGracias.", mainController.DaysLeft, mainController.RunsLeft, mainController.GetClientLicenseCode());
                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!mainController.HasValidLicense && (mainController.DaysLeft < 0 || mainController.RunsLeft < 0))
                mainScreen.HasValidLicense = false;
            this.Dispose();
        }

        private void txtVerificationCode_TextChanged(object sender, EventArgs e)
        {
            if (txtVerificationCode.Text.Trim() == mainController.GetVerificationCode())
            {
                mainController.License = txtVerificationCode.Text;
                cbValid.Checked = true;
                txtInfo.Text = "Su licencia es valida y ahora puede disfrutar de toda la funcionalidad de la aplicación. Gracias.";
            }

        }
   }
}
