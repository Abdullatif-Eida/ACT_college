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

    public partial class Year_Form : Form
    {
        SqlDataAdapter adapter1;
        DataTable years;
        public Year_Form()
        {
            InitializeComponent();
        }

        private void Year_Form_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Select max(Year_ID)+1 from Year", connect);
            SqlDataReader reader = command1.ExecuteReader();
            reader.Read();
            textBox15.Text = reader[0].ToString();
            connect.Close();

            DataTable dtt = new DataTable();
            SqlDataAdapter getid = new SqlDataAdapter("select * from Year", connect);
            getid.Fill(dtt);
            comboBox2.DataSource = dtt;
            comboBox2.DisplayMember = "Year_ID";

            textBox14.DataBindings.Add("Text", dtt, "Year");
            textBox13.DataBindings.Add("Text", dtt, "Quarter_of_the_year");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Insert into Year(Year,Quarter_of_the_year)" +
                "values('" + textBox4.Text + "','" + textBox2.Text + "')", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Adding year done Successfully...");
            textBox2.Text = "";
            textBox4.Text = "";
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
            textBox4.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try { 
            int yearid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("update Year SET Year='" + textBox14.Text +
                "' , Quarter_of_the_year='" + textBox13.Text + "' where Year_ID='" + yearid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Editing Year done Successfully...");
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
            SqlCommand command1 = new SqlCommand("Delete from Year WHERE [Year_ID]='" + subjectid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Year Deleted Successfully...");
            comboBox2.Text = "";
            textBox14.Text = "";
            textBox13.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure the record you want to delete doesn't used in any other table as Foreign key");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            years = new DataTable();
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                    Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            adapter1 = new SqlDataAdapter("select * from Year", connect);
            adapter1.Fill(years);
            dataGridView1.DataSource = years;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            textBox14.Text = "";
            textBox13.Text = "";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            try { 
            SqlCommandBuilder Sqlbuilder = new SqlCommandBuilder(adapter1);
            adapter1.Update(years);
            MessageBox.Show(" Saving is Done...");
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure you pressed on view all button");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Main_Form mainform = new Main_Form();
            mainform.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button52_Click(object sender, EventArgs e)
        {

        }
    }
}
