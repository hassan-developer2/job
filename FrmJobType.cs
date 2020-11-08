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
    public partial class FrmJobType : Form
    {
        public FrmJobType()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void clearFields()
        {
            txtName.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataClassesJobDataContext db = new DataClassesJobDataContext();
                JobType jobType = new JobType();
                jobType.name = txtName.Text;
                db.JobTypes.InsertOnSubmit(jobType);
                db.SubmitChanges();
                MessageBox.Show("record saved!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSearchJobType frmSearch = new FrmSearchJobType();
            frmSearch.Show();
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
                int id = Convert.ToInt16(cboId.Text);
                DataClassesJobDataContext db = new DataClassesJobDataContext();

                var queryResults =
                    from j in db.JobTypes
                    where j.Id == Convert.ToInt16(cboId.Text)
                    select new { j };
                if (queryResults.Any())
                {
                    txtName.Text = queryResults.FirstOrDefault().j.name;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var context = new DataClassesJobDataContext())
            {
                var job = context.JobTypes.Where(r => r.Id == Convert.ToInt16(cboId.Text));
                if (job.Any())
                {
                    var ans = job.First();
                    ans.name = txtName.Text;
                    

                    context.SubmitChanges();
                    MessageBox.Show("Record successfully Updated !");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var context = new DataClassesJobDataContext())
            {
                var savedJob = context.JobTypes.Where(r => r.Id == Convert.ToInt16(cboId.Text));
                if (savedJob.Any())
                {
                    var job = savedJob.First();
                    job.name = txtName.Text;

                    context.JobTypes.DeleteOnSubmit(job);

                    context.SubmitChanges();
                    MessageBox.Show("Record successfully deleted !");

                }
            }
        }
    }
}
