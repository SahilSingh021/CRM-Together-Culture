namespace TogetherCultureCRM.AdminPages
{
    partial class AdminEditUserPage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.isBannedCheckBox = new System.Windows.Forms.CheckBox();
            this.isAdminCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userIdTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.updateBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 95);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(323, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Edit Users";
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.updateBtn);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.passwordTxt);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.emailTxt);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.usernameTxt);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.userIdTxt);
            this.mainPanel.Controls.Add(this.isBannedCheckBox);
            this.mainPanel.Controls.Add(this.isAdminCheckBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainPanel.Location = new System.Drawing.Point(0, 95);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(804, 666);
            this.mainPanel.TabIndex = 1;
            // 
            // isBannedCheckBox
            // 
            this.isBannedCheckBox.AutoSize = true;
            this.isBannedCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.isBannedCheckBox.Location = new System.Drawing.Point(344, 363);
            this.isBannedCheckBox.Name = "isBannedCheckBox";
            this.isBannedCheckBox.Size = new System.Drawing.Size(74, 17);
            this.isBannedCheckBox.TabIndex = 21;
            this.isBannedCheckBox.Text = "Is Banned";
            this.isBannedCheckBox.UseVisualStyleBackColor = true;
            // 
            // isAdminCheckBox
            // 
            this.isAdminCheckBox.AutoSize = true;
            this.isAdminCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.isAdminCheckBox.Location = new System.Drawing.Point(272, 363);
            this.isAdminCheckBox.Name = "isAdminCheckBox";
            this.isAdminCheckBox.Size = new System.Drawing.Size(66, 17);
            this.isAdminCheckBox.TabIndex = 20;
            this.isAdminCheckBox.Text = "Is Admin";
            this.isAdminCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(269, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "User ID:";
            // 
            // userIdTxt
            // 
            this.userIdTxt.Enabled = false;
            this.userIdTxt.Location = new System.Drawing.Point(272, 200);
            this.userIdTxt.MaxLength = 30;
            this.userIdTxt.Name = "userIdTxt";
            this.userIdTxt.Size = new System.Drawing.Size(250, 20);
            this.userIdTxt.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(269, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Username:";
            // 
            // usernameTxt
            // 
            this.usernameTxt.Location = new System.Drawing.Point(272, 245);
            this.usernameTxt.MaxLength = 30;
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(250, 20);
            this.usernameTxt.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(269, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Email:";
            // 
            // emailTxt
            // 
            this.emailTxt.Location = new System.Drawing.Point(272, 289);
            this.emailTxt.MaxLength = 30;
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(250, 20);
            this.emailTxt.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(269, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Password:";
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(272, 333);
            this.passwordTxt.MaxLength = 30;
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '*';
            this.passwordTxt.Size = new System.Drawing.Size(250, 20);
            this.passwordTxt.TabIndex = 28;
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(255)))), ((int)(((byte)(247)))));
            this.updateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.updateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.ForeColor = System.Drawing.Color.Black;
            this.updateBtn.Location = new System.Drawing.Point(272, 387);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(250, 35);
            this.updateBtn.TabIndex = 30;
            this.updateBtn.Text = "UPDATE";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // AdminEditUserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 761);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminEditUserPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Edit User";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox isBannedCheckBox;
        private System.Windows.Forms.CheckBox isAdminCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userIdTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.Button updateBtn;
    }
}