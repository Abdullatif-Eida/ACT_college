using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACLCollege_Program
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }
        private void btnCalendar_Click(object sender, EventArgs e)
        {
            Student_form studentform = new Student_form();
            studentform.Show();
        }
        private void button10_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAnnouncement_Click(object sender, EventArgs e)
        {
            Teacher_Form teacherform = new Teacher_Form();
            teacherform.Show();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Branch_form branchesform = new Branch_form();
            branchesform.Show();
        }
        private void btnCourses_Click(object sender, EventArgs e)
        {
            subjects_form subjectform = new subjects_form();
            subjectform.Show();
        }
        private void btnForum_Click(object sender, EventArgs e)
        {
            Session_Form sessionForm = new Session_Form();
            sessionForm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Faculties_Form facultiesform = new Faculties_Form();
            facultiesform.Show();
        }
        private void btnMessages_Click(object sender, EventArgs e)
        {
            Classes_Form classesform = new Classes_Form();
            classesform.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Terms_Form termsform = new Terms_Form();
            termsform.Show();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            Year_Form yearform = new Year_Form();
            yearform.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            YearClass_Form yearclassform = new YearClass_Form();
            yearclassform.Show();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Exams_form examform = new Exams_form();
            examform.Show();
        }
        private void button12_Click_1(object sender, EventArgs e)
        {
            Continuous_assessments CA = new Continuous_assessments();
            CA.Show();
        }
        private void button12_Click(object sender, EventArgs e)
        {

        }
        private void Main_Form_Load(object sender, EventArgs e)
        {

        }
        private void Label9_Click(object sender, EventArgs e)
        {

        }
    }
}
