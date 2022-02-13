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
    public partial class Session_Form : Form
    {
        SqlDataAdapter adapter1;
        DataTable sessions;
        public Session_Form()
        {
            InitializeComponent();
        }
        private void Session_Form_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                   Initial Catalog=ACTCollege_database; Integrated Security=true;");
            
            DataTable dtt = new DataTable();
            SqlDataAdapter getid = new SqlDataAdapter("select * from Session", connect);
            getid.Fill(dtt);
            comboBox2.DataSource = dtt;
            comboBox1.DataSource = dtt;
            comboBox2.DisplayMember = "Subject_ID";
            comboBox1.DisplayMember = "Class_ID";
            textBox13.DataBindings.Add("Text", dtt, "Class_data");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Insert into Session(Subject_ID,Class_ID,Class_data)" +
                "values('" + textBox15.Text + "','" + textBox4.Text + "','" + textBox2.Text + "')", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Adding Session done Successfully...");
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
            int sessionsid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("update Session SET Class_data='" + textBox13.Text +
                "' where Subject_ID='" + sessionsid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Editing Session done Successfully...");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter a valid data");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try { 
            int sessionsid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Delete from Session WHERE [Subject_ID]='" + sessionsid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Session Deleted Successfully...");
            comboBox1.Text = "";
            comboBox2.Text = ""; textBox13.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure the record you want to delete doesn't used in any other table as Foreign key");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = ""; comboBox2.Text = ""; textBox13.Text = "";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            sessions = new DataTable();
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            adapter1 = new SqlDataAdapter("select * from Session", connect);
            adapter1.Fill(sessions);
            dataGridView1.DataSource = sessions;
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
            adapter1.Update(sessions);
            MessageBox.Show(" Saving is Done...");
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure you pressed on view all button");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void panel35_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
