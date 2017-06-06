namespace Client
{
    partial class FormAddChair
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
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonRemove = new System.Windows.Forms.Button();
            this.ButtonSubmit = new System.Windows.Forms.Button();
            this.ListViewAll = new System.Windows.Forms.ListView();
            this.ColumnHeaderMain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListViewChosen = new System.Windows.Forms.ListView();
            this.ColumnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxFacultyID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(15, 24);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(448, 20);
            this.TextBoxName.TabIndex = 2;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(226, 156);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(25, 25);
            this.ButtonAdd.TabIndex = 6;
            this.ButtonAdd.Text = "+";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.Location = new System.Drawing.Point(226, 222);
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(25, 25);
            this.ButtonRemove.TabIndex = 7;
            this.ButtonRemove.Text = "-";
            this.ButtonRemove.UseVisualStyleBackColor = true;
            this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // ButtonSubmit
            // 
            this.ButtonSubmit.Location = new System.Drawing.Point(200, 326);
            this.ButtonSubmit.Name = "ButtonSubmit";
            this.ButtonSubmit.Size = new System.Drawing.Size(75, 23);
            this.ButtonSubmit.TabIndex = 8;
            this.ButtonSubmit.Text = "Add";
            this.ButtonSubmit.UseVisualStyleBackColor = true;
            this.ButtonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // ListViewAll
            // 
            this.ListViewAll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderMain});
            this.ListViewAll.FullRowSelect = true;
            this.ListViewAll.GridLines = true;
            this.ListViewAll.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewAll.Location = new System.Drawing.Point(15, 124);
            this.ListViewAll.MultiSelect = false;
            this.ListViewAll.Name = "ListViewAll";
            this.ListViewAll.Size = new System.Drawing.Size(205, 182);
            this.ListViewAll.TabIndex = 9;
            this.ListViewAll.UseCompatibleStateImageBehavior = false;
            this.ListViewAll.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeaderMain
            // 
            this.ColumnHeaderMain.Text = "Name";
            this.ColumnHeaderMain.Width = 500;
            // 
            // ListViewChosen
            // 
            this.ListViewChosen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderName});
            this.ListViewChosen.FullRowSelect = true;
            this.ListViewChosen.GridLines = true;
            this.ListViewChosen.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewChosen.Location = new System.Drawing.Point(257, 124);
            this.ListViewChosen.MultiSelect = false;
            this.ListViewChosen.Name = "ListViewChosen";
            this.ListViewChosen.Size = new System.Drawing.Size(206, 182);
            this.ListViewChosen.TabIndex = 10;
            this.ListViewChosen.UseCompatibleStateImageBehavior = false;
            this.ListViewChosen.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeaderName
            // 
            this.ColumnHeaderName.Text = "Name";
            this.ColumnHeaderName.Width = 500;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "FacultyID";
            // 
            // TextBoxFacultyID
            // 
            this.TextBoxFacultyID.Location = new System.Drawing.Point(15, 70);
            this.TextBoxFacultyID.Name = "TextBoxFacultyID";
            this.TextBoxFacultyID.Size = new System.Drawing.Size(448, 20);
            this.TextBoxFacultyID.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Teachers";
            // 
            // FormAddChair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 361);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxFacultyID);
            this.Controls.Add(this.ListViewChosen);
            this.Controls.Add(this.ListViewAll);
            this.Controls.Add(this.ButtonSubmit);
            this.Controls.Add(this.ButtonRemove);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAddChair";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add chair";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddChair_FormClosing);
            this.Load += new System.EventHandler(this.FormAddChair_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonRemove;
        private System.Windows.Forms.Button ButtonSubmit;
        private System.Windows.Forms.ListView ListViewAll;
        private System.Windows.Forms.ListView ListViewChosen;
        private System.Windows.Forms.ColumnHeader ColumnHeaderMain;
        private System.Windows.Forms.ColumnHeader ColumnHeaderName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxFacultyID;
        private System.Windows.Forms.Label label1;
    }
}