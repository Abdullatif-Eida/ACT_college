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
    public partial class Student_form : Form
    {

        SqlDataAdapter adapter1;
        DataTable students;
        public Student_form()
        {
            InitializeComponent();
        }
        private void Student_form_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Select max(Student_ID)+1 from Students", connect);
            SqlDataReader reader = command1.ExecuteReader();
            reader.Read();
            textBox15.Text = reader[0].ToString();
            connect.Close();

            DataTable dtt = new DataTable();
            SqlDataAdapter getid = new SqlDataAdapter("select * from Students", connect);
            getid.Fill(dtt);
            comboBox2.DataSource = dtt;
            comboBox2.DisplayMember = "Student_ID";

            textBox14.DataBindings.Add("Text", dtt, "Name");
            textBox12.DataBindings.Add("Text", dtt, "Address");
            textBox13.DataBindings.Add("Text", dtt, "Birth_of_date");
            textBox10.DataBindings.Add("Text", dtt, "Phone");
            textBox11.DataBindings.Add("Text", dtt, "Gender");
            textBox9.DataBindings.Add("Text", dtt, "faculties_ID");
            textBox1.DataBindings.Add("Text", dtt, "Class_ID");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 =
                new SqlCommand("Insert into Students(Name,Birth_of_date,Address,Gender,Phone,faculties_ID,Class_ID)" +
                "values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text +
                "','"+ textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + 
                "','" + textBox8.Text + "')", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Adding Student done Successfully...");
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            String id = textBox15.Text;
            int newid = int.Parse(id) + 1;
            textBox15.Text = newid.ToString();
            connect.Close();
            }
            catch (Exception )
            {
                MessageBox.Show("Please Enter a valid data");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try { 
            int studentid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                    Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("update Students SET Name='"+ textBox14.Text +
                "' , Address='" + textBox12.Text + "' , Birth_of_date='" + textBox13.Text +
                "' , Phone='" + textBox10.Text + "' , Gender='" + textBox11.Text + "' , faculties_ID='" + 
                textBox9.Text + "' , Class_ID='" + textBox1.Text + "' where Student_ID='" + studentid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Editing Student done Successfully...");
            }
            catch (Exception )
            {
                MessageBox.Show("Please Enter a valid data");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try { 
            int studentid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Delete from Students WHERE [Student_ID]='" + studentid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show(" Students Deleted Successfully...");
            comboBox2.Text = "";
            textBox14.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox9.Text = "";
            textBox1.Text = "";
            }
            catch (Exception )
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
            textBox9.Text = "";
            textBox1.Text = "";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Main_Form mainform = new Main_Form();
            mainform.Show();
            this.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            students = new DataTable();
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            adapter1 = new SqlDataAdapter("select * from Students", connect);
            adapter1.Fill(students);
            dataGridView1.DataSource = students;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            try { 
            SqlCommandBuilder Sqlbuilder = new SqlCommandBuilder(adapter1);
            adapter1.Update(students);
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

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
