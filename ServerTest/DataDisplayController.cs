using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Devart.Data.MySql;
using MySql.Data.Types;
using System.Xml;

namespace RestaurantApp
{
    class DataDisplayController
    {

        // initializing all Adapters;
        public static restDataSetTableAdapters.dish_menuTableAdapter DishMenuAdapter = new restDataSetTableAdapters.dish_menuTableAdapter();
        public static restDataSetTableAdapters.dish_dictionaryTableAdapter DishDictionaryAdapter = new restDataSetTableAdapters.dish_dictionaryTableAdapter();
        public static restDataSetTableAdapters.dish_categoryTableAdapter DishCategoryAdapter = new restDataSetTableAdapters.dish_categoryTableAdapter();
        public static restDataSetTableAdapters.rest_staffTableAdapter RestStaffAdapter = new restDataSetTableAdapters.rest_staffTableAdapter();
        public static restDataSetTableAdapters.fines_and_servicesTableAdapter FineAndServiceAdapter = new restDataSetTableAdapters.fines_and_servicesTableAdapter();

        public static restDataSetTableAdapters.order_listTableAdapter OrderListAdapter = new restDataSetTableAdapters.order_listTableAdapter();
        public static restDataSetTableAdapters.orderTableAdapter orderTableAdapter = new restDataSetTableAdapters.orderTableAdapter();
        public static restDataSetTableAdapters.dishes_orderTableAdapter dishesOrderAdapter = new restDataSetTableAdapters.dishes_orderTableAdapter();

        public static restDataSetTableAdapters.dish_categoryTableAdapter CategoryTableAdapter = new restDataSetTableAdapters.dish_categoryTableAdapter();

        public static restDataSetTableAdapters.staffTableAdapter staffTableAdapter = new restDataSetTableAdapters.staffTableAdapter();
        public static restDataSetTableAdapters.positionTableAdapter positionTableAdapter = new restDataSetTableAdapters.positionTableAdapter();
        public static restDataSetTableAdapters.TableAdapterManager AdapterManager = new restDataSetTableAdapters.TableAdapterManager();
      
        // start of OrderDetailsAdapter
        public static string OrderDetailSelectCommand = "SELECT        comment_or_complain.name, comment_or_complain.email," +
            " comment_or_complain.`comment`, `order`.order_id, `order`.table_id " +
            "FROM comment_or_complain INNER JOIN `order` ON comment_or_complain.order_id = `order`.order_id " +
            "WHERE (order.order_id=@order_id)";
        public static MySqlDataAdapter OrderDetailsAdapter = new MySqlDataAdapter(OrderDetailSelectCommand, orderTableAdapter.Connection);
        // finish 
        // start of FineDetailsAdapter
        public static string FineDetailSelectCommand = "SELECT        `order`.order_id, fine_dictionary.price, fine_dictionary.name, fine.fine_id, fine.fine_count AS `count`" +
            "FROM            fine INNER JOIN fine_dictionary ON fine.fine_id = fine_dictionary.fine_id INNER JOIN `order` ON fine.order_id = `order`.order_id " +
            "WHERE (order.order_id=@order_id)";
        public static MySqlDataAdapter FineDetailsAdapter = new MySqlDataAdapter(FineDetailSelectCommand, orderTableAdapter.Connection);
        // finish 
        // start of ServiceDetailsAdapter
        public static string ServiceDetailSelectCommand = "SELECT        `order`.order_id, service_dictionary.price, service_dictionary.name, service.service_id, service.service_count AS `count`" +
            "FROM service INNER JOIN service_dictionary ON service.service_id = service_dictionary.service_id INNER JOIN `order` ON service.order_id = `order`.order_id " +
            "WHERE(order.order_id = @order_id)";
        public static MySqlDataAdapter ServiceDetailsAdapter = new MySqlDataAdapter(ServiceDetailSelectCommand, orderTableAdapter.Connection);
        // finish 
        // end of initializing;

        public static restDataSet restDataSet = new restDataSet();

