using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using job.search;

namespace job
{
    public partial class FrmQuestion : Form
    {
        public FrmQuestion()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtName.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataClassesJobDataContext db = new DataClassesJobDataContext();
                Question question = new Question();
                question.question1 = txtName.Text;
                db.Questions.InsertOnSubmit(question);
                db.SubmitChanges();
                MessageBox.Show("saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSearchQuestion frmSearchQuestion = new FrmSearchQuestion();
            frmSearchQuestion.Show();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboId.Text == "")
                {
                    MessageBox.Show("select a value first and then click get data");
                    return;
                }
                string id = cboId.Text;
                DataClassesJobDataContext db = new DataClassesJobDataContext();

                var queryResults =
                    from question in db.Questions
                    where question.Id ==Convert.ToInt32( cboId.Text)
                    select new { question };
                if (queryResults.Any())
                { 
                    txtName.Text = queryResults.FirstOrDefault().question.question1;
                    //cboJobType.ValueMember = queryResults.FirstOrDefault().job.jobTypeId.ToString();
                    // txtName.Text = db.petitioners.Where(p => p.id == id).FirstOrDefault().name;   //works fine
                }
                else
                {
                    MessageBox.Show("no data found", "alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var context = new DataClassesJobDataContext())
            {
                var savedQuestion = context.Questions.Where(r => r.Id == Convert.ToInt16(cboId.Text));
                if (savedQuestion.Any())
                {
                    var ques = savedQuestion.First();
                    ques.question1 = txtName.Text;
                   
                    context.Questions.DeleteOnSubmit(ques);
                    context.SubmitChanges();
                    MessageBox.Show("Record successfully deleted !");

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var context = new DataClassesJobDataContext())
            {
                var ques = context.Questions.Where(r => r.Id == Convert.ToInt16(cboId.Text));
                if (ques.Any())
                {
                    var com = ques.First();
                    com.question1 = txtName.Text;

                    context.SubmitChanges();
                    MessageBox.Show("Record successfully Updated !");
                    ClearFields();
                }
            }
        }
    }
}
