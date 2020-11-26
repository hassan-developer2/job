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
    public partial class FrmCompanyProfile : Form
    {
        public FrmCompanyProfile()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clearFields();
            groupBoxFields.Enabled = true;
        }

        private void clearFields()
        {
            txtDescription.Clear();
            txtName.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataClassesJobDataContext db = new DataClassesJobDataContext();
             
                #region check if company name exists
                var queryResults = from c in db.CompanyProfiles
                                   where c.name == txtName.Text
                                   select c;
                if (queryResults.Any())
                {
                    MessageBox.Show(txtName.Text + " already exists");
                    return;
                }
                #endregion
                CompanyProfile company = new CompanyProfile();
                company.description = txtDescription.Text;
                company.name = txtName.Text;
                db.CompanyProfiles.InsertOnSubmit(company);
                db.SubmitChanges();
                MessageBox.Show("record saved!");
                clearFields();
                groupBoxFields.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSearchCompany frmCompanyProfile = new FrmSearchCompany();
            frmCompanyProfile.Show();

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
                    from comp in db.CompanyProfiles
                    where comp.id == Convert.ToInt16(cboId.Text)
                    select new { comp };
                if (queryResults.Any())
                {
                    txtName.Text = queryResults.FirstOrDefault().comp.name;
                    txtDescription.Text = queryResults.FirstOrDefault().comp.description;
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
                var savedCompany = context.CompanyProfiles.Where(r => r.id == Convert.ToInt16(cboId.Text));
                if (savedCompany.Any())
                {
                    var comp = savedCompany.First();
                    comp.name = txtName.Text;
                    comp.description = txtDescription.Text;

                    context.CompanyProfiles.DeleteOnSubmit(comp);

                    context.SubmitChanges();
                    MessageBox.Show("Record successfully deleted !");

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var context = new DataClassesJobDataContext())
            {
                var comp = context.CompanyProfiles.Where(r => r.id == Convert.ToInt16(cboId.Text));
                if (comp.Any())
                {
                    var com = comp.First();
                    com.name = txtName.Text;
                    com.description = txtDescription.Text;

                    context.SubmitChanges();
                    MessageBox.Show("Record successfully Updated !");
                    clearFields();
                }
            }
        }

        private void FrmCompanyProfile_Load(object sender, EventArgs e)
        {
            groupBoxFields.Enabled = false;
        }
    }
}
