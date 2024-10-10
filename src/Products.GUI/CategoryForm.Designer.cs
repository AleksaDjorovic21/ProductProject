namespace Products.GUI
{

partial class CategoryForm
{
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox categoryNameTextBox;
    private System.Windows.Forms.Button createButton;
    private System.Windows.Forms.Button cancelButton;

    private void InitializeComponent()
    {
        this.label1 = new System.Windows.Forms.Label();
        this.categoryNameTextBox = new System.Windows.Forms.TextBox();
        this.createButton = new System.Windows.Forms.Button();
        this.cancelButton = new System.Windows.Forms.Button();
        this.SuspendLayout();
        
        // Label
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(78, 17);
        this.label1.TabIndex = 0;
        this.label1.Text = "Category Name:";
        
        // TextBox
        this.categoryNameTextBox.Location = new System.Drawing.Point(15, 29);
        this.categoryNameTextBox.Name = "categoryNameTextBox";
        this.categoryNameTextBox.Size = new System.Drawing.Size(257, 22);
        this.categoryNameTextBox.TabIndex = 1;
        
        // Create Button
        this.createButton.Location = new System.Drawing.Point(15, 57);
        this.createButton.Name = "createButton";
        this.createButton.Size = new System.Drawing.Size(75, 23);
        this.createButton.TabIndex = 2;
        this.createButton.Text = "Create";
        this.createButton.UseVisualStyleBackColor = true;
        this.createButton.Click += new System.EventHandler(this.createButton_Click);
        
        // Cancel Button
        this.cancelButton.Location = new System.Drawing.Point(197, 57);
        this.cancelButton.Name = "cancelButton";
        this.cancelButton.Size = new System.Drawing.Size(75, 23);
        this.cancelButton.TabIndex = 3;
        this.cancelButton.Text = "Cancel";
        this.cancelButton.UseVisualStyleBackColor = true;
        this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
        
        // CreateCategoryForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 92);
        this.Controls.Add(this.cancelButton);
        this.Controls.Add(this.createButton);
        this.Controls.Add(this.categoryNameTextBox);
        this.Controls.Add(this.label1);
        this.Name = "CategoryForm"; 
        this.Text = "Create Category";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
}
