using System;
using System.Windows.Forms;
using Assignment.Forms;

namespace Assignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuestionA_Click(object sender, EventArgs e) => new QuestionAForm().Show();
        private void btnQuestionB_Click(object sender, EventArgs e) => new QuestionBForm().Show();
        private void btnQuestionC_Click(object sender, EventArgs e) => new QuestionCForm().Show();
        private void btnQuestionD_Click(object sender, EventArgs e) => new QuestionDForm().Show();
        private void btnQuestionE_Click(object sender, EventArgs e) => new QuestionEForm().Show();
        private void btnQuestionF_Click(object sender, EventArgs e) => new QuestionFForm().Show();
        private void btnQuestionG_Click(object sender, EventArgs e) => new QuestionGForm().Show();
        private void btnSqlServer2022_Click(object sender, EventArgs e) => new SqlServer2022Form().Show();

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
