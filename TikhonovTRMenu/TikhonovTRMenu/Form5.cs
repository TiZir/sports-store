using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tutorial.SqlConn;

namespace TikhonovTRMenu
{
    public partial class Form5 : Form
    {
        int IDu;
        public Form5(int ID)
        {
            IDu = ID;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.ForUserDelivery". При необходимости она может быть перемещена или удалена.
            this.forUserDeliveryTableAdapter.Fill(this.tikhonovTRDataSet.ForUserDelivery);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.ForUser". При необходимости она может быть перемещена или удалена.
            this.forUserTableAdapter.Fill(this.tikhonovTRDataSet.ForUser);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.ForUserDelivery". При необходимости она может быть перемещена или удалена.
            this.forUserDeliveryTableAdapter.Fill(this.tikhonovTRDataSet.ForUserDelivery);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.ForUser". При необходимости она может быть перемещена или удалена.
            this.forUserTableAdapter.Fill(this.tikhonovTRDataSet.ForUser);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.ForUser". При необходимости она может быть перемещена или удалена.
            this.forUserTableAdapter.Fill(this.tikhonovTRDataSet.ForUser);
        }
        

        private void forUserDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void forUserDeliveryBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void forUserDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Input_Orders", conn);

                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;

                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                cmd.Parameters.Add("@IDCode", SqlDbType.Int).Value = comboBox1.SelectedValue;
                cmd.Parameters.Add("@IDEmp", SqlDbType.Int).Value = comboBox2.SelectedValue;
                cmd.Parameters.Add("@IDUser", SqlDbType.Int).Value = IDu;
                cmd.Parameters.Add("@Quant", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);
                cmd.Parameters.Add("@Cost", SqlDbType.Money).Value = 1;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 60).Value = textBox1.Text;
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = "1/1/1";
                cmd.Parameters.Add("@OrderStatus", SqlDbType.Bit).Value = 0;
                // Выполнить процедуру.
                cmd.ExecuteNonQuery();
                    textBox1.Clear();
                    textBox2.Clear();
                this.forUserTableAdapter.Fill(this.tikhonovTRDataSet.ForUser);
                this.forUserDeliveryTableAdapter.Fill(this.tikhonovTRDataSet.ForUserDelivery);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                //MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                iDToolStripTextBox.Text = Convert.ToString(IDu);
                this.yourOrdersTableAdapter.Fill(this.tikhonovTRDataSet.YourOrders, ((int)(System.Convert.ChangeType(iDToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-8OAHTJ6\SQLEXPRESS;Initial Catalog=TikhonovTR;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                string sql = "select dbo.SummOrderForUser(@ID);";
                var result = new SqlCommand(sql, connect);
                result.Parameters.AddWithValue("ID", IDu);
                var data = result.ExecuteScalar();
                textBox3.Text = data.ToString();
                connect.Close();
            }
            catch
            {
                DialogResult resultE;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                resultE = MessageBox.Show("Нет заказов", "Нельзя посчитать общую цену", buttons);
            }
        }

        private void yourOrdersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            iDToolStripTextBox.Text = Convert.ToString(IDu);
            try
            {

                this.yourOrdersTableAdapter.Fill(this.tikhonovTRDataSet.YourOrders, ((int)(System.Convert.ChangeType(iDToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void yourOrdersDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Update_Orders_Status", conn);
                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                cmd.Parameters.Add("@IDOrder", SqlDbType.Int).Value = comboBox3.SelectedValue;
                cmd.Parameters.Add("@OrderStatus", SqlDbType.Bit).Value = 1;
                cmd.ExecuteNonQuery();
                this.forUserTableAdapter.Fill(this.tikhonovTRDataSet.ForUser);
                this.forUserDeliveryTableAdapter.Fill(this.tikhonovTRDataSet.ForUserDelivery);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                //MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
