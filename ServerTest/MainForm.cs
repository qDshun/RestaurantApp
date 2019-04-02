using MySql.Data.MySqlClient;
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
    public partial class MainForm : Form
    {
        restDataSet ds = new restDataSet();
        restDataSetTableAdapters.usersTableAdapter usersAdapter = new restDataSetTableAdapters.usersTableAdapter();
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.AutoSize = true;
            DataDisplayController.DishDictionaryAdapter.Fill(DataDisplayController.restDataSet.dish_dictionary);
            DataDisplayController.FillComboBox(DataDisplayController.restDataSet.dish_dictionary as DataTable, dataGridView1, comboBoxDish, DataDisplayController.restDataSet);
            DataDisplayController.orderTableAdapter.Fill(DataDisplayController.restDataSet.order);
            DataDisplayController.FillComboBox(DataDisplayController.restDataSet.order as DataTable, dataGridView1, comboBoxOrder, DataDisplayController.restDataSet, 0);
            DataDisplayController.FillComboBox(DataDisplayController.restDataSet.order as DataTable, dataGridView1, comboBoxOrderDetails, DataDisplayController.restDataSet, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataDisplayController.DataGridViewDisplayDataTable(dataGridView1, DataDisplayController.restDataSet, DataDisplayController.restDataSet.order_list as DataTable);
            DataDisplayController.OrderListAdapter.Fill(DataDisplayController.restDataSet.order_list);
            dataGridView1.Columns[0].Name = "Order №";
        }

        private void dishesWCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dish_menu dishes = new Dish_menu();
            dishes.Show();
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplayController.DataGridViewDisplayOrderList(dataGridView1);
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
        }

        private void servicesAndFinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            DataDisplayController.DataGridViewDisplayDataTable(dataGridView1, restDataSet, restDataSet.fines_and_services as DataTable);
            DataDisplayController.FineAndServiceAdapter.Fill(restDataSet.fines_and_services);
            */
        }
        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only [0-9]
            char c = e.KeyChar;
            if (!(((c >= '0' && c <= '9')) || (c == (char)Keys.Back)))
                e.Handled = true;
            return;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int dish_id = Convert.ToInt32(comboBoxDish.SelectedValue.ToString().Split(' ')[0]);
            int order_id = Convert.ToInt32(comboBoxOrder.SelectedValue);
            int dishes_count = Convert.ToInt32(textBoxCount.Text);
            DataDisplayController.AddOderDish(dish_id, order_id, dishes_count, dataGridView1, comboBoxDish, comboBoxOrder);
        }

        private void buttonOrderDetail_Click(object sender, EventArgs e)
        {
            new OrderDetails(Convert.ToInt32(comboBoxOrderDetails.SelectedValue)).Show();
        }

        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            DataDisplayController.AddOrder(dateTimePickerOrder, textBoxTableID);
            DataDisplayController.DishDictionaryAdapter.Fill(DataDisplayController.restDataSet.dish_dictionary);
            DataDisplayController.FillComboBox(DataDisplayController.restDataSet.dish_dictionary as DataTable, dataGridView1, comboBoxDish, DataDisplayController.restDataSet);
            DataDisplayController.orderTableAdapter.Fill(DataDisplayController.restDataSet.order);
            DataDisplayController.FillComboBox(DataDisplayController.restDataSet.order as DataTable, dataGridView1, comboBoxOrder, DataDisplayController.restDataSet, 0);
            DataDisplayController.FillComboBox(DataDisplayController.restDataSet.order as DataTable, dataGridView1, comboBoxOrderDetails, DataDisplayController.restDataSet, 0);
        }
        
    }
}