        public static void ExportMenuToXML(DataGridView dataGridView)
        {
            string path = Application.StartupPath.ToString() + "\\menu.xml";
            XmlDocument menu = new XmlDocument();
            menu.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement rootNode = menu.CreateElement("menu");
            rootNode.SetAttribute("name", "Полное меню");
            menu.AppendChild(rootNode);
            DishMenuAdapter.Fill(restDataSet.dish_menu);
            string previousElement = null;

            foreach (DataRow r in restDataSet.dish_menu.Rows)
            {
                string current = r.Field<string>(restDataSet.dish_menu.Columns[1]);
                if (current!=previousElement)
                {
                    XmlElement categoryNode = menu.CreateElement("category");
                    categoryNode.SetAttribute("name", r.Field<string>(restDataSet.dish_menu.Columns[1]));
                    rootNode.AppendChild(categoryNode);
                }
                previousElement = current;
            }

            foreach (DataRow r in restDataSet.dish_menu.Rows)
            {
                string category = r.Field<string>(restDataSet.dish_menu.Columns[1]);
                string xpath = "//category[@name='" + category + "']";
                XmlElement dish = menu.CreateElement("dish");
                XmlText dishName = menu.CreateTextNode(r.Field<string>(restDataSet.dish_menu.Columns[2]));
                XmlAttribute name = menu.CreateAttribute("dish");
                name.AppendChild(dishName);
                dish.Attributes.Append(name);
                menu.SelectSingleNode(xpath).AppendChild(dish);
            }
            menu.Save(path);
            MessageBox.Show("menu.xml was successfuly formed at \n" + path);
        }

        public static void InitOrderDetailAdapter(int parametr)
        {
            OrderDetailsAdapter.SelectCommand.Parameters.Add("@order_id", SqlDbType.Int);
            OrderDetailsAdapter.SelectCommand.Parameters["@order_id"].Value = parametr;
        }

        public static void InitFineDetailAdapter(int parametr)
        {
            FineDetailsAdapter.SelectCommand.Parameters.Add("@order_id", SqlDbType.Int);
            FineDetailsAdapter.SelectCommand.Parameters["@order_id"].Value = parametr;
        }

        public static void InitServiceDetailAdapter(int parametr)
        {
            ServiceDetailsAdapter.SelectCommand.Parameters.Add("@order_id", SqlDbType.Int);
            ServiceDetailsAdapter.SelectCommand.Parameters["@order_id"].Value = parametr;
        }

        public static void DataGridViewDisplayDataTable(DataGridView dataGridView, restDataSet restDataSet, DataTable dataTable)
        {
            dataGridView.AutoGenerateColumns = true;
            int index = restDataSet.Tables.IndexOf(dataTable);
            dataGridView.DataSource = restDataSet;
            dataGridView.DataMember = restDataSet.Tables[index].TableName;
        }

        public static void DataGridViewDisplayOrderList(DataGridView dataGridView)
        {
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = restDataSet;
            dataGridView.DataMember = "order_list";
            try
            {
                OrderListAdapter.Fill(restDataSet.order_list);
            }
            catch
            {
                restDataSet.order_list.GetErrors();
            }
        }

        public static void FillComboBox(DataTable dataTable, DataGridView dataGridView, ComboBox comboBox, restDataSet restDataSet)
        {
            int index = restDataSet.Tables.IndexOf(dataTable);
            string[] combo_box_data = new string[restDataSet.Tables[index].Rows.Count];
            int i = 0;
            foreach (DataRow r in restDataSet.Tables[index].Rows)
            {
                combo_box_data[i] = r.Field<int>(0) + "  " + r.Field<string>(1) + "";
                i++;
            }
            comboBox.DataSource = combo_box_data;
        }

        public static void FillComboBox(DataTable dataTable, DataGridView dataGridView, ComboBox comboBox, restDataSet restDataSet, int Col)
        {
            int index = restDataSet.Tables.IndexOf(dataTable);
            string[] combo_box_data = new string[restDataSet.Tables[index].Rows.Count];
            int i = 0;
            foreach (DataRow r in restDataSet.Tables[index].Rows)
            {
                combo_box_data[i] = r.Field<int>(Col) + "";
                i++;
            }
            comboBox.DataSource = combo_box_data;
        }

