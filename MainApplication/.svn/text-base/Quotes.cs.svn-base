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
    public partial class Quotes : Form
    {
        #region Properties
        private CustomerController customerController;
        private QuoteController quoteController;
        private ProductController productController;
        private SubProductController subProductController;
        private SubProductForTransactionController subProductForTransactionController;
        private SaleController saleController;
        private ErrorProvider errorProvider;
        private Customer selectedCustomer;
        private Product selectedProduct;
        private SubProduct selectedSubProduct;
        private SubProductForTransaction selectedSubProductForTransaction;
        private Quote quote;
        decimal total = 0;

        #endregion

        public Quotes()
        {
            InitializeQuotes();
        }

        private void InitializeQuotes()
        {
            errorProvider = new ErrorProvider(this);
            InitializeComponent();
            customerController = new CustomerController();
            quoteController = new QuoteController();
            productController = new ProductController();
            subProductController = new SubProductController();
            subProductForTransactionController = new SubProductForTransactionController();
            saleController = new SaleController();
            txtValidTo.Text = DateTime.Now.AddDays(30).ToShortDateString();
        }

        public Quotes(Quote q)
        {
            InitializeQuotes();
            quote = q;
            LoadQuoteData();
        }

        #region Particular Methods
        private void LoadQuoteData()
        {
            if (quote.Locked)
            {
                txtValidTo.Text = quote.ValidTo.ToShortDateString();
                txtProduct.Enabled = false;
            }
            else
                txtValidTo.Text = DateTime.Now.AddDays(30).ToShortDateString();
            btnSell.Enabled = !quote.Selled;
            gbCustomer.Enabled = false;
            selectedCustomer = quote.Customer;
            txtCustomer.Text = quote.Customer.Name + " \"" + quote.Customer.NickName + "\" " + quote.Customer.LastName;
            LoadCustomerData();
            
            LoadQuoteItems();
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
            btnSaveAndSend.Enabled = false;
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
            Int32 selectedRowCount = dgvQuoteItems.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
                selectedSubProductForTransaction = (SubProductForTransaction)dgvQuoteItems.SelectedRows[0].DataBoundItem;
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
            if(quote.Locked)
                return;
            selectedSubProductForTransaction.Quantity++;
            subProductForTransactionController.SaveOrUpdate(selectedSubProductForTransaction);
            LoadQuoteItems();
        }

        private void DecreaseItemQuantity()
        {
            if (quote.Locked)
                return;
            selectedSubProductForTransaction.Quantity--;
            if(selectedSubProductForTransaction.Quantity > 0)
                subProductForTransactionController.SaveOrUpdate(selectedSubProductForTransaction);
            else
                subProductForTransactionController.Erase(selectedSubProductForTransaction);
            LoadQuoteItems();
        }

        private void LoadQuoteItems()
        {
            total = 0;
            quote.SubProductsForTransactions = subProductForTransactionController.GetFor(quote);
            dgvQuoteItems.DataSource = quote.SubProductsForTransactions;
            UpdateSubTotals();
            quote.Total = total;
            quoteController.SaveOrUpdate(quote);
            txtQuoteTotal.Text = total.ToString("$#,##0.00");
            if(quote.SubProductsForTransactions.Count > 0)
            {
                btnSell.Enabled = true;
                btnSaveAndSend.Enabled = !string.IsNullOrEmpty(selectedCustomer.Email);
            }
            else
            {
                btnSell.Enabled = false;
                btnSaveAndSend.Enabled = false;
            }
        }

        private void UpdateSubTotals()
        {
            foreach (DataGridViewRow row in dgvQuoteItems.Rows)
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
            if(string.IsNullOrEmpty(txtCustomer.Text))
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
            if(selectedProduct != null)
                lstSubProduct.DataSource = subProductController.GetAllFor(selectedProduct);
        }

        private void lstSubProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedSubProduct();
            btnAddProduct.Enabled = true;
        }

        private void dgvQuoteItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvQuoteItems.ClearSelection();
        }

        private void dgvQuoteItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedSubProductForTransaction = (SubProductForTransaction)dgvQuoteItems.Rows[e.RowIndex].DataBoundItem;
            if (e.ColumnIndex == 1)
                IncreaseItemQuantity();
            else if (e.ColumnIndex == 3)
                DecreaseItemQuantity();
        }

        #endregion

        #region Button Clicks
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if(quote == null)
                quote = quoteController.Create(selectedCustomer, DateTime.Today.AddDays(15));
            subProductForTransactionController.Create(selectedSubProduct, quote);
            LoadQuoteItems();
            txtProduct.Text = string.Empty;
            txtProduct.Focus();
        }

        private void btnSaveAndSend_Click(object sender, EventArgs e)
        {
            //TODO:Hacer que envie por mail
            quote.Lock();
            quoteController.SaveOrUpdate(quote);
            MessageBox.Show("La cotización ha sido enviada y bloqueada de futuras modificaciones.");
            Statistics s = new Statistics();
            s.MdiParent = this.MdiParent;
            s.Show();
            this.Dispose();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            quote.Lock();
            quote.Selled = true;
            quoteController.SaveOrUpdate(quote);
            Sale sale = saleController.Create(quote);
            foreach (SubProductForTransaction subProductForTransaction in quote.SubProductsForTransactions)
            {
                SubProductForTransaction item = subProductForTransactionController.Create(subProductForTransaction.SubProduct, sale);
                item.Quantity = subProductForTransaction.Quantity;
                item.UnitPrice = subProductForTransaction.UnitPrice;
                subProductForTransactionController.SaveOrUpdate(item);
            }
            MessageBox.Show(string.Format("Se ha creado una venta para {0} \"{1}\" {2} con los datos de esta cotización.", selectedCustomer.Name, selectedCustomer.NickName, selectedCustomer.LastName));
            Sales s = new Sales(sale);
            s.MdiParent = this.MdiParent;
            s.Show();
            this.Dispose();
        }

        #endregion
        
        #region Validations

        #endregion
    }
}
