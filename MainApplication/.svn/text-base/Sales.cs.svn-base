using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SBM.Business;
using SBM.Core;

namespace MainApplication
{
    public partial class Sales : Form
    {
        #region Properties
        private CustomerController customerController;
        private SaleController saleController;
        private ProductController productController;
        private SubProductController subProductController;
        private SubProductForTransactionController subProductForTransactionController;
        private ErrorProvider errorProvider;
        private Customer selectedCustomer;
        private Product selectedProduct;
        private SubProduct selectedSubProduct;
        private SubProductForTransaction selectedSubProductForTransaction;
        private Sale sale;
        decimal total = 0;

        #endregion

        public Sales()
        {
            InitializeSales();
        }

        public Sales(Sale s)
        {
            InitializeSales();
            sale = s;
            LoadSaleData();
        }

        private void InitializeSales()
        {
            errorProvider = new ErrorProvider(this);
            InitializeComponent();
            customerController = new CustomerController();
            saleController = new SaleController();
            productController = new ProductController();
            subProductController = new SubProductController();
            subProductForTransactionController = new SubProductForTransactionController();
        }

        #region Particular Methods
        private void LoadSaleData()
        {
            if (sale.Locked)
                txtProduct.Enabled = false;
            gbCustomer.Enabled = false;
            selectedCustomer = sale.Customer;
            txtCustomer.Text = sale.Customer.Name + " \"" + sale.Customer.NickName + "\" " + sale.Customer.LastName;
            LoadCustomerData();
            LoadSaleItems();
            btnReady.Enabled = !sale.Locked;
        }

        private void LoadCustomerData()
        {
            lblCustomerName.Text = string.Format("{0} \"{1}\" {2}", selectedCustomer.Name, selectedCustomer.NickName, selectedCustomer.LastName);
            lblCustomerAddress.Text = selectedCustomer.Address;
            lblCustomerPhone.Text = selectedCustomer.Phone;
            lblCustomerEmail.Text = selectedCustomer.Email;
            gbProducts.Enabled = true;
        }

        private void ClearCustomer()
        {
            string na = "N/A";
            lblCustomerName.Text = na;
            lblCustomerEmail.Text = na;
            lblCustomerAddress.Text = na;
            lblCustomerPhone.Text = na;
            gbProducts.Enabled = false;
        }

        private void GetSelectedCustomer()
        {
            selectedCustomer = null;
            Int32 selectedRowCount = dgvCustomers.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
                selectedCustomer = (Customer)dgvCustomers.SelectedRows[0].DataBoundItem;
        }

        private void GetSelectedSubProductForTransaction()
        {
            selectedSubProductForTransaction = null;
            Int32 selectedRowCount = dgvSaleItems.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
                selectedSubProductForTransaction = (SubProductForTransaction)dgvSaleItems.SelectedRows[0].DataBoundItem;
        }

        private void GetSelectedProduct()
        {
            selectedProduct = null;
            selectedProduct = (Product)lstProduct.SelectedItem;
        }

        private void GetSelectedSubProduct()
        {
            selectedSubProduct = null;
            selectedSubProduct = (SubProduct)lstSubProduct.SelectedItem;
        }

        private void IncreaseItemQuantity()
        {
            if (sale.Locked)
                return;
            selectedSubProductForTransaction.Quantity++;
            subProductForTransactionController.SaveOrUpdate(selectedSubProductForTransaction);
            LoadSaleItems();
        }

        private void DecreaseItemQuantity()
        {
            if (sale.Locked)
                return;
            selectedSubProductForTransaction.Quantity--;
            if (selectedSubProductForTransaction.Quantity > 0)
                subProductForTransactionController.SaveOrUpdate(selectedSubProductForTransaction);
            else
                subProductForTransactionController.Erase(selectedSubProductForTransaction);
            LoadSaleItems();
        }

        private void LoadSaleItems()
        {
            total = 0;
            dgvSaleItems.DataSource = subProductForTransactionController.GetFor(sale);
            UpdateSubTotals();
            sale.Total = total;
            saleController.SaveOrUpdate(sale);
            txtQuoteTotal.Text = total.ToString("$#,##0.00");
        }

        private void UpdateSubTotals()
        {
            foreach (DataGridViewRow row in dgvSaleItems.Rows)
            {
                SubProductForTransaction spft = (SubProductForTransaction)row.DataBoundItem;
                row.Cells[5].Value = spft.Quantity * spft.UnitPrice;
                total += spft.Quantity * spft.UnitPrice;
            }
        }

        #endregion

        #region Data Interaction
        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            GetSelectedCustomer();
            if (selectedCustomer != null)
                LoadCustomerData();
            else
                ClearCustomer();
        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomer.Text))
            {
                dgvCustomers.DataSource = new List<Customer>();
                ClearCustomer();
            }
            else dgvCustomers.DataSource = customerController.Get(txtCustomer.Text);
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProduct.Text))
            {
                lstProduct.DataSource = new List<Product>();
                lstSubProduct.DataSource = new List<SubProduct>();
                btnAddProduct.Enabled = false;
            }
            else lstProduct.DataSource = productController.Get(txtProduct.Text);
        }

        private void lstProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedProduct();
            if (selectedProduct != null)
                lstSubProduct.DataSource = subProductController.GetAllFor(selectedProduct);
        }

        private void lstSubProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedSubProduct();
            btnAddProduct.Enabled = true;
        }

        private void dgvSaleItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSaleItems.ClearSelection();
        }

        private void dgvSaleItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedSubProductForTransaction = (SubProductForTransaction)dgvSaleItems.Rows[e.RowIndex].DataBoundItem;
            if (e.ColumnIndex == 1)
                IncreaseItemQuantity();
            else if (e.ColumnIndex == 3)
                DecreaseItemQuantity();
        }

        #endregion

        #region Button Clicks
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (sale == null)
                sale = saleController.Create(selectedCustomer);
            subProductForTransactionController.Create(selectedSubProduct, sale);
            LoadSaleItems();
            txtProduct.Text = string.Empty;
            txtProduct.Focus();
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            //TODO:Hacer que envie por mail
            sale.Lock();
            sale.SaleDate = DateTime.Now;
            saleController.SaveOrUpdate(sale);
            MessageBox.Show("La venta ha sido guardada y bloqueada de futuras modificaciones.");
            Statistics s = new Statistics();
            s.MdiParent = this.MdiParent;
            s.Show();
            this.Dispose();
        }

        #endregion
    }
}
