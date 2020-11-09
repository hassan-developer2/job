using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace job
{
    public partial class FrmInterview : Form
    {
        public FrmInterview()
        {
            InitializeComponent();
        }

        private void FrmInterview_Load(object sender, EventArgs e)
        {
            //get company
            DataClassesJobDataContext db = new DataClassesJobDataContext();
            var queryResultsCompany = from c in db.CompanyProfiles
                                      select c;
            if (queryResultsCompany.Any())
            {
                cboCompany.DataSource = queryResultsCompany;
                cboCompany.DisplayMember = "name";
                cboCompany.ValueMember = "id";
            }
            // get questions
            var queryResultsQuestion = from q in db.Questions
                                       select q;
            if (queryResultsQuestion.Any())
            {
                cboQuestion.DataSource = queryResultsQuestion;
                cboQuestion.DisplayMember = "question1";
                cboQuestion.ValueMember = "Id";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataClassesJobDataContext db = new DataClassesJobDataContext();
                InterviewDetail interviewDetail = new InterviewDetail();
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
                var queryResults = from s in db.Interviews
                                   where s.Id == cboId.Text
                                   select s;
                if (queryResults.Any())
                {
                   // MessageBox.Show("id already exists");
                    // return;
                    goto childTable;
                }
                else
                {
                    //insert new  transId
                    Interview interview = new Interview();
                    interview.Id = cboId.Text;
                    interview.TransDate = dtpTransDate.Value;
                    interview.CompanyId = Convert.ToInt32( cboCompany.SelectedValue);
                    interview.CompanyName = cboCompany.Text;
                    
                    db.Interviews.InsertOnSubmit(interview);
                    db.SubmitChanges();

                }
                #endregion
                childTable:
                interviewDetail.InterviewId = cboId.Text;
                interviewDetail.QuestionId =(int) cboQuestion.SelectedValue;
                interviewDetail.Question = cboQuestion.Text;

                db.InterviewDetails.InsertOnSubmit(interviewDetail);
                db.SubmitChanges();
                MessageBox.Show("item added in detail");


                // bind saleDetail data to grid view


                var interDetail = from s in db.InterviewDetails
                                  where s.InterviewId == cboId.Text
                                  select s;
                // var list = new List<object> { queryResults };
                dataGridViewQuestion.DataSource = interDetail;
                // show notification for delete
                notifyIconRightClick.ShowBalloonTip(3, "Tip", "right click on datagrid to get context menu", ToolTipIcon.Info);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var random = System.Guid.NewGuid().ToString().Replace("-", null);
            cboId.Text = random;
            dataGridViewQuestion.Refresh();
        }

        private void contextMenuStripDelete_MouseClick(object sender, MouseEventArgs e)
        {
            // delete the record
            string id = dataGridViewQuestion.Rows[0].Cells["Id"].Value.ToString();
            int idInt = Convert.ToInt32(id);
            try
            {
                using (var context = new DataClassesJobDataContext())
                {
                    var savedInterview = context.InterviewDetails.Where(r => r.Id == idInt);
                    if (savedInterview.Any())
                    {
                        var cou = savedInterview.First();
                        cou.Id = idInt;

                        cou.InterviewId = cboId.Text;
                        cou.QuestionId =(int) cboQuestion.SelectedValue;
                        cou.Question = cboQuestion.Text;

                        context.InterviewDetails.DeleteOnSubmit(cou);

                        context.SubmitChanges();
                        MessageBox.Show("Record successfully deleted !");
                        dataGridViewQuestion.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}
