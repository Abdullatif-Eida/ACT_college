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
    public partial class subjects_form : Form
    {
        SqlDataAdapter adapter1;
        DataTable subjects;
        public subjects_form()
        {
            InitializeComponent();
        }

        private void subjects_form_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Select max(Subject_ID)+1 from Subjects", connect);
            SqlDataReader reader = command1.ExecuteReader();
            reader.Read();
            textBox15.Text = reader[0].ToString();
            connect.Close();

            DataTable dtt = new DataTable();
            SqlDataAdapter getid = new SqlDataAdapter("select * from Subjects", connect);
            getid.Fill(dtt);
            comboBox2.DataSource = dtt;
            comboBox2.DisplayMember = "Subject_ID";
            textBox14.DataBindings.Add("Text", dtt, "Teacher_ID");
            textBox13.DataBindings.Add("Text", dtt, "Title");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Insert into Subjects(Title,Teacher_ID)" +
                "values('" + textBox2.Text + "','" + textBox4.Text + "')", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Adding Subject done Successfully...");
            textBox2.Text = "";
            textBox4.Text = "";

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
            textBox4.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try { 
            int subjectid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("update Subjects SET Title='" + textBox13.Text +
                "' , Teacher_ID='" + textBox14.Text + "' where Subject_ID='" + subjectid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Editing Subject done Successfully...");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter a valid data");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try { 
            int subjectid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                    Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Delete from Subjects WHERE [Subject_ID]='" + subjectid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Subjects Deleted Successfully...");
            comboBox2.Text = "";
            textBox14.Text = "";
            textBox13.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure the record you want to delete doesn't used in any other table as Foreign key");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            textBox14.Text = ""; textBox13.Text = "";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            subjects = new DataTable();
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            adapter1 = new SqlDataAdapter("select * from Subjects", connect);
            adapter1.Fill(subjects);
            dataGridView1.DataSource = subjects;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Main_Form mainform = new Main_Form();
            mainform.Show();
            this.Close();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            try { 
            SqlCommandBuilder Sqlbuilder = new SqlCommandBuilder(adapter1);
            adapter1.Update(subjects);
            MessageBox.Show(" Saving is Done...");
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure you pressed on view all button");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button37_Click(object sender, EventArgs e)
        {

        }
    }
}
