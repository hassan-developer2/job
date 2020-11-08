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
    public partial class FrmApplyJob : Form
    {
        public FrmApplyJob()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var random = System.Guid.NewGuid().ToString().Replace("-", null);
            cboId.Text = random;
            dataGridViewJob.Refresh();
        }

        private void FrmApplyJob_Load(object sender, EventArgs e)
        {
            
            DataClassesJobDataContext db = new DataClassesJobDataContext();
            var queryResultsJob = from j in db.Jobs
                                  select j;
            if (queryResultsJob.Any())
            {
                cboJob.DataSource = queryResultsJob;
                cboJob.ValueMember = "id";
                cboJob.DisplayMember = "name";
                
            }

           
            var queryResultsComp = from c in db.CompanyProfiles
                                   select c;
            if (queryResultsComp.Any())
            {
                cboCompany.DataSource = queryResultsComp;
                cboCompany.DisplayMember = "name";
                cboCompany.ValueMember = "id";
            }
            //todo get data in list box of todays date
            var queryResultsListBox = from trans in db.ApplyJobs
                                      where trans.Transdate == Convert.ToDateTime(dtpDate.Text)
                                      select trans.Id;
                                      
            if (queryResultsListBox.Any())
            {
                listBoxJob.DataSource = queryResultsListBox;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataClassesJobDataContext db = new DataClassesJobDataContext();
                ApplyJobDetail jobDetail = new ApplyJobDetail();
                //check if item already exists in sales detail table with same transId
                //var item = from i in db.ApplyJobDetails
                //           where i.ItemId.Equals(DropDownListItemName.SelectedItem.Value) && i.SaleId == LabelSaleId.Text
                //           select i;
                //if (item.Any())
                //{
                //    LabelMessage.ForeColor = System.Drawing.Color.Red;
                //    LabelMessage.Text = DropDownListItemName.SelectedItem.Text + " already exists. please update or delete it to make a new entry";
                //    // txtNetTotal.Text = "0";
                //    return;
                //}
                // generate Sale Id manually by random
                // var random = Guid.NewGuid().ToString().Replace("-", null);
                if (cboId.Text == "*" || cboId.Text == "")
                {
                    MessageBox.Show("please click the new button");
                    return;
                }


                /*
                 vendor.ItemTypeId = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                    vendor.itemTypeName = DropDownList1.SelectedItem.Text;

                insert data into master table (sale) before inserting data into child table(saleDetail)
                 */



                #region insert data into master tabel
                // insert data into master table
                var queryResults = from s in db.ApplyJobs
                                   where s.Id == cboId.Text
                                   select s;
                if (queryResults.Any())
                {
                    MessageBox.Show("id already exists");
                    return;
                }
                else
                {
                    //insert new  transId
                    ApplyJob job = new ApplyJob();
                    job.Id = cboId.Text;
                    job.Transdate = Convert.ToDateTime(dtpDate.Text);

                    db.ApplyJobs.InsertOnSubmit(job);
                    db.SubmitChanges();
                    
                }
                #endregion

                jobDetail.JobId = (int)cboJob.SelectedValue;
                jobDetail.CompanyId = (int)cboCompany.SelectedValue;
                jobDetail.ApplyJobId = cboId.Text;
                db.ApplyJobDetails.InsertOnSubmit(jobDetail);
                db.SubmitChanges();
                MessageBox.Show("item added in detail");


                // bind saleDetail data to grid view


                var applyDetail = from s in db.ApplyJobDetails
                                  where s.ApplyJobId == cboId.Text
                                  select s;
                // var list = new List<object> { queryResults };
                dataGridViewJob.DataSource = applyDetail;
                // show notification for delete
                notifyIconRightClick.ShowBalloonTip(3, "Tip", "right click on datagrid to get context menu", ToolTipIcon.Info);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void contextMenuStripJob_MouseClick(object sender, MouseEventArgs e)
        {
            // delete the record
            string id = dataGridViewJob.Rows[0].Cells["Id"].Value.ToString();
            int idInt = Convert.ToInt32(id);
            try
            {
                using (var context = new DataClassesJobDataContext())
                {
                    var savedJob = context.ApplyJobDetails.Where(r => r.Id == idInt);
                    if (savedJob.Any())
                    {
                        var cou = savedJob.First();
                        cou.Id = idInt;

                        cou.ApplyJobId = cboId.Text;
                        cou.CompanyId = Convert.ToInt32(cboCompany.SelectedValue);

                        cou.JobId =Convert.ToInt32( cboJob.SelectedValue);

                        context.ApplyJobDetails.DeleteOnSubmit(cou);

                        context.SubmitChanges();
                        MessageBox.Show("Record successfully deleted !");
                        dataGridViewJob.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSearchApplyJob job = new FrmSearchApplyJob();
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
                string id = cboId.Text;
                DataClassesJobDataContext db = new DataClassesJobDataContext();

                var queryResults =
                    from job in db.ApplyJobs
                    where job.Id == cboId.Text
                    select new { job };
                if (queryResults.Any())
                {
                    string jobName, companyName;
                    int jobId, compId;
                    dtpDate.Text = queryResults.FirstOrDefault().job.Transdate.ToString();
                  
                  //  jobId =Convert.ToInt32( db.ApplyJobDetails.Where(j => j.ApplyJobId == (queryResults.FirstOrDefault().job.Id)).FirstOrDefault().ApplyJobId);

                    // look at how query is matched . we get company id by matching from parent and childs table
                    // compId = Convert.ToInt32(db.ApplyJobDetails.Where(j => j.CompanyId == queryResults.FirstOrDefault().job.ApplyJobDetails.FirstOrDefault().CompanyId));
                    //compId = Convert.ToInt32(db.ApplyJobDetails.Where(j => j.ApplyJobId == queryResults.FirstOrDefault().job.ApplyJobDetails.FirstOrDefault().ApplyJobId).FirstOrDefault().CompanyId);

                    //jobName = db.Jobs.Where(j => j.id == jobId).FirstOrDefault().name;
                    //companyName = db.CompanyProfiles.Where(c => c.id == compId).FirstOrDefault().name;
                    //cboCompany.Text = companyName;
                    //cboJob.Text = jobName;
                    // populate datagrid
                    var queryResultsGrid = from j in db.ApplyJobDetails
                                           where j.ApplyJobId == cboId.Text
                                           select j;
                    if (queryResultsGrid.Any())
                    {
                        dataGridViewJob.DataSource = queryResultsGrid;
                    }
                    
                    
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
                var savedJOb = context.ApplyJobs.Where(r => r.Id == cboId.Text);
                if (savedJOb.Any())
                {
                    var job = savedJOb.First();
                    job.Id = (string)cboId.SelectedValue;
                    job.Transdate = Convert.ToDateTime( dtpDate.Text);
                
                    context.ApplyJobs.DeleteOnSubmit(job);

                    context.SubmitChanges();
                    MessageBox.Show("Record successfully deleted !");

                }
                else
                {
                    MessageBox.Show("no id selected");
                }
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
           
            //String idSubString = id.Substring(7, 32);
            try
            {
                if (listBoxJob.Items[0].ToString()=="")
                {
                    MessageBox.Show("select a value first and then click get data");
                    return;
                }
                String id = listBoxJob.Items[0].ToString();
                DataClassesJobDataContext db = new DataClassesJobDataContext();

                var queryResults =
                    from job in db.ApplyJobs
                    where job.Id == id
                    select new { job };
                if (queryResults.Any())
                {
                   
                    dtpDate.Text = queryResults.FirstOrDefault().job.Transdate.ToString();

                    //  jobId =Convert.ToInt32( db.ApplyJobDetails.Where(j => j.ApplyJobId == (queryResults.FirstOrDefault().job.Id)).FirstOrDefault().ApplyJobId);

                    // look at how query is matched . we get company id by matching from parent and childs table
                    // compId = Convert.ToInt32(db.ApplyJobDetails.Where(j => j.CompanyId == queryResults.FirstOrDefault().job.ApplyJobDetails.FirstOrDefault().CompanyId));
                    //compId = Convert.ToInt32(db.ApplyJobDetails.Where(j => j.ApplyJobId == queryResults.FirstOrDefault().job.ApplyJobDetails.FirstOrDefault().ApplyJobId).FirstOrDefault().CompanyId);

                    //jobName = db.Jobs.Where(j => j.id == jobId).FirstOrDefault().name;
                    //companyName = db.CompanyProfiles.Where(c => c.id == compId).FirstOrDefault().name;
                    //cboCompany.Text = companyName;
                    //cboJob.Text = jobName;
                    // populate datagrid
                    var queryResultsGrid = from j in db.ApplyJobDetails
                                           where j.ApplyJobId == id
                                           select j;
                    if (queryResultsGrid.Any())
                    {
                        dataGridViewJob.DataSource = queryResultsGrid;
                    }


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

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