        public static void DeleteWorker(DataGridView dataGridView1, ComboBox comboBoxFire, ComboBox comboBoxPosition)
        {
            try
            {
                staffTableAdapter.Fill(restDataSet.staff);
                restDataSet.staff.FindBystaff_id(Convert.ToInt32(comboBoxFire.SelectedValue.ToString().Split(' ').ElementAt(0))).Delete();
                staffTableAdapter.Update(restDataSet);
                AdapterManager.UpdateAll(restDataSet);
                DataGridViewDisplayDataTable(dataGridView1, restDataSet, restDataSet.rest_staff);
                RestStaffAdapter.Fill(restDataSet.rest_staff);
                FillComboBox(restDataSet.staff as DataTable, dataGridView1, comboBoxFire, restDataSet);
                FillComboBox(restDataSet.position as DataTable, dataGridView1, comboBoxPosition, restDataSet);
                MessageBox.Show("Fired successfuly", "Firing a peasant...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void AddOrder(DateTimePicker dateTime, TextBox textBox)
        {
            int order_id = 1;
            while (restDataSet.order.FindByorder_id(order_id) != null)
                order_id++;
            int table_id = Convert.ToInt32(textBox.Text);
            orderTableAdapter.Insert(order_id, table_id, dateTime.Value);
            MessageBox.Show("Order №" + order_id + "added successfuly", "Adding new order...");
        }

        public static void AddOderDish(int dish_id, int order_id, int dishes_count, DataGridView dataGridView1, ComboBox comboBoxDish, ComboBox comboBoxOrder)
        {
            try
            {
                dishesOrderAdapter.Fill(restDataSet.dishes_order);
                int dishes_order_id = 1;
                while (restDataSet.dishes_order.FindBydishes_order_id(dishes_order_id) != null)
                    dishes_order_id++;
                dishesOrderAdapter.Insert(dish_id, order_id, dishes_count, dishes_order_id);
                DishDictionaryAdapter.Fill(restDataSet.dish_dictionary);
                FillComboBox(restDataSet.dish_dictionary as DataTable, dataGridView1, comboBoxDish, restDataSet);
                orderTableAdapter.Fill(restDataSet.order);
                FillComboBox(restDataSet.order as DataTable, dataGridView1, comboBoxOrder, restDataSet, 0);
                MessageBox.Show("Added successfuly", "Adding dishes to order...");
                DataGridViewDisplayDataTable(dataGridView1, restDataSet, restDataSet.order_list as DataTable);
                OrderListAdapter.Fill(restDataSet.order_list);
                dataGridView1.Columns[0].Name = "Order №";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void AddWorker(string name, string passport_id, string email, DataGridView dataGridView1, ComboBox comboBoxPosition, ComboBox comboBoxFire)
        {
            try
            {
                staffTableAdapter.Fill(restDataSet.staff);
                int position_id = Convert.ToInt32(comboBoxPosition.SelectedValue.ToString().Split(' ').ElementAt(0));
                int staff_id = 1;
                while (restDataSet.staff.FindBystaff_id(staff_id) != null)
                    staff_id++;
                staffTableAdapter.Insert(staff_id, name, passport_id, email, position_id);
                staffTableAdapter.Fill(restDataSet.staff);
                AdapterManager.UpdateAll(restDataSet);
                RestStaffAdapter.Fill(restDataSet.rest_staff);
                DataGridViewDisplayDataTable(dataGridView1, restDataSet, restDataSet.rest_staff);
                FillComboBox(restDataSet.staff as DataTable, dataGridView1, comboBoxFire, restDataSet);
                FillComboBox(restDataSet.position as DataTable, dataGridView1, comboBoxPosition, restDataSet);
                MessageBox.Show("Added successfuly", "Adding a peasant...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void AddDish(int category_id, int price, int amount, string name, DataGridView dataGridView1)
        {
            try
            {
                DishDictionaryAdapter.Fill(restDataSet.dish_dictionary);
                int dish_id=1;
                while (restDataSet.dish_dictionary.FindBydish_id(dish_id) != null)
                    dish_id++;
                DishDictionaryAdapter.Insert(dish_id, name,  price, amount, category_id);
                MessageBox.Show("Added successfuly", "Adding new dish...");
                AdapterManager.UpdateAll(restDataSet);
                DataGridViewDisplayDataTable(dataGridView1, restDataSet, restDataSet.dish_menu as DataTable);
                DishMenuAdapter.Fill(restDataSet.dish_menu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public static void DeleteDish(DataGridView dataGridView)
        {
            try
            {
                DishDictionaryAdapter.Fill(restDataSet.dish_dictionary);
                DishCategoryAdapter.Fill(restDataSet.dish_category);
                int dish_id = -1;
                if (dataGridView.SelectedRows!=null)
                {
                    dish_id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
                }
                restDataSet.dish_dictionary.FindBydish_id(dish_id).Delete();
                DishDictionaryAdapter.Update(restDataSet);
                AdapterManager.UpdateAll(restDataSet);
                DataGridViewDisplayDataTable(dataGridView, restDataSet, restDataSet.dish_menu);
                DishMenuAdapter.Fill(restDataSet.dish_menu);
                MessageBox.Show("Deleted successfuly", "Deleting a dish...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
