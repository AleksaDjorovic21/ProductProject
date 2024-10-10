namespace Products.GUI
{
    public partial class CategoryForm : Form
    {
        public string CategoryName => categoryNameTextBox.Text; 

        public CategoryForm()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CategoryName))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }
            DialogResult = DialogResult.OK; 
            Close(); 
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; 
            Close(); 
        }
    }
}
