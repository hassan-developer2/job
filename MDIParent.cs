using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using job.report;
namespace job
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;
        private StatusStrip StatusStrip1 =new StatusStrip();
        public MDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void linkLabelClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void jobTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmJobType jobType = new FrmJobType();
            jobType.Show();
        }

        private void companyProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompanyProfile frmCompanyProfile = new FrmCompanyProfile();
            frmCompanyProfile.Show();
        }

        private void jobToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmJob frmJob = new FrmJob();
            frmJob.Show();
        }

        private void applyJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmApplyJob frmApply = new FrmApplyJob();
            frmApply.Show();
        }

        private void jobApplyDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportJobDetail frmReportJobDetail = new FrmReportJobDetail();
            frmReportJobDetail.Show();
        }

        private void MDIParent_Load(object sender, EventArgs e)
        {
            StatusStrip1.Text = "welcome to " + Application.ProductName;
            statusStrip = StatusStrip1;
            statusStrip.Height = 300;
           
        }

        private void companyProfileReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportCompany frmReportCompany = new FrmReportCompany();
            frmReportCompany.Show();
        }

        private void questionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQuestion frmQuestion = new FrmQuestion();
            frmQuestion.Show();
        }

        private void interviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmInterview frmInterview = new FrmInterview();
            frmInterview.Show();
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void abouTheDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void linkLabelClose2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
