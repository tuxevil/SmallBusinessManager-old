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
    public partial class Products : FormValidated
    {
        #region Properties
        private ProductController productController;
        private SubProductController subProductController;
        private PartController partController;
        private PartForSubProductController partForSubProductController;
        private bool newProduct = true;
        //private Guid productId;
        private Product selectedProduct;
        private bool newSubProduct = true;
        //private Guid subProductId;
        private SubProduct selectedSubProduct;
        private Part selectedPart;
        private PartForSubProduct selectedPartForSubProduct;

        #endregion

        public Products()
        {
            errorProvider = new ErrorProvider(this);
            InitializeComponent();
            productController = new ProductController();
            subProductController = new SubProductController();
            partController = new PartController();
            partForSubProductController = new PartForSubProductController();
            dgvProducts.DataSource = productController.GetAll();
            cbParts.DataSource = partController.GetAll();
        }

        #region Particular Methods
        private void ClearProductData()
        {
            txtProductDescription.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductPrice.Text = string.Empty;
            txtProductPriceFinal.Text = string.Empty;
            txtProductStockQuantity.Text = string.Empty;
            newProduct = true;
            txtProductName.Focus();
            //ClearSubProductData();
            gbSubProduct.Enabled = false;
            gbSubProductList.Enabled = false;
            dgvProducts.ClearSelection();
            ClearSubProductData();
            ClearErrors(gbProduct.Controls);
            btnProductErase.Enabled = false;
        }

        private void ClearSubProductData()
        {
            txtSubProductName.Text = string.Empty;
            txtSubProductStockQuantity.Text = string.Empty;
            newSubProduct = true;
            gbPart.Enabled = false;
            gbPartList.Enabled = false;
            txtSubProductName.Focus();
            dgvSubProducts.ClearSelection();
            dgvParts.ClearSelection();
            ClearErrors(gbSubProduct.Controls);
            btnSubProductErase.Enabled = false;
        }

        private void GetSelectedProduct()
        {
            selectedProduct = null;
            Int32 selectedRowCount = dgvProducts.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
                selectedProduct = (Product)dgvProducts.SelectedRows[0].DataBoundItem;
        }

        private void LoadProductData()
        {
            txtProductDescription.Text = selectedProduct.Description;
            txtProductName.Text = selectedProduct.Name;
            txtProductPrice.Text = selectedProduct.Price.ToString();
            txtProductPriceFinal.Text = selectedProduct.FinalPrice.ToString();
            txtProductStockQuantity.Text = selectedProduct.StockQuantity.ToString();
            //productId = product.Id;
            newProduct = false;
            dgvSubProducts.DataSource = subProductController.GetAllFor(selectedProduct);
            gbSubProduct.Enabled = true;
            gbSubProductList.Enabled = true;
            ClearErrors(gbProduct.Controls);
            btnProductErase.Enabled = true;
        }

        private void GetSelectedSubProduct()
        {
            selectedSubProduct = null;
            Int32 selectedRowCount = dgvSubProducts.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
                selectedSubProduct = (SubProduct)dgvSubProducts.SelectedRows[0].DataBoundItem;
        }

        private void LoadSubProductData()
        {
            txtSubProductName.Text = selectedSubProduct.Name;
            txtSubProductStockQuantity.Text = selectedSubProduct.StockQuantity.ToString();
            //subProductId = subProduct.Id;
            newSubProduct = false;
            nudIncrease.Value = 0;
            nudDecrease.Value = 0;
            gbPart.Enabled = true;
            gbPartList.Enabled = true;
            LoadPartForSubProductData();
            ClearErrors(gbSubProduct.Controls);
            btnSubProductErase.Enabled = true;
        }

        private void GetSelectedPart()
        {
            selectedPart = (Part)cbParts.SelectedItem;
        }

        private void GetSelectedPartForSubProduct()
        {
            selectedPartForSubProduct = null;
            btnPartErase.Enabled = false;
            Int32 selectedRowCount = dgvParts.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                selectedPartForSubProduct = (PartForSubProduct)dgvParts.SelectedRows[0].DataBoundItem;
                lblPartForErase.Text = selectedPartForSubProduct.PartName;
                btnPartErase.Enabled = true;
            }
        }

        private void LoadPartForSubProductData()
        {
            List<PartForSubProduct> result = partForSubProductController.GetFor(selectedSubProduct);
            dgvParts.DataSource = result;

            decimal subTotalCost = 0;
            foreach (PartForSubProduct partForSubProduct in result)
                subTotalCost += partForSubProduct.CostForProduct;
            lblSubTotalCost.Text = subTotalCost.ToString("$#,##0.00");
            lblCF.Text = (subTotalCost * Convert.ToDecimal(0.1)).ToString("$#,##0.00");
            lblTotalCost.Text = (subTotalCost * Convert.ToDecimal(1.1)).ToString("$#,##0.00");
        }

        #endregion

        #region Data Interaction
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            GetSelectedProduct();
            if (selectedProduct != null)
                LoadProductData();
            else
                ClearProductData();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            if (newProduct)
                txtProductStockQuantity.Text = 0.ToString();
        }

        private void txtProductPrice_TextChanged(object sender, EventArgs e)
        {
            if (newProduct)
                txtProductStockQuantity.Text = 0.ToString();
        }

        private void txtSubProductName_TextChanged(object sender, EventArgs e)
        {
            if (newSubProduct)
                txtSubProductStockQuantity.Text = 0.ToString();
        }

        private void dgvSubProducts_SelectionChanged(object sender, EventArgs e)
        {
            GetSelectedSubProduct();
            if (selectedSubProduct != null)
                LoadSubProductData();
            else
                ClearSubProductData();
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

        private void dgvProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProducts.ClearSelection();
            ClearProductData();
        }

        private void dgvSubProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSubProducts.ClearSelection();
            ClearSubProductData();
        }

        private void dgvParts_SelectionChanged(object sender, EventArgs e)
        {
            GetSelectedPartForSubProduct();
        }

        private void dgvParts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvParts.ClearSelection();
            lblPartForErase.Text = string.Empty;
        }
        
        #endregion

        #region Button Clicks
        private void btnProductClean_Click(object sender, EventArgs e)
        {
            ClearProductData();
        }

        private void btnSubProductSave_Click(object sender, EventArgs e)
        {
            if (!IsValid(gbSubProduct.Controls))
                return;

            if (newSubProduct)
                subProductController.Create(selectedProduct, txtSubProductName.Text.Trim());
            else
            {
                selectedSubProduct.Name = txtSubProductName.Text.Trim();
                subProductController.SaveOrUpdate(selectedSubProduct);
                //subProductController.Modify(selectedSubProduct.Id, txtSubProductName.Text.Trim(), Convert.ToInt32(txtSubProductStockQuantity.Text.Trim()), Status.Active);
            }
            dgvSubProducts.DataSource = subProductController.GetAllFor(selectedProduct);
            ClearSubProductData();
        }

        private void btnProductSave_Click(object sender, EventArgs e)
        {
            if (!IsValid(gbProduct.Controls))
                return;

            if (newProduct)
                productController.Create(txtProductName.Text.Trim(), txtProductDescription.Text.Trim(), Convert.ToDecimal(txtProductPrice.Text.Trim()), Convert.ToDecimal(txtProductPriceFinal.Text.Trim()));
            else
            {
                selectedProduct.Name = txtProductName.Text.Trim();
                selectedProduct.Description = txtProductDescription.Text.Trim();
                selectedProduct.Price = Convert.ToDecimal(txtProductPrice.Text.Trim());
                selectedProduct.FinalPrice = Convert.ToDecimal(txtProductPriceFinal.Text.Trim());
                productController.SaveOrUpdate(selectedProduct);
            }
            dgvProducts.DataSource = productController.GetAll();
            ClearProductData();
        }

        private void btnProductErase_Click(object sender, EventArgs e)
        {
            productController.Erase(selectedProduct);
            selectedProduct = null;
            dgvProducts.DataSource = productController.GetAll();
        }

        private void btnSubProductErase_Click(object sender, EventArgs e)
        {
            subProductController.Erase(selectedSubProduct);
            selectedSubProduct = null;
            dgvProducts.DataSource = productController.GetAll();
        }
        
        private void btnSubProductClean_Click(object sender, EventArgs e)
        {
            ClearSubProductData();
        }
        
        private void btnSubProductAddStock_Click(object sender, EventArgs e)
        {
            if(nudIncrease.Value > 0)
                subProductController.IncreaseStock(selectedSubProduct, Convert.ToInt32(nudIncrease.Value));
            else if (nudDecrease.Value > 0)
                subProductController.DecreaseStock(selectedSubProduct, Convert.ToInt32(nudDecrease.Value));
            dgvProducts.DataSource = productController.GetAll();
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            GetSelectedPart();
            partForSubProductController.Create(selectedPart, selectedSubProduct, nudPartQuantity.Value);
            LoadPartForSubProductData();
            nudPartQuantity.Value = 0;
            cbParts.SelectedIndex = 0;
        }

        private void btnPartErase_Click(object sender, EventArgs e)
        {
            partForSubProductController.Erase(selectedPartForSubProduct);
            lblPartForErase.Text = string.Empty;
            selectedPartForSubProduct = null;
            btnPartErase.Enabled = false;
            LoadPartForSubProductData();
        }

        
        #endregion

        #region Validations
        private void txtProductName_Validating(object sender, CancelEventArgs e)
        {
            Validation_Required(txtProductName, "Nombre requerido");
        }

        private void txtProductPriceFinal_Validating(object sender, CancelEventArgs e)
        {
            Validation_PriceRequired(txtProductPriceFinal, "Precio al publico requerido", "Ingrese solo numeros");
        }

        private void txtSubProductName_Validating(object sender, CancelEventArgs e)
        {
            Validation_Required(txtSubProductName, "Nombre requerido");
        }

        private void txtProductPrice_Validating(object sender, CancelEventArgs e)
        {
            Validation_PriceRequired(txtProductPrice, "Precio requerido", "Ingrese solo numeros");
        }
        #endregion

       
    }
}
