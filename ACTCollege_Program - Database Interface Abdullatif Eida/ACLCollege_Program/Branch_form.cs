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
    public partial class Branch_form : Form
    {
        SqlDataAdapter adapter1;
        DataTable branches;
        public Branch_form()
        {
            InitializeComponent();
        }
        private void Brunch_form_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Select max(Branch_ID)+1 from Branches", connect);
            SqlDataReader reader = command1.ExecuteReader();
            reader.Read();
            textBox15.Text = reader[0].ToString();
            connect.Close();

            DataTable dtt = new DataTable();
            SqlDataAdapter getid = new SqlDataAdapter("select * from Branches", connect);
            getid.Fill(dtt);
            comboBox2.DataSource = dtt;
            comboBox2.DisplayMember = "Branch_ID";

            textBox14.DataBindings.Add("Text", dtt, "Name");
            textBox12.DataBindings.Add("Text", dtt, "Address");
            textBox13.DataBindings.Add("Text", dtt, "College_ID");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Insert into Branches(Name,Address,College_ID)" +
                "values('" + textBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "')", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Adding Branche done Successfully...");
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
            int brachid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("update Branches SET Name='" + textBox14.Text + 
                "' , Address='" + textBox12.Text + "' , College_ID='" + textBox13.Text +
                "' where Branch_ID='" + brachid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Editing Branch done Successfully...");
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
            int brachid = int.Parse(comboBox2.Text);
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            SqlCommand command1 = new SqlCommand("Delete from Branches WHERE [Branch_ID]='" + brachid + "'", connect);
            command1.ExecuteNonQuery();
            MessageBox.Show("Branch Deleted Successfully...");
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
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            textBox14.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            branches = new DataTable();
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-V9AF34JG\SQLEXPRESS;
                Initial Catalog=ACTCollege_database; Integrated Security=true;");
            connect.Open();
            adapter1 = new SqlDataAdapter("select * from Branches", connect);
            adapter1.Fill(branches);
            dataGridView1.DataSource = branches;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            try {
            SqlCommandBuilder Sqlbuilder = new SqlCommandBuilder(adapter1);
            adapter1.Update(branches);
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
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAnnouncement_Click(object sender, EventArgs e)
        {

        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel38_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button36_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Main_Form mainform = new Main_Form();
            mainform.Show();
            this.Close();
        }

        private void btnCalendar_Click_1(object sender, EventArgs e)
        {
            Student_form studentform = new Student_form();
            studentform.Show();
            this.Close();
        }

        private void btnAnnouncement_Click_1(object sender, EventArgs e)
        {
            Teacher_Form teacherform = new Teacher_Form();
            teacherform.Show();
            this.Close();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            subjects_form subjectform = new subjects_form();
            subjectform.Show();
            this.Close();
        }

        private void btnMessages_Click(object sender, EventArgs e)
        {
            Classes_Form classesform = new Classes_Form();
            classesform.Show();
            this.Close();
        }

        private void btnForum_Click(object sender, EventArgs e)
        {
            Session_Form sessionForm = new Session_Form();
            sessionForm.Show();
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Faculties_Form facultiesform = new Faculties_Form();
            facultiesform.Show();
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Branch_form branchesform = new Branch_form();
            branchesform.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Terms_Form termsform = new Terms_Form();
            termsform.Show();
            this.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Year_Form yearform = new Year_Form();
            yearform.Show();
            this.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            YearClass_Form yearclassform = new YearClass_Form();
            yearclassform.Show();
            this.Close();
        }
    }
}
