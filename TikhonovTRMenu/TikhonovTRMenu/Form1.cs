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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
   DialogResult dialog = MessageBox.Show(
    "Вы действительно хотите выйти из программы?",
    "Завершение программы",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning
   );
   if(dialog == DialogResult.Yes) {
    e.Cancel = false;
   }
   else {
    e.Cancel = true;
   }
  }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "ТихоновM")
            {
                Form newForm = new Form3();
                newForm.Show();
            }
            else
            {
                DialogResult resultE;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                resultE = MessageBox.Show("Введен неверный пароль менеджера", "Ошибка авторизации", buttons);
            }
            textBox3.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-8OAHTJ6\SQLEXPRESS;Initial Catalog=TikhonovTR;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                string sql = "select dbo.LogPas(@Log,@Pas);";
                var result = new SqlCommand(sql, connect);
                result.Parameters.AddWithValue("Log", textBox1.Text);
                result.Parameters.AddWithValue("Pas", textBox2.Text);
                var data = result.ExecuteScalar();
                if (data.ToString()=="True")
                {
                    Form5 newForm = new Form5(Convert.ToInt32(textBox2.Text));
                    newForm.Show();
                }
                else {
                    DialogResult resultE;
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    resultE = MessageBox.Show("Введен неверный логин или пароль", "Ошибка авторизации", buttons);
                }
                textBox1.Clear();
                textBox2.Clear();
                connect.Close();
            }
            catch {
                DialogResult resultE;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                resultE = MessageBox.Show("Введен неверный логин или пароль", "Ошибка авторизации", buttons);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "ТихоновA")
            {
                Form2 newForm = new Form2();
                newForm.Show();

            }
            else
            {
                DialogResult resultE;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                resultE = MessageBox.Show("Введен неверный пароль администратора", "Ошибка авторизации", buttons);
            }
            textBox4.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Создать объект Command для вызова процедуры Get_Employee_Info.
                SqlCommand cmd = new SqlCommand("dbo.Input_Users", conn);

                // Вид Command является StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;

                // Добавить параметр @p_Emp_Id и прикрепить к нему значение 100.
                cmd.Parameters.Add("@Sur", SqlDbType.NVarChar, 30).Value = textBox5.Text;
                cmd.Parameters.Add("@First", SqlDbType.NVarChar, 30).Value = textBox6.Text;
                cmd.Parameters.Add("@Last", SqlDbType.NVarChar, 30).Value = textBox7.Text;
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 15).Value = textBox8.Text;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 30).Value = textBox9.Text;

                // Выполнить процедуру.
                cmd.ExecuteNonQuery();
                string sql = "select top 1 IDUsers,Email from Users order by IDUsers DESC";
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = sql;
                using (DbDataReader reader = cmd2.ExecuteReader())
                {
                    reader.Read();
                    int IDUsers = reader.GetOrdinal("IDUsers");
                    int Email = reader.GetOrdinal("Email");
                    string resultE1 = reader.GetInt32(IDUsers).ToString();
                    string resultE2 = reader.GetString(Email);
                    DialogResult resultE;
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    resultE = MessageBox.Show("Ваша почта: "+resultE2+ " Ваш пароль: " + resultE1, "Не сообщайте свои данные", buttons);

                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();

                }
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

           
            /*Form4 newForm = new Form4();
            newForm.Show();
            this.Hide();*/
        }
    }
}
