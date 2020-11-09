using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace job.search
{
    public partial class FrmSearchInterview : Form
    {
        public FrmSearchInterview()
        {
            InitializeComponent();
        }

        private void FrmSearchInterview_Load(object sender, EventArgs e)
        {
            GetInterview();
        }

        private void GetInterview()
        {
            DataClassesJobDataContext db = new DataClassesJobDataContext();
            var queryResults = from i in db.Interviews
                               select i;
            if (queryResults.Any())
            {
                dataGridInterview.DataSource = queryResults;
            }
            else
            {
                MessageBox.Show("no data found");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataClassesJobDataContext db = new DataClassesJobDataContext();
            dataGridInterview.DataSource = db.Interviews.Where(n => n.CompanyName.Contains(txtSearch.Text)).ToList();
        }
    }
}
