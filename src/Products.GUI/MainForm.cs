using System.Net.Http.Json;
using Products.Api.DTOs;
using Products.Core.DTOs;

namespace Products.GUI
{
    public partial class MainForm : Form
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "http://localhost:5233/api/products"; 

        public MainForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            LoadProducts();

            productsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productsDataGridView.CellClick += ProductsDataGridView_CellClick;
        }

        private void ProductsDataGridView_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                var selectedRow = productsDataGridView.Rows[e.RowIndex];

                if (selectedRow.DataBoundItem is ProductDto selectedProduct)
                {
                    // Populate text boxes with the selected product's details
                    productNameTextBox.Text = selectedProduct.ProductName;
                    descriptionTextBox.Text = selectedProduct.Description;
                    priceTextBox.Text = selectedProduct.Price.ToString();
                    stockQuantityTextBox.Text = selectedProduct.StockQuantity.ToString();
                    categoryIdTextBox.Text = selectedProduct.CategoryId.ToString();
                }
            }
        }

        private async void LoadProducts()
        {
            try
            {
                // Optionally show a loading message or spinner
                var products = await _httpClient.GetFromJsonAsync<List<ProductDto>>($"{ApiUrl}/with-categories");
                if (products != null)
                {
                    productsDataGridView.DataSource = products;
                    productsDataGridView.Columns["ProductId"].HeaderText = "Product ID";
                    productsDataGridView.Columns["ProductName"].HeaderText = "Product Name";
                    productsDataGridView.Columns["Price"].HeaderText = "Price";
                    productsDataGridView.Columns["Description"].HeaderText = "Description";
                    productsDataGridView.Columns["StockQuantity"].HeaderText = "Stock Quantity";
                    productsDataGridView.Columns["CreatedAt"].HeaderText = "Created At";
                    productsDataGridView.Columns["CategoryId"].HeaderText = "CategoryId";
                    productsDataGridView.Columns["CategoryName"].HeaderText = "Category Name";
                }
                else
                {
                    MessageBox.Show("No products found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                var productDto = new ProductDto
                {
                    ProductName = productNameTextBox.Text,
                    Description = descriptionTextBox.Text,  
                    Price = decimal.Parse(priceTextBox.Text),
                    StockQuantity = int.Parse(stockQuantityTextBox.Text),  
                    CategoryId = int.Parse(categoryIdTextBox.Text),
                };

                var response = await _httpClient.PostAsJsonAsync(ApiUrl, productDto);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Product added successfully!");
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("Error adding product.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid values for price and category ID.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            var selectedRow = productsDataGridView.SelectedRows.Count > 0 ? productsDataGridView.SelectedRows[0] : null; 

            if (selectedRow != null) 
            {
                var selectedProduct = selectedRow.DataBoundItem as ProductDto; 

                if (selectedProduct != null)
                {
                    var updateProductDto = new UpdateProductDto
                    {
                        ProductName = productNameTextBox.Text,
                        Description = descriptionTextBox.Text,
                        Price = decimal.Parse(priceTextBox.Text),
                        StockQuantity = int.Parse(stockQuantityTextBox.Text),
                        CategoryId = int.Parse(categoryIdTextBox.Text),
                    };

                    var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{selectedProduct.ProductId}", updateProductDto);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Product updated successfully!");
                        LoadProducts(); 
                    }
                    else
                    {
                        MessageBox.Show("Error updating product.");
                    }
                }
            }
        }
        private async void createCategoryButton_Click(object sender, EventArgs e)
        {
            using var createCategoryForm = new CategoryForm();
            if (createCategoryForm.ShowDialog() == DialogResult.OK)
            {
                var categoryName = createCategoryForm.CategoryName;

                // Create a new CategoryDto object
                var categoryDto = new CategoryDto
                {
                    CategoryName = categoryName
                };

                // Call the API to create the category
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5233/api/categories", categoryDto);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Category created successfully!");
                }
                else
                {
                    MessageBox.Show("Error creating category.");
                }
            }
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (productsDataGridView.SelectedRows.Count > 0) 
            {
                var selectedRow = productsDataGridView.SelectedRows[0]; 
                var selectedProduct = selectedRow.DataBoundItem as ProductDto; 

                if (selectedProduct != null)
                {
                    var confirmResult = MessageBox.Show("Are you sure to delete this product?", "Confirm Delete",
                                                        MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        var response = await _httpClient.DeleteAsync($"{ApiUrl}/{selectedProduct.ProductId}");
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Product deleted successfully!");
                            LoadProducts();
                        }
                        else
                        {
                            MessageBox.Show("Error deleting product.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }
    }
}
