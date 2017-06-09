using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SBM.Business;
using SBM.Core;

namespace MainApplication
{
    public partial class Providers : FormValidated
    {
        #region Properties
        private bool newProvider = true;
        private Provider selectedProvider;
        private ProviderController providerController;

        #endregion

        public Providers()
        {
            errorProvider = new ErrorProvider(this);
            InitializeComponent();
            providerController = new ProviderController();
            dgvProviders.DataSource = providerController.GetAll();
        }

        #region Particular Methods
        private void CleanForm()
        {
            txtProviderAddress.Text = string.Empty;
            txtProviderEmail.Text = string.Empty;
            txtProviderName.Text = string.Empty;
            txtProviderPhone.Text = string.Empty;
            newProvider = true;
            txtContactAddress.Text = string.Empty;
            txtContactEmail.Text = string.Empty;
            txtContactName.Text = string.Empty;
            txtContactPhone.Text = string.Empty;
            ClearErrors(Controls);
            ClearErrors(gbContact.Controls);
            btnProviderErase.Enabled = false;
        }

        private void LoadForm()
        {
            txtProviderAddress.Text = selectedProvider.Address;
            txtProviderEmail.Text = selectedProvider.Email;
            txtProviderName.Text = selectedProvider.Name;
            txtProviderPhone.Text = selectedProvider.Phone;
            this.newProvider = false;
            txtContactAddress.Text = selectedProvider.Contact.Address;
            txtContactEmail.Text = selectedProvider.Contact.Email;
            txtContactName.Text = selectedProvider.Contact.Name;
            txtContactPhone.Text = selectedProvider.Contact.Phone;
            btnProviderErase.Enabled = true;
        }

        #endregion

        #region Data Interaction
        private void dgvProviders_SelectionChanged(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvProviders.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                selectedProvider = (Provider)dgvProviders.SelectedRows[0].DataBoundItem;
                LoadForm();
            }
            else
                selectedProvider = null;
        }

        private void dgvProviders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProviders.ClearSelection();
            CleanForm();
        }

        #endregion

        #region Button Clicks
        private void btnProviderSave_Click(object sender, EventArgs e)
        {
            if(!IsValid(Controls))
                return;
            if(!IsValid(gbContact.Controls))
                return;

            BasicEntity contact = new BasicEntity(txtContactName.Text, txtContactPhone.Text, txtContactAddress.Text, txtContactEmail.Text);
            if (newProvider)
                providerController.Create(txtProviderName.Text, txtProviderPhone.Text, txtProviderAddress.Text, txtProviderEmail.Text, contact);
            else
            {
                selectedProvider.Name = txtProviderName.Text.Trim();
                selectedProvider.Phone = txtProviderPhone.Text.Trim();
                selectedProvider.Address = txtProviderAddress.Text.Trim();
                selectedProvider.Email = txtProviderEmail.Text.Trim();
                selectedProvider.Contact = contact;
                providerController.SaveOrUpdate(selectedProvider);
            }
            dgvProviders.DataSource = providerController.GetAll();
            CleanForm();
        }
        
        private void btnProviderErase_Click(object sender, EventArgs e)
        {
            providerController.Erase(selectedProvider);
            selectedProvider = null;
            dgvProviders.DataSource = providerController.GetAll();
        }

        private void btnProviderClean_Click(object sender, EventArgs e)
        {
            CleanForm();
        }

        #endregion

        #region Validations
        private void txtProviderName_Validating(object sender, CancelEventArgs e)
        {
            Validation_Required(txtProviderName, "Nombre requerido");
        }

        private void txtProviderPhone_Validating(object sender, CancelEventArgs e)
        {
            Validation_Number(txtProviderPhone, "Ingrese solo numeros");
        }

        private void txtContactPhone_Validating(object sender, CancelEventArgs e)
        {
            Validation_NumberVinculated(txtContactPhone, "Ingrese solo numeros", txtContactName, "Ingrese un nombre");
        }

        private void txtProviderEmail_Validating(object sender, CancelEventArgs e)
        {
            Validation_Email(txtProviderEmail, "Email invalido");
        }

        private void txtContactEmail_Validating(object sender, CancelEventArgs e)
        {
            Validation_EmailVinculated(txtContactEmail, "Email invalido", txtContactName, "Ingrese un nombre");
        }
        #endregion

        
    }
}
