namespace Client
{
    partial class FormChooseType
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
            this.ComboBoxMain = new System.Windows.Forms.ComboBox();
            this.ButtonChoose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComboBoxMain
            // 
            this.ComboBoxMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxMain.FormattingEnabled = true;
            this.ComboBoxMain.Location = new System.Drawing.Point(12, 25);
            this.ComboBoxMain.Name = "ComboBoxMain";
            this.ComboBoxMain.Size = new System.Drawing.Size(254, 21);
            this.ComboBoxMain.TabIndex = 0;
            // 
            // ButtonChoose
            // 
            this.ButtonChoose.Location = new System.Drawing.Point(101, 74);
            this.ButtonChoose.Name = "ButtonChoose";
            this.ButtonChoose.Size = new System.Drawing.Size(75, 23);
            this.ButtonChoose.TabIndex = 1;
            this.ButtonChoose.Text = "Choose";
            this.ButtonChoose.UseVisualStyleBackColor = true;
            this.ButtonChoose.Click += new System.EventHandler(this.ButtonChoose_Click);
            // 
            // FormChooseType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 109);
            this.Controls.Add(this.ButtonChoose);
            this.Controls.Add(this.ComboBoxMain);
            this.Name = "FormChooseType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose entity type";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChooseType_FormClosed);
            this.Load += new System.EventHandler(this.FormChooseType_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxMain;
        private System.Windows.Forms.Button ButtonChoose;
    }
}