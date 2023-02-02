using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tutorial.SqlConn;
using System.Data.SqlClient;

namespace TikhonovTRMenu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Сatal". При необходимости она может быть перемещена или удалена.
            this.сatalTableAdapter.Fill(this.tikhonovTRDataSet.Сatal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AdminUsers". При необходимости она может быть перемещена или удалена.
            this.adminUsersTableAdapter.Fill(this.tikhonovTRDataSet.AdminUsers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Emp". При необходимости она может быть перемещена или удалена.
            this.empTableAdapter.Fill(this.tikhonovTRDataSet.Emp);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.StatTop". При необходимости она может быть перемещена или удалена.
            this.statTopTableAdapter.Fill(this.tikhonovTRDataSet.StatTop);

        }

        private void statDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.aDCardTableAdapter.Fill(this.tikhonovTRDataSet.ADCard, ((int)(System.Convert.ChangeType(iDADToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void Сотрудники_Click(object sender, EventArgs e)
        {

        }

        private void fillToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.supCardTableAdapter.Fill(this.tikhonovTRDataSet.SupCard, ((int)(System.Convert.ChangeType(iDSupToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillToolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                this.userCardTableAdapter.Fill(this.tikhonovTRDataSet.UserCard, ((int)(System.Convert.ChangeType(iDUserToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillToolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                this.orderCardTableAdapter.Fill(this.tikhonovTRDataSet.OrderCard, ((int)(System.Convert.ChangeType(iDOrderToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

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
                cmd.Parameters.Add("@Platform", SqlDbType.NVarChar, 12).Value = textBox3.Text;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 30).Value = textBox10.Text;
                cmd.Parameters.Add("@Desc", SqlDbType.NVarChar, 30).Value = textBox11.Text;
                cmd.ExecuteNonQuery();
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Сatal". При необходимости она может быть перемещена или удалена.
                this.сatalTableAdapter.Fill(this.tikhonovTRDataSet.Сatal);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AdminUsers". При необходимости она может быть перемещена или удалена.
                this.adminUsersTableAdapter.Fill(this.tikhonovTRDataSet.AdminUsers);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Emp". При необходимости она может быть перемещена или удалена.
                this.empTableAdapter.Fill(this.tikhonovTRDataSet.Emp);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.StatTop". При необходимости она может быть перемещена или удалена.
                this.statTopTableAdapter.Fill(this.tikhonovTRDataSet.StatTop);
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Delete_ADS", conn);
                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                cmd.Parameters.Add("@IDAds", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
                cmd.ExecuteNonQuery();
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Сatal". При необходимости она может быть перемещена или удалена.
                this.сatalTableAdapter.Fill(this.tikhonovTRDataSet.Сatal);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AdminUsers". При необходимости она может быть перемещена или удалена.
                this.adminUsersTableAdapter.Fill(this.tikhonovTRDataSet.AdminUsers);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Emp". При необходимости она может быть перемещена или удалена.
                this.empTableAdapter.Fill(this.tikhonovTRDataSet.Emp);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.StatTop". При необходимости она может быть перемещена или удалена.
                this.statTopTableAdapter.Fill(this.tikhonovTRDataSet.StatTop);
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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Input_Employees", conn);
                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                cmd.Parameters.Add("@Sur", SqlDbType.NVarChar, 30).Value = textBox2.Text;
                cmd.Parameters.Add("@Firs", SqlDbType.NVarChar, 30).Value = textBox7.Text;
                cmd.Parameters.Add("@Las", SqlDbType.NVarChar, 30).Value = textBox6.Text;
                cmd.Parameters.Add("@Pos", SqlDbType.NVarChar, 30).Value = textBox5.Text;
                cmd.Parameters.Add("@Sal", SqlDbType.Money).Value = Convert.ToDouble(textBox8.Text) ;
                cmd.Parameters.Add("@Job", SqlDbType.NVarChar, 30).Value = textBox9.Text;
                cmd.Parameters.Add("@Busy", SqlDbType.Bit).Value =0;
                cmd.ExecuteNonQuery();
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Сatal". При необходимости она может быть перемещена или удалена.
                this.сatalTableAdapter.Fill(this.tikhonovTRDataSet.Сatal);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AdminUsers". При необходимости она может быть перемещена или удалена.
                this.adminUsersTableAdapter.Fill(this.tikhonovTRDataSet.AdminUsers);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Emp". При необходимости она может быть перемещена или удалена.
                this.empTableAdapter.Fill(this.tikhonovTRDataSet.Emp);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.StatTop". При необходимости она может быть перемещена или удалена.
                this.statTopTableAdapter.Fill(this.tikhonovTRDataSet.StatTop);
                textBox2.Clear();
                textBox7.Clear();
                textBox6.Clear();
                textBox5.Clear();
                textBox8.Clear();
                textBox9.Clear();
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

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Delete__Employees", conn);
                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                cmd.Parameters.Add("@IDEmp", SqlDbType.Int).Value = Convert.ToInt32(textBox13.Text);
                cmd.ExecuteNonQuery();
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Сatal". При необходимости она может быть перемещена или удалена.
                this.сatalTableAdapter.Fill(this.tikhonovTRDataSet.Сatal);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AdminUsers". При необходимости она может быть перемещена или удалена.
                this.adminUsersTableAdapter.Fill(this.tikhonovTRDataSet.AdminUsers);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Emp". При необходимости она может быть перемещена или удалена.
                this.empTableAdapter.Fill(this.tikhonovTRDataSet.Emp);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.StatTop". При необходимости она может быть перемещена или удалена.
                this.statTopTableAdapter.Fill(this.tikhonovTRDataSet.StatTop);
                textBox13.Clear();
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

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Update_Employees_JobStat", conn);
                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                cmd.Parameters.Add("@IDEmp", SqlDbType.Int).Value = Convert.ToInt32(textBox14.Text);
                cmd.Parameters.Add("@Job", SqlDbType.NVarChar,30).Value = textBox15.Text;
                cmd.ExecuteNonQuery();
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Сatal". При необходимости она может быть перемещена или удалена.
                this.сatalTableAdapter.Fill(this.tikhonovTRDataSet.Сatal);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AdminUsers". При необходимости она может быть перемещена или удалена.
                this.adminUsersTableAdapter.Fill(this.tikhonovTRDataSet.AdminUsers);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Emp". При необходимости она может быть перемещена или удалена.
                this.empTableAdapter.Fill(this.tikhonovTRDataSet.Emp);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.StatTop". При необходимости она может быть перемещена или удалена.
                this.statTopTableAdapter.Fill(this.tikhonovTRDataSet.StatTop);
                textBox14.Clear();
                textBox15.Clear();
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

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Input_Supplies", conn);
                string sql = "select dbo.SummSup(@COD,@Quan);";
                var result = new SqlCommand(sql, conn);
                result.Parameters.AddWithValue("COD", Convert.ToInt32(textBox18.Text));
                result.Parameters.AddWithValue("Quan", Convert.ToInt32(textBox16.Text));
                var data = result.ExecuteScalar();
                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                DialogResult resultE;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                resultE = MessageBox.Show("Сделать заказ поставки на сумму: " + data.ToString(), "Сумма поставки", buttons);
                if (resultE == DialogResult.Yes)
                {
                    cmd.Parameters.Add("@IDCode", SqlDbType.Int).Value = Convert.ToInt32(textBox18.Text);
                    cmd.Parameters.Add("@Quan", SqlDbType.Int).Value = Convert.ToInt32(textBox16.Text);
                    cmd.Parameters.Add("@Cost", SqlDbType.Money).Value = 1;
                    cmd.Parameters.Add("@Time", SqlDbType.Date).Value = "1/1/1";
                    cmd.Parameters.Add("@Stat", SqlDbType.Bit).Value = 0;
                    cmd.ExecuteNonQuery();
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Сatal". При необходимости она может быть перемещена или удалена.
                    this.сatalTableAdapter.Fill(this.tikhonovTRDataSet.Сatal);
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AdminUsers". При необходимости она может быть перемещена или удалена.
                    this.adminUsersTableAdapter.Fill(this.tikhonovTRDataSet.AdminUsers);
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Emp". При необходимости она может быть перемещена или удалена.
                    this.empTableAdapter.Fill(this.tikhonovTRDataSet.Emp);
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.StatTop". При необходимости она может быть перемещена или удалена.
                    this.statTopTableAdapter.Fill(this.tikhonovTRDataSet.StatTop);
                }
                textBox18.Clear();
                textBox16.Clear();
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

        private void button8_Click(object sender, EventArgs e)
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
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = textBox23.Text;
                cmd.Parameters.Add("@Desc", SqlDbType.NVarChar, 100).Value = textBox21.Text;
                cmd.Parameters.Add("@Quant", SqlDbType.Int).Value = Convert.ToInt32(textBox19.Text);
                cmd.Parameters.Add("@Demand", SqlDbType.Float).Value = random;
                cmd.Parameters.Add("@Give", SqlDbType.Money).Value = Convert.ToDouble(textBox20.Text);
                cmd.Parameters.Add("@Get", SqlDbType.Money).Value = Convert.ToDouble(textBox22.Text);
                cmd.ExecuteNonQuery();
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Сatal". При необходимости она может быть перемещена или удалена.
                this.сatalTableAdapter.Fill(this.tikhonovTRDataSet.Сatal);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AdminUsers". При необходимости она может быть перемещена или удалена.
                this.adminUsersTableAdapter.Fill(this.tikhonovTRDataSet.AdminUsers);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Emp". При необходимости она может быть перемещена или удалена.
                this.empTableAdapter.Fill(this.tikhonovTRDataSet.Emp);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.StatTop". При необходимости она может быть перемещена или удалена.
                this.statTopTableAdapter.Fill(this.tikhonovTRDataSet.StatTop);
                textBox23.Clear();
                textBox21.Clear();
                textBox19.Clear();
                textBox20.Clear();
                textBox22.Clear();
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

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Delete__Products", conn);
                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                cmd.Parameters.Add("@Code", SqlDbType.Int).Value = Convert.ToInt32(textBox24.Text);
                cmd.ExecuteNonQuery();
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Сatal". При необходимости она может быть перемещена или удалена.
                this.сatalTableAdapter.Fill(this.tikhonovTRDataSet.Сatal);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AdminUsers". При необходимости она может быть перемещена или удалена.
                this.adminUsersTableAdapter.Fill(this.tikhonovTRDataSet.AdminUsers);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Emp". При необходимости она может быть перемещена или удалена.
                this.empTableAdapter.Fill(this.tikhonovTRDataSet.Emp);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.StatTop". При необходимости она может быть перемещена или удалена.
                this.statTopTableAdapter.Fill(this.tikhonovTRDataSet.StatTop);
                textBox24.Clear();
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

        private void button6_Click(object sender, EventArgs e)
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
                cmd.Parameters.Add("@IDSup", SqlDbType.Int).Value = Convert.ToInt32(textBox17.Text);
                cmd.Parameters.Add("@Stat", SqlDbType.Bit).Value = 1;
                cmd.ExecuteNonQuery();
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Сatal". При необходимости она может быть перемещена или удалена.
                this.сatalTableAdapter.Fill(this.tikhonovTRDataSet.Сatal);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AdminUsers". При необходимости она может быть перемещена или удалена.
                this.adminUsersTableAdapter.Fill(this.tikhonovTRDataSet.AdminUsers);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Emp". При необходимости она может быть перемещена или удалена.
                this.empTableAdapter.Fill(this.tikhonovTRDataSet.Emp);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.StatTop". При необходимости она может быть перемещена или удалена.
                this.statTopTableAdapter.Fill(this.tikhonovTRDataSet.StatTop);
                textBox17.Clear();
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

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Delete_Users", conn);
                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                cmd.Parameters.Add("@IDUs", SqlDbType.Int).Value = Convert.ToInt32(textBox25.Text);
                cmd.ExecuteNonQuery();
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Сatal". При необходимости она может быть перемещена или удалена.
                this.сatalTableAdapter.Fill(this.tikhonovTRDataSet.Сatal);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AdminUsers". При необходимости она может быть перемещена или удалена.
                this.adminUsersTableAdapter.Fill(this.tikhonovTRDataSet.AdminUsers);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Emp". При необходимости она может быть перемещена или удалена.
                this.empTableAdapter.Fill(this.tikhonovTRDataSet.Emp);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.StatTop". При необходимости она может быть перемещена или удалена.
                this.statTopTableAdapter.Fill(this.tikhonovTRDataSet.StatTop);
                textBox25.Clear();
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

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Delete__Orders", conn);
                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                cmd.Parameters.Add("@IDOrder", SqlDbType.Int).Value = Convert.ToInt32(textBox26.Text);
                cmd.ExecuteNonQuery();
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Сatal". При необходимости она может быть перемещена или удалена.
                this.сatalTableAdapter.Fill(this.tikhonovTRDataSet.Сatal);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.AdminUsers". При необходимости она может быть перемещена или удалена.
                this.adminUsersTableAdapter.Fill(this.tikhonovTRDataSet.AdminUsers);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.Emp". При необходимости она может быть перемещена или удалена.
                this.empTableAdapter.Fill(this.tikhonovTRDataSet.Emp);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tikhonovTRDataSet.StatTop". При необходимости она может быть перемещена или удалена.
                this.statTopTableAdapter.Fill(this.tikhonovTRDataSet.StatTop);
                textBox26.Clear();
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
