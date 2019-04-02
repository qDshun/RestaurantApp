using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApp
{
    public partial class Dish_menu : Form
    {
        public Dish_menu()
        {
            InitializeComponent();
            DataDisplayController.CategoryTableAdapter.Fill(restDataSet.dish_category);
            DataDisplayController.FillComboBox(restDataSet.dish_category as DataTable, dataGridView1, comboBoxDishCategory, restDataSet);
            DataDisplayController.DataGridViewDisplayDataTable(dataGridView1, restDataSet, restDataSet.dish_menu as DataTable);
            DataDisplayController.DishMenuAdapter.Fill(restDataSet.dish_menu);
            dataGridView1.Columns[0].Visible = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int category_id = comboBoxDishCategory.SelectedIndex + 1;
            int price = Convert.ToInt32(textBoxPrice.Text);
            int amount = Convert.ToInt32(textBoxAmount.Text);
            string name = textBoxName.Text;
            DataDisplayController.AddDish(category_id, price, amount, name, dataGridView1);

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataDisplayController.DeleteDish(dataGridView1);
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only [0-9]
            char c = e.KeyChar;
            if (!(((c >= '0' && c <= '9')) || (c == (char)Keys.Back)))
                e.Handled = true;
            return;
        }

        private void textBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only [0-9]
            char c = e.KeyChar;
            if (!(((c >= '0' && c <= '9')) || (c == (char)Keys.Back)))
                e.Handled = true;
            return;
        }

        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only [0-9]
            char c = e.KeyChar;
            if (!(((c >= '0' && c <= '9')) || (c == (char)Keys.Back)))
                e.Handled = true;
            return;
        }

        private void textBoxIDcreating_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only [0-9]
            char c = e.KeyChar;
            if (!(((c >= '0' && c < '9')) || (c == (char)Keys.Back)))
                e.Handled = true;
            return;
        }

        private void toXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplayController.ExportMenuToXML(dataGridView1);
        }
    }
}
