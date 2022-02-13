using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ACLCollege_Program
{

    public partial class Teacher_Form : Form
    {
        SqlDataAdapter adapter1;
        DataTable teachers;
        public Teacher_Form()
        {
            InitializeComponent();
        }

        private void Teacher_Form_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Select max(Teacher_ID)+1 from Teachers", connect);
            SqlDataReader reader = command1.ExecuteReader();
            reader.Read();
            textBox15.Text = reader[0].ToString();
            connect.Close();

            DataTable dtt = new DataTable();
            SqlDataAdapter getid = new SqlDataAdapter("select * from Teachers", connect);
            getid.Fill(dtt);
            comboBox2.DataSource = dtt;
            comboBox2.DisplayMember = "Teacher_ID";

            textBox14.DataBindings.Add("Text", dtt, "Name");
            textBox12.DataBindings.Add("Text", dtt, "Address");
            textBox13.DataBindings.Add("Text", dtt, "Date_of_hiring");
            textBox10.DataBindings.Add("Text", dtt, "Salary");
            textBox11.DataBindings.Add("Text", dtt, "Gender");
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
                connect.Open();
                SqlCommand command1 = new SqlCommand("Insert into Teachers(Name,Gender,Salary,Date_of_hiring,Address)" +
                    "values('" + textBox2.Text + "','" + textBox5.Text + "','" + textBox7.Text +
                           "','" + textBox3.Text + "','" + textBox4.Text + "')", connect);
                command1.ExecuteNonQuery();
                MessageBox.Show("Adding Teacher done Successfully...");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                String id = textBox15.Text;
                int newid = int.Parse(id) + 1;
                textBox15.Text = newid.ToString();
                connect.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter a valid data");
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = ""; textBox5.Text = ""; textBox7.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
            int teacherid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("update Teachers SET Name='" + textBox14.Text +
                "' , Address='" + textBox12.Text + "' , Date_of_hiring='" + textBox13.Text +
                "' , Salary='" + textBox10.Text + "' , Gender='" + textBox11.Text + 
                "' where Teacher_ID='" + teacherid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Editing Teacher done Successfully...");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter a valid data");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
            int teacherid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Delete from Teachers WHERE [Teacher_ID]='" + teacherid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show(" Teacher Deleted Successfully...");
            comboBox2.Text = "";
            textBox14.Text = "";
            textBox12.Text = "";
            textBox13.Text = ""; textBox10.Text = ""; textBox11.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure the record you want to delete doesn't used in any other table as Foreign key");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            textBox14.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            teachers = new DataTable();
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            adapter1 = new SqlDataAdapter("select * from Teachers", connect);
            adapter1.Fill(teachers);
            dataGridView1.DataSource = teachers;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Main_Form mainform = new Main_Form();
            mainform.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
            SqlCommandBuilder Sqlbuilder = new SqlCommandBuilder(adapter1);
            adapter1.Update(teachers);
            MessageBox.Show(" Saving is Done...");
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure you pressed on view all button");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
