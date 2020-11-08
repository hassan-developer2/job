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
    public partial class FrmJob : Form
    {
        public FrmJob()
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
                if (txtName.Text=="")
                {
                    MessageBox.Show("enter name first");
                    txtName.Focus();
                    return;
                }
              
                DataClassesJobDataContext db = new DataClassesJobDataContext();
                Job job = new Job();
                job.name = txtName.Text;
                job.jobTypeId = Convert.ToInt32(cboJobType.SelectedValue);
                db.Jobs.InsertOnSubmit(job);
                db.SubmitChanges();
                MessageBox.Show("record saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
                throw;
            }
        }

        private void FrmJob_Load(object sender, EventArgs e)
        {
            getDataInCboJobType();
        }

        private void getDataInCboJobType()
        {
            DataClassesJobDataContext db = new DataClassesJobDataContext();
            var queryResults = from j in db.JobTypes
                               select j;
            if (queryResults.Any())
            {
                cboJobType.DataSource = queryResults;
                cboJobType.DisplayMember = "name";
                cboJobType.ValueMember = "id";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSearchJob job = new FrmSearchJob();
            job.Show();
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
                    from job in db.Jobs
                    where job.id == Convert.ToInt16(cboId.Text)
                    select new { job };
                if (queryResults.Any())
                {
                    txtName.Text = queryResults.FirstOrDefault().job.name;
                    int jobTypeId = (int)queryResults.FirstOrDefault().job.jobTypeId;
                    //get job type name
                    string jobTypeName = db.JobTypes.Where(i => i.Id == jobTypeId).FirstOrDefault().name;
                    cboJobType.Text = jobTypeName;
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
                var savedJOb = context.Jobs.Where(r => r.id == Convert.ToInt16(cboId.Text));
                if (savedJOb.Any())
                {
                    var job = savedJOb.First();
                    job.name = txtName.Text;
                    job.jobTypeId =(int) cboJobType.SelectedValue;

                    context.Jobs.DeleteOnSubmit(job);

                    context.SubmitChanges();
                    MessageBox.Show("Record successfully deleted !");

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var context = new DataClassesJobDataContext())
            {
                var job = context.Jobs.Where(r => r.id == Convert.ToInt16(cboId.Text));
                if (job.Any())
                {
                    var jb = job.First();
                    jb.name = txtName.Text;
                    jb.jobTypeId =(int) cboJobType.SelectedValue;

                    context.SubmitChanges();
                    MessageBox.Show("Record successfully Updated !");
                    clearFields();
                }
            }
        }
    }
}
