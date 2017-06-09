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
    public partial class Customers : FormValidated
    {
        #region Properties
        private bool newUser = true;
        private Customer selectedCustomer;
        private CustomerController customerController;
        private QuoteController quoteController;
        private SaleController saleController;

        #endregion

        public Customers()
        {
            errorProvider = new ErrorProvider(this);
            InitializeComponent();
            customerController = new CustomerController();
            quoteController = new QuoteController();
            saleController = new SaleController();
            dgvCustomers.DataSource = customerController.GetAllActive();
        }

        #region Particular Methods
        private void CleanForm()
        {
            txtCustomerAddress.Text = string.Empty;
            txtCustomerEmail.Text = string.Empty;
            txtCustomerLastName.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerNickName.Text = string.Empty;
            txtCustomerPhone.Text = string.Empty;
            newUser = true;
            btnCustomerErase.Enabled = false;
            ClearErrors(Controls);
            dgvCustomerQuotes.DataSource = new List<Quote>();
            dgvCustomerSales.DataSource = new List<Sale>();
        }

        private void LoadForm()
        {
            txtCustomerAddress.Text = selectedCustomer.Address;
            txtCustomerEmail.Text = selectedCustomer.Email;
            txtCustomerLastName.Text = selectedCustomer.LastName;
            txtCustomerName.Text = selectedCustomer.Name;
            txtCustomerNickName.Text = selectedCustomer.NickName;
            txtCustomerPhone.Text = selectedCustomer.Phone;
            this.newUser = false;
            btnCustomerErase.Enabled = true;
            dgvCustomerQuotes.DataSource = quoteController.Get(selectedCustomer.Id.ToString());
            dgvCustomerSales.DataSource = saleController.Get(selectedCustomer.Id.ToString());
        }

        #endregion

        #region Data Interaction
        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            selectedCustomer = null;
            Int32 selectedRowCount = dgvCustomers.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                selectedCustomer = (Customer)dgvCustomers.SelectedRows[0].DataBoundItem;
                LoadForm();
            }
        }

        private void dgvCustomers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCustomers.ClearSelection();
            CleanForm();
        }

        private void dgvCustomerQuotes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCustomerQuotes.ClearSelection();
        }

        private void dgvCustomerSales_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCustomerSales.ClearSelection();
        }

        private void dgvCustomerQuotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                Quotes q = new Quotes((Quote)dgvCustomerQuotes.Rows[e.RowIndex].DataBoundItem);
                q.MdiParent = this.MdiParent;
                q.Show();
                this.Dispose();
            }
        }

        private void dgvCustomerSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                Sales q = new Sales((Sale)dgvCustomerSales.Rows[e.RowIndex].DataBoundItem);
                q.MdiParent = this.MdiParent;
                q.Show();
                this.Dispose();
            }
        }

        #endregion

        #region Button Clicks
        private void btnCustomerSave_Click(object sender, EventArgs e)
        {
            if (!IsValid(Controls))
                return;
            
            if(newUser)
                customerController.Create(txtCustomerName.Text.Trim(), txtCustomerLastName.Text.Trim(), txtCustomerNickName.Text.Trim(), txtCustomerPhone.Text.Trim(), txtCustomerAddress.Text.Trim(), txtCustomerEmail.Text.Trim());
            else
            {
                selectedCustomer.Name = txtCustomerName.Text.Trim();
                selectedCustomer.NickName = txtCustomerNickName.Text.Trim();
                selectedCustomer.LastName = txtCustomerLastName.Text.Trim();
                selectedCustomer.Phone = txtCustomerPhone.Text.Trim();
                selectedCustomer.Address = txtCustomerAddress.Text.Trim();
                selectedCustomer.Email = txtCustomerEmail.Text.Trim();
                customerController.SaveOrUpdate(selectedCustomer);
            }
            dgvCustomers.DataSource = customerController.GetAllActive();
            CleanForm();
        }
        
        private void btnCustomerClean_Click(object sender, EventArgs e)
        {
            CleanForm();
        }
        
        private void btnCustomerErase_Click(object sender, EventArgs e)
        {
            customerController.Erase(selectedCustomer);
            selectedCustomer = null;
            dgvCustomers.DataSource = customerController.GetAllActive();
        }

        #endregion

        #region Validations
        private void txtCustomerNickName_Validating(object sender, CancelEventArgs e)
        {
            Validation_Required(txtCustomerNickName, "Apodo requerido");
        }

        private void txtCustomerPhone_Validating(object sender, CancelEventArgs e)
        {
            Validation_Number(txtCustomerPhone, "Ingrese solo numeros");
        }

        private void txtCustomerEmail_Validating(object sender, CancelEventArgs e)
        {
            Validation_Email(txtCustomerEmail, "Email invalido");
        }

        #endregion

        
        
    }
}
