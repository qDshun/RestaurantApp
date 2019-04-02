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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
            DataDisplayController.staffTableAdapter.Fill(restDataSet.staff);
            DataDisplayController.positionTableAdapter.Fill(restDataSet.position);
            DataDisplayController.FillComboBox(restDataSet.staff as DataTable, dataGridView1, comboBoxFire, restDataSet);
            DataDisplayController.FillComboBox(restDataSet.position as DataTable, dataGridView1, comboBoxPosition, restDataSet);
            DataDisplayController.DataGridViewDisplayDataTable(dataGridView1, restDataSet, restDataSet.rest_staff);
            DataDisplayController.RestStaffAdapter.Fill(restDataSet.rest_staff);
            dataGridView1.Columns[0].Visible = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataDisplayController.DeleteWorker(dataGridView1, comboBoxFire, comboBoxPosition);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string passport_id = textBoxPassportID.Text;
            string email = textBoxEmail.Text;
            DataDisplayController.AddWorker(name, passport_id, email, dataGridView1, comboBoxPosition, comboBoxFire);
        }
    }
}
