namespace job
{
    partial class FrmInterview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInterview));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.groupBoxButtons = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTransDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboQuestion = new System.Windows.Forms.ComboBox();
            this.dataGridViewQuestion = new System.Windows.Forms.DataGridView();
            this.notifyIconRightClick = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuestion)).BeginInit();
            this.contextMenuStripDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAdd.Location = new System.Drawing.Point(736, 292);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 56);
            this.btnAdd.TabIndex = 81;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGetData.BackgroundImage")));
            this.btnGetData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGetData.Location = new System.Drawing.Point(390, 154);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(106, 92);
            this.btnGetData.TabIndex = 80;
            this.btnGetData.Text = "get data";
            this.btnGetData.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGetData.UseVisualStyleBackColor = true;
            // 
            // groupBoxButtons
            // 
            this.groupBoxButtons.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxButtons.Controls.Add(this.btnPrint);
            this.groupBoxButtons.Controls.Add(this.btnDelete);
            this.groupBoxButtons.Controls.Add(this.btnUpdate);
            this.groupBoxButtons.Controls.Add(this.btnSearch);
            this.groupBoxButtons.Controls.Add(this.btnNew);
            this.groupBoxButtons.Controls.Add(this.btnSave);
            this.groupBoxButtons.Location = new System.Drawing.Point(35, 25);
            this.groupBoxButtons.Name = "groupBoxButtons";
            this.groupBoxButtons.Size = new System.Drawing.Size(695, 97);
            this.groupBoxButtons.TabIndex = 79;
            this.groupBoxButtons.TabStop = false;
            this.groupBoxButtons.Text = "Commands";
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrint.Location = new System.Drawing.Point(561, 21);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(108, 57);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "&Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(337, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 57);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(116, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 59);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(447, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 57);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(14, 19);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(96, 59);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "&New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Blue;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(223, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 59);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "ID";
            // 
            // cboId
            // 
            this.cboId.FormattingEnabled = true;
            this.cboId.Location = new System.Drawing.Point(100, 167);
            this.cboId.Name = "cboId";
            this.cboId.Size = new System.Drawing.Size(275, 21);
            this.cboId.TabIndex = 83;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "date";
            // 
            // dtpTransDate
            // 
            this.dtpTransDate.Location = new System.Drawing.Point(100, 235);
            this.dtpTransDate.Name = "dtpTransDate";
            this.dtpTransDate.Size = new System.Drawing.Size(200, 20);
            this.dtpTransDate.TabIndex = 85;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 86;
            this.label3.Text = "company";
            // 
            // cboCompany
            // 
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(100, 323);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(200, 21);
            this.cboCompany.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "question";
            // 
            // cboQuestion
            // 
            this.cboQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuestion.FormattingEnabled = true;
            this.cboQuestion.Location = new System.Drawing.Point(390, 327);
            this.cboQuestion.Name = "cboQuestion";
            this.cboQuestion.Size = new System.Drawing.Size(314, 21);
            this.cboQuestion.TabIndex = 89;
            // 
            // dataGridViewQuestion
            // 
            this.dataGridViewQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuestion.Location = new System.Drawing.Point(100, 483);
            this.dataGridViewQuestion.Name = "dataGridViewQuestion";
            this.dataGridViewQuestion.Size = new System.Drawing.Size(603, 189);
            this.dataGridViewQuestion.TabIndex = 90;
            // 
            // notifyIconRightClick
            // 
            this.notifyIconRightClick.ContextMenuStrip = this.contextMenuStripDelete;
            this.notifyIconRightClick.Text = "notifyIcon1";
            this.notifyIconRightClick.Visible = true;
            // 
            // contextMenuStripDelete
            // 
            this.contextMenuStripDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDelete});
            this.contextMenuStripDelete.Name = "contextMenuStripDelete";
            this.contextMenuStripDelete.Size = new System.Drawing.Size(181, 48);
            this.contextMenuStripDelete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.contextMenuStripDelete_MouseClick);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Image = global::job.Properties.Resources.colt;
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemDelete.Text = "Delete";
            // 
            // FrmInterview
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 694);
            this.Controls.Add(this.dataGridViewQuestion);
            this.Controls.Add(this.cboQuestion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCompany);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpTransDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.groupBoxButtons);
            this.IsMdiContainer = true;
            this.Name = "FrmInterview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interview";
            this.Load += new System.EventHandler(this.FrmInterview_Load);
            this.groupBoxButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuestion)).EndInit();
            this.contextMenuStripDelete.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.GroupBox groupBoxButtons;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTransDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboQuestion;
        private System.Windows.Forms.DataGridView dataGridViewQuestion;
        private System.Windows.Forms.NotifyIcon notifyIconRightClick;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
    }
}