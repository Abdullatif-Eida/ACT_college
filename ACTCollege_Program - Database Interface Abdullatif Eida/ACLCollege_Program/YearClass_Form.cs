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
    public partial class YearClass_Form : Form
    {
        SqlDataAdapter adapter1;
        DataTable yearclasses;
        public YearClass_Form()
        {
            InitializeComponent();
        }

        private void YearClass_Form_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
         
            DataTable dtt = new DataTable();
            SqlDataAdapter getid = new SqlDataAdapter("select * from Class_year", connect);
            getid.Fill(dtt);
            comboBox2.DataSource = dtt;
            comboBox2.DisplayMember = "Year_ID";
            textBox14.DataBindings.Add("Text", dtt, "Class_ID");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Insert into Class_year(Year_ID,Class_ID)" +
                "values('" + textBox15.Text + "','" + textBox4.Text + "')", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Adding done Successfully...");
            textBox15.Text = "";
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
            textBox15.Text = "";  
            textBox4.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try { 
            int yearid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("update Class_year SET Class_ID='" +
                textBox14.Text + "' where Year_ID='" + yearid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Editing done Successfully...");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter a valid data");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try { 
            int yearid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Delete from Class_year WHERE [Year_ID]='" + yearid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Deleting done Successfully...");
            comboBox2.Text = "";
            textBox14.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure the record you want to delete doesn't used in any other table as Foreign key");
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            textBox14.Text = "";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            yearclasses = new DataTable();
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            adapter1 = new SqlDataAdapter("select * from Class_year", connect);
            adapter1.Fill(yearclasses);
            dataGridView1.DataSource = yearclasses;
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
            adapter1.Update(yearclasses);
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

        private void button20_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button36_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
