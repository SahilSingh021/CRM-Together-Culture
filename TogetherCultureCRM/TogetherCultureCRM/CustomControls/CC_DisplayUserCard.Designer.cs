namespace TogetherCultureCRM.CustomControls
{
    partial class CC_DisplayUserCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameLbl = new System.Windows.Forms.Label();
            this.isAdminCheckBox = new System.Windows.Forms.CheckBox();
            this.isBannedCheckBox = new System.Windows.Forms.CheckBox();
            this.manageBtn = new System.Windows.Forms.Button();
            this.userIdLbl = new System.Windows.Forms.Label();
            this.emailLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.Location = new System.Drawing.Point(14, 15);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(55, 13);
            this.usernameLbl.TabIndex = 10;
            this.usernameLbl.Text = "Username";
            // 
            // isAdminCheckBox
            // 
            this.isAdminCheckBox.AutoSize = true;
            this.isAdminCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.isAdminCheckBox.Enabled = false;
            this.isAdminCheckBox.Location = new System.Drawing.Point(489, 10);
            this.isAdminCheckBox.Name = "isAdminCheckBox";
            this.isAdminCheckBox.Size = new System.Drawing.Size(66, 17);
            this.isAdminCheckBox.TabIndex = 14;
            this.isAdminCheckBox.Text = "Is Admin";
            this.isAdminCheckBox.UseVisualStyleBackColor = true;
            // 
            // isBannedCheckBox
            // 
            this.isBannedCheckBox.AutoSize = true;
            this.isBannedCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.isBannedCheckBox.Enabled = false;
            this.isBannedCheckBox.Location = new System.Drawing.Point(489, 33);
            this.isBannedCheckBox.Name = "isBannedCheckBox";
            this.isBannedCheckBox.Size = new System.Drawing.Size(74, 17);
            this.isBannedCheckBox.TabIndex = 15;
            this.isBannedCheckBox.Text = "Is Banned";
            this.isBannedCheckBox.UseVisualStyleBackColor = true;
            // 
            // manageBtn
            // 
            this.manageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(255)))), ((int)(((byte)(247)))));
            this.manageBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.manageBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.manageBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.manageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageBtn.ForeColor = System.Drawing.Color.Black;
            this.manageBtn.Location = new System.Drawing.Point(569, 10);
            this.manageBtn.Name = "manageBtn";
            this.manageBtn.Size = new System.Drawing.Size(200, 40);
            this.manageBtn.TabIndex = 16;
            this.manageBtn.Text = "Manage";
            this.manageBtn.UseVisualStyleBackColor = false;
            // 
            // userIdLbl
            // 
            this.userIdLbl.AutoSize = true;
            this.userIdLbl.Location = new System.Drawing.Point(613, 15);
            this.userIdLbl.Name = "userIdLbl";
            this.userIdLbl.Size = new System.Drawing.Size(36, 13);
            this.userIdLbl.TabIndex = 17;
            this.userIdLbl.Text = "userId";
            this.userIdLbl.Visible = false;
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Location = new System.Drawing.Point(14, 30);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(32, 13);
            this.emailLbl.TabIndex = 18;
            this.emailLbl.Text = "Email";
            // 
            // CC_DisplayUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.emailLbl);
            this.Controls.Add(this.userIdLbl);
            this.Controls.Add(this.manageBtn);
            this.Controls.Add(this.isBannedCheckBox);
            this.Controls.Add(this.isAdminCheckBox);
            this.Controls.Add(this.usernameLbl);
            this.Name = "CC_DisplayUserCard";
            this.Size = new System.Drawing.Size(782, 60);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.CheckBox isAdminCheckBox;
        private System.Windows.Forms.CheckBox isBannedCheckBox;
        private System.Windows.Forms.Button manageBtn;
        private System.Windows.Forms.Label userIdLbl;
        private System.Windows.Forms.Label emailLbl;
    }
}
