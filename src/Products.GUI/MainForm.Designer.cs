namespace Products.GUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox stockQuantityTextBox;
        private System.Windows.Forms.TextBox categoryIdTextBox;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label stockQuantityLabel;
        private System.Windows.Forms.Label categoryIdLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridView productsDataGridView;
        private System.Windows.Forms.Button createCategoryButton;

        // Initialize components method
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.productsDataGridView = new System.Windows.Forms.DataGridView();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.stockQuantityTextBox = new System.Windows.Forms.TextBox();
            this.categoryIdTextBox = new System.Windows.Forms.TextBox();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.stockQuantityLabel = new System.Windows.Forms.Label();
            this.categoryIdLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.createCategoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Initialize productsDataGridView
            this.productsDataGridView = new System.Windows.Forms.DataGridView();
            this.productsDataGridView.Location = new System.Drawing.Point(380, 10);
            this.productsDataGridView.Name = "productsDataGridView";
            this.productsDataGridView.Size = new System.Drawing.Size(645, 275);
            this.productsDataGridView.TabIndex = 0;

            // productNameTextBox
            this.productNameTextBox.Location = new System.Drawing.Point(140, 60);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(180, 20);
            this.productNameTextBox.TabIndex = 1;

            // productNameLabel
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Location = new System.Drawing.Point(20, 60);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(78, 13);
            this.productNameLabel.TabIndex = 7;
            this.productNameLabel.Text = "Product Name:";

            // priceTextBox
            this.priceTextBox.Location = new System.Drawing.Point(140, 100);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(180, 20);
            this.priceTextBox.TabIndex = 3;

            // priceLabel
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(20, 100);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(34, 13);
            this.priceLabel.TabIndex = 8;
            this.priceLabel.Text = "Price:";

            // categoryIdTextBox
            this.categoryIdTextBox.Location = new System.Drawing.Point(140, 220);
            this.categoryIdTextBox.Name = "categoryIdTextBox";
            this.categoryIdTextBox.Size = new System.Drawing.Size(180, 20);
            this.categoryIdTextBox.TabIndex = 6;

            // categoryIdLabel
            this.categoryIdLabel.AutoSize = true;
            this.categoryIdLabel.Location = new System.Drawing.Point(20, 220);
            this.categoryIdLabel.Name = "categoryIdLabel";
            this.categoryIdLabel.Size = new System.Drawing.Size(62, 13);
            this.categoryIdLabel.TabIndex = 9;
            this.categoryIdLabel.Text = "Category ID:";

            // addButton
            this.addButton.Location = new System.Drawing.Point(20, 260);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);

            // updateButton
            this.updateButton.Location = new System.Drawing.Point(120, 260);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 13;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);

            // deleteButton
            this.deleteButton.Location = new System.Drawing.Point(220, 260);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 14;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);

            // descriptionTextBox
            this.descriptionTextBox.Location = new System.Drawing.Point(140, 140);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(180, 20);
            this.descriptionTextBox.TabIndex = 4;

            // descriptionLabel
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(20, 140);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.descriptionLabel.TabIndex = 9;
            this.descriptionLabel.Text = "Description:";

            // stockQuantityTextBox
            this.stockQuantityTextBox.Location = new System.Drawing.Point(140, 180);
            this.stockQuantityTextBox.Name = "stockQuantityTextBox";
            this.stockQuantityTextBox.Size = new System.Drawing.Size(180, 20);
            this.stockQuantityTextBox.TabIndex = 5;

            // stockQuantityLabel
            this.stockQuantityLabel.AutoSize = true;
            this.stockQuantityLabel.Location = new System.Drawing.Point(20, 180);
            this.stockQuantityLabel.Name = "stockQuantityLabel";
            this.stockQuantityLabel.Size = new System.Drawing.Size(82, 13);
            this.stockQuantityLabel.TabIndex = 9;
            this.stockQuantityLabel.Text = "Stock Quantity:";

            // createCategoryButton
            this.createCategoryButton.Location = new System.Drawing.Point(10, 300); 
            this.createCategoryButton.Name = "createCategoryButton";
            this.createCategoryButton.Size = new System.Drawing.Size(100, 23);
            this.createCategoryButton.Text = "Create Category";
            this.createCategoryButton.UseVisualStyleBackColor = true;
            this.createCategoryButton.Click += new System.EventHandler(this.createCategoryButton_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(1100, 350);
            this.Controls.Add(this.productNameTextBox);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.categoryIdTextBox);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.categoryIdLabel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.stockQuantityTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.stockQuantityLabel);
            this.Controls.Add(this.productsDataGridView);
            this.Controls.Add(this.createCategoryButton);
            this.Name = "MainForm";
            this.Text = "Product Manager";
        }
    }
}
