using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SBM.Business;
using SBM.Core;

namespace MainApplication
{
    public partial class Parts : FormValidated
    {
        #region Properties
        private PartController partController;
        private ProviderController providerController;
        private PartByProviderController partByProviderController;
        private bool newPart = true;
        private Part selectedPart;

        #endregion

        public Parts()
        {
            errorProvider = new ErrorProvider(this);
            InitializeComponent();
            partController = new PartController();
            providerController = new ProviderController();
            partByProviderController = new PartByProviderController();
            dgvParts.DataSource = partController.GetAll();
            lbProviders.DataSource = providerController.GetAll();
            lbProviders.ClearSelected();
        }

        #region Particular Methods
        private void ClearPartData()
        {
            txtPartName.Text = string.Empty;
            txtPartPrice.Text = string.Empty;
            txtPartQuantity.Text = string.Empty;
            newPart = true;
            txtPartName.Focus();
            nudDecrease.Value = 0;
            nudIncrease.Value = 0;
            ClearErrors(Controls);
            btnPartErase.Enabled = false;
        }

        private void GetSelectedPart()
        {
            selectedPart = null;
            Int32 selectedRowCount = dgvParts.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
                selectedPart = (Part)dgvParts.SelectedRows[0].DataBoundItem;
        }

        private void LoadPartData()
        {
            txtPartName.Text = selectedPart.Name;
            txtPartPrice.Text = selectedPart.AveragePrice.ToString();
            txtPartQuantity.Text = selectedPart.StockQuantity.ToString();
            newPart = false;

            selectedPart.PartByProviders = partByProviderController.GetFor(selectedPart);

            lbProviders.DataSource = providerController.GetAll();
            lbProviders.ClearSelected();

            List<int> selectedIndex = new List<int>();
            int i = 0;
            foreach (Provider item in lbProviders.Items)
            {
                if (selectedPart.PartByProviders.Exists(e => e.Provider.Id.Equals(item.Id)))
                    selectedIndex.Add(i);
                i++;
            }
            
            foreach (int index in selectedIndex)
                lbProviders.SetSelected(index, true);    

            ClearErrors(Controls);
            btnPartErase.Enabled = true;
        }
        
        #endregion

        #region Data Interaction
        private void dgvParts_SelectionChanged(object sender, EventArgs e)
        {
            GetSelectedPart();
            if (selectedPart != null)
                LoadPartData();
            else
                ClearPartData();
        }

        private void txtPartName_TextChanged(object sender, EventArgs e)
        {
            if (newPart)
                txtPartQuantity.Text = 0.ToString();
            gbProviders.Enabled = !string.IsNullOrEmpty(txtPartName.Text) && !string.IsNullOrEmpty(txtPartPrice.Text);
        }

        private void txtPartPrice_TextChanged(object sender, EventArgs e)
        {
            if (newPart)
                txtPartQuantity.Text = 0.ToString();
            gbProviders.Enabled = !string.IsNullOrEmpty(txtPartName.Text) && !string.IsNullOrEmpty(txtPartPrice.Text);
        }

        private void nudIncrease_ValueChanged(object sender, EventArgs e)
        {
            if (nudIncrease.Value > 0)
                nudDecrease.Value = 0;
        }

        private void nudDecrease_ValueChanged(object sender, EventArgs e)
        {
            if (nudDecrease.Value > 0)
                nudIncrease.Value = 0;
        }

        private void dgvParts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvParts.ClearSelection();
        }

        #endregion

        #region Button Clicks
        private void btnPartSave_Click(object sender, EventArgs e)
        {
            if (!IsValid(Controls))
                return;

            if (newPart)
                selectedPart = partController.Create(txtPartName.Text.Trim(), Convert.ToDecimal(txtPartPrice.Text.Trim()));
            else
            {
                selectedPart.Name = txtPartName.Text.Trim();
                selectedPart.AveragePrice = Convert.ToDecimal(txtPartPrice.Text.Trim());
                partController.SaveOrUpdate(selectedPart);
                
            }

            partByProviderController.EraseFor(selectedPart);
            foreach (Provider provider in lbProviders.SelectedItems)
                partByProviderController.Create(selectedPart, provider, Convert.ToDecimal(txtPartPrice.Text));
            
            dgvParts.DataSource = partController.GetAll();
            ClearPartData();
        }

        private void btnPartClean_Click(object sender, EventArgs e)
        {
            ClearPartData();
        }

        private void btnPartErase_Click(object sender, EventArgs e)
        {
            partController.Erase(selectedPart);
            selectedPart = null;
            dgvParts.DataSource = partController.GetAll();
        }

        private void btnPartAddStock_Click(object sender, EventArgs e)
        {
            if (nudIncrease.Value > 0)
                partController.IncreaseStock(selectedPart, Convert.ToInt32(nudIncrease.Value));
            else if (nudDecrease.Value > 0)
                partController.DecreaseStock(selectedPart, Convert.ToInt32(nudDecrease.Value));
            dgvParts.DataSource = partController.GetAll();
        }

        #endregion

        #region Validations
        private void txtPartName_Validating(object sender, CancelEventArgs e)
        {
            Validation_Required(txtPartName, "Nombre requerido");
        }

        private void txtPartPrice_Validating(object sender, CancelEventArgs e)
        {
            Validation_PriceRequired(txtPartPrice, "Precio requerido", "Ingrese solo numeros");
        }

        #endregion

        
        
    }
}
