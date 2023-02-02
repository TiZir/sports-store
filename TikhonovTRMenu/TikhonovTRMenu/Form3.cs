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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.ForManagerSup". При необходимости она может быть перемещена или удалена.
            this.forManagerSupTableAdapter.Fill(this.tikhonovTRDataSet.ForManagerSup);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AD". При необходимости она может быть перемещена или удалена.
            this.aDTableAdapter.Fill(this.tikhonovTRDataSet.AD);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Input_Supplies", conn);
                string sql = "select dbo.SummSup(@COD,@Quan);";
                var result = new SqlCommand(sql, conn);
                result.Parameters.AddWithValue("COD", comboBox1.SelectedValue);
                result.Parameters.AddWithValue("Quan", Convert.ToInt32(textBox2.Text));
                var data = result.ExecuteScalar();
                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                DialogResult resultE;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                resultE = MessageBox.Show("Сделать заказ поставки на сумму: " +data.ToString(), "Сумма поставки", buttons);
                if (resultE == DialogResult.Yes)
                {
                    cmd.Parameters.Add("@IDCode", SqlDbType.Int).Value = comboBox1.SelectedValue;
                    cmd.Parameters.Add("@Quan", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);
                    cmd.Parameters.Add("@Cost", SqlDbType.Money).Value = 1;
                    cmd.Parameters.Add("@Time", SqlDbType.Date).Value = "1/1/1";
                    cmd.Parameters.Add("@Stat", SqlDbType.Bit).Value = 0;
                    cmd.ExecuteNonQuery();
                }
                textBox2.Clear();
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.ForManagerSup". При необходимости она может быть перемещена или удалена.
                this.forManagerSupTableAdapter.Fill(this.tikhonovTRDataSet.ForManagerSup);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AD". При необходимости она может быть перемещена или удалена.
                this.aDTableAdapter.Fill(this.tikhonovTRDataSet.AD);

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void forManagerSupDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void forManagerSupDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Update_Supplies_Status", conn);
                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                cmd.Parameters.Add("@IDSup", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
                cmd.Parameters.Add("@Stat", SqlDbType.Bit).Value = 1;
                cmd.ExecuteNonQuery();
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.ForManagerSup". При необходимости она может быть перемещена или удалена.
                this.forManagerSupTableAdapter.Fill(this.tikhonovTRDataSet.ForManagerSup);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AD". При необходимости она может быть перемещена или удалена.
                this.aDTableAdapter.Fill(this.tikhonovTRDataSet.AD);
                textBox1.Clear();
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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Input_Products", conn);
                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                //Создание объекта для генерации чисел
                Random rnd = new Random();
                //Получить случайное число (в диапазоне от 0 до 10)
                float random = rnd.Next(0, 41);
                //Вывод числа в консоль
                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar,150).Value = textBox5.Text;
                cmd.Parameters.Add("@Desc", SqlDbType.NVarChar, 100).Value = textBox7.Text;
                cmd.Parameters.Add("@Quant", SqlDbType.Int).Value = Convert.ToInt32(textBox9.Text);
                cmd.Parameters.Add("@Demand", SqlDbType.Float).Value = random;
                cmd.Parameters.Add("@Give", SqlDbType.Money).Value = Convert.ToDouble(textBox8.Text);
                cmd.Parameters.Add("@Get", SqlDbType.Money).Value = Convert.ToDouble(textBox6.Text);
                cmd.ExecuteNonQuery();
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.ForManagerSup". При необходимости она может быть перемещена или удалена.
                this.forManagerSupTableAdapter.Fill(this.tikhonovTRDataSet.ForManagerSup);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AD". При необходимости она может быть перемещена или удалена.
                this.aDTableAdapter.Fill(this.tikhonovTRDataSet.AD);
                textBox5.Clear();
                textBox7.Clear();
                textBox9.Clear();
                textBox8.Clear();
                textBox6.Clear();

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

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Input_ADS", conn);
                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                //Создание объекта для генерации чисел
                Random rnd2 = new Random();
                //Получить случайное число (в диапазоне от 0 до 10)
                float random2 = rnd2.Next(0, 150);
                //Вывод числа в консоль
                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                cmd.Parameters.Add("@IDCode", SqlDbType.Int).Value = Convert.ToInt32(textBox12.Text);
                cmd.Parameters.Add("@Growth", SqlDbType.Float).Value = random2;
                cmd.Parameters.Add("@Cost", SqlDbType.Money).Value = Convert.ToDouble(textBox4.Text);
                cmd.Parameters.Add("@Platform", SqlDbType.NVarChar,12).Value = textBox3.Text;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 30).Value = textBox10.Text;
                cmd.Parameters.Add("@Desc", SqlDbType.NVarChar, 30).Value = textBox11.Text;
                cmd.ExecuteNonQuery();
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.ForManagerSup". При необходимости она может быть перемещена или удалена.
                this.forManagerSupTableAdapter.Fill(this.tikhonovTRDataSet.ForManagerSup);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AD". При необходимости она может быть перемещена или удалена.
                this.aDTableAdapter.Fill(this.tikhonovTRDataSet.AD);
                textBox12.Clear();
                textBox4.Clear();
                textBox3.Clear();
                textBox10.Clear();
                textBox11.Clear();
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

        private void forManagerADDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
