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
    public partial class Terms_Form : Form
    {
        SqlDataAdapter adapter1;
        DataTable terms;
        public Terms_Form()
        {
            InitializeComponent();
        }

        private void Terms_Form_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Select max(Term_ID)+1 from Terms", connect);
            SqlDataReader reader = command1.ExecuteReader();
            reader.Read();
            textBox15.Text = reader[0].ToString();
            connect.Close();

            DataTable dtt = new DataTable();
            SqlDataAdapter getid = new SqlDataAdapter("select * from Terms", connect);
            getid.Fill(dtt);
            comboBox2.DataSource = dtt;
            comboBox2.DisplayMember = "Term_ID";

            textBox13.DataBindings.Add("Text", dtt, "Name");
            textBox12.DataBindings.Add("Text", dtt, "duration");
            textBox14.DataBindings.Add("Text", dtt, "Year_ID");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Insert into Terms(Name,duration,Year_ID)" +
                "values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Adding Terms done Successfully...");
            textBox2.Text = "";
            textBox3.Text = "";
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
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try { 
            int termsid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("update Terms SET Name='" + textBox13.Text + 
                "' , duration='" + textBox12.Text + "' , Year_ID='" + textBox14.Text + 
                "' where Term_ID='" + termsid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Editing Terms done Successfully...");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter a valid data");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try { 
            int termsid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Delete from Terms WHERE [Term_ID]='" + termsid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Terms Deleted Successfully...");
            comboBox2.Text = "";
            textBox14.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure the record you want to delete doesn't used in any other table as Foreign key");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            terms = new DataTable();
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            adapter1 = new SqlDataAdapter("select * from Terms", connect);
            adapter1.Fill(terms);
            dataGridView1.DataSource = terms;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Main_Form mainform = new Main_Form();
            mainform.Show();
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            textBox14.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try { 
            SqlCommandBuilder Sqlbuilder = new SqlCommandBuilder(adapter1);
            adapter1.Update(terms);
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

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
