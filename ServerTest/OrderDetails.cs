using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Devart.Data.MySql;

namespace RestaurantApp
{
    public partial class OrderDetails : Form
    {
        int OrderId;

        public OrderDetails(int order_id)
        {
            InitializeComponent();
            OrderId = order_id;
            labelInfo.Text = "Details for order № " + OrderId;
        }

        private void OrderDetails_Load(object sender, EventArgs e)
        {
            DataDisplayController.InitOrderDetailAdapter(OrderId);
            DataDisplayController.OrderDetailsAdapter.Fill(DataDisplayController.restDataSet.OrderComments);
            DataDisplayController.DataGridViewDisplayDataTable(dataGridViewComments, DataDisplayController.restDataSet, DataDisplayController.restDataSet.OrderComments as DataTable);

            DataDisplayController.InitServiceDetailAdapter(OrderId);
            DataDisplayController.ServiceDetailsAdapter.Fill(DataDisplayController.restDataSet.ServiceDetails);
            DataDisplayController.DataGridViewDisplayDataTable(dataGridViewService, DataDisplayController.restDataSet, DataDisplayController.restDataSet.ServiceDetails as DataTable);
            dataGridViewService.Columns[0].Visible = false;
            dataGridViewService.Columns[3].Visible = false;

            DataDisplayController.InitFineDetailAdapter(OrderId);
            DataDisplayController.FineDetailsAdapter.Fill(DataDisplayController.restDataSet.FineDetails);
            DataDisplayController.DataGridViewDisplayDataTable(dataGridViewFines, DataDisplayController.restDataSet, DataDisplayController.restDataSet.FineDetails as DataTable);
            dataGridViewFines.Columns[0].Visible = false;
            dataGridViewFines.Columns[3].Visible = false;
        }
    }
}
