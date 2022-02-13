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
    public partial class Exams_form : Form
    {
        SqlDataAdapter adapter1;
        DataTable exams;
        public Exams_form()
        {
            InitializeComponent();
        }

        private void Exams_form_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Select max(Exam_ID)+1 from Exam", connect);
            SqlDataReader reader = command1.ExecuteReader();
            reader.Read();
            textBox15.Text = reader[0].ToString();
            connect.Close();

            DataTable dtt = new DataTable();
            SqlDataAdapter getid = new SqlDataAdapter("select * from Exam", connect);
            getid.Fill(dtt);
            comboBox2.DataSource = dtt;
            comboBox2.DisplayMember = "Exam_ID";

            textBox14.DataBindings.Add("Text", dtt, "Subject_ID");
            textBox12.DataBindings.Add("Text", dtt, "Student_ID");
            textBox13.DataBindings.Add("Text", dtt, "Term_ID");
            textBox10.DataBindings.Add("Text", dtt, "Mark");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                    Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Insert into Exam(Subject_ID,Student_ID,Mark,Term_ID)" +
                "values('" + textBox2.Text + "','" + textBox4.Text + "','" + textBox7.Text + "','" + textBox3.Text + "')", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Adding Exam done Successfully...");
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
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
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = ""; 
            textBox7.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try { 
            int examid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("update Exam SET Subject_ID='" + textBox14.Text +
                "' , Student_ID='" + textBox12.Text + "' , Mark='" + textBox10.Text + 
                "' , Term_ID='" + textBox13.Text + "' where Exam_ID='" + examid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Editing Exam done Successfully...");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter a valid data");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try { 
            int examid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                    Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Delete from Exam WHERE [Exam_ID]='" + examid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Exams Deleted done Successfully...");
            comboBox2.Text = "";
            textBox14.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox10.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure the record you want to delete doesn't used in any other table as Foreign key");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            textBox14.Text = ""; textBox12.Text = ""; textBox13.Text = ""; textBox10.Text = "";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            exams = new DataTable();
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            adapter1 = new SqlDataAdapter("select * from Exam", connect);
            adapter1.Fill(exams);
            dataGridView1.DataSource = exams;
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            try { 
            SqlCommandBuilder Sqlbuilder = new SqlCommandBuilder(adapter1);
            adapter1.Update(exams);
            MessageBox.Show(" Saving is Done...");
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure you pressed on view all button");
            }
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            Main_Form mainform = new Main_Form();
            mainform.Show();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
