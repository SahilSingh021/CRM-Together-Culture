namespace TogetherCultureCRM.CustomControls
{
    partial class CC_Request
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
            this.approveBtn = new System.Windows.Forms.Button();
            this.denyBtn = new System.Windows.Forms.Button();
            this.requestDescriptionLbl = new System.Windows.Forms.Label();
            this.usernameTxt = new System.Windows.Forms.Label();
            this.adminRequestIdLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // approveBtn
            // 
            this.approveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(255)))), ((int)(((byte)(247)))));
            this.approveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.approveBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.approveBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.approveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.approveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approveBtn.ForeColor = System.Drawing.Color.Black;
            this.approveBtn.Location = new System.Drawing.Point(448, 10);
            this.approveBtn.Name = "approveBtn";
            this.approveBtn.Size = new System.Drawing.Size(160, 40);
            this.approveBtn.TabIndex = 6;
            this.approveBtn.Text = "Approve";
            this.approveBtn.UseVisualStyleBackColor = false;
            // 
            // denyBtn
            // 
            this.denyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(255)))), ((int)(((byte)(247)))));
            this.denyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.denyBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.denyBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.denyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.denyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denyBtn.ForeColor = System.Drawing.Color.Black;
            this.denyBtn.Location = new System.Drawing.Point(614, 10);
            this.denyBtn.Name = "denyBtn";
            this.denyBtn.Size = new System.Drawing.Size(160, 40);
            this.denyBtn.TabIndex = 7;
            this.denyBtn.Text = "Deny";
            this.denyBtn.UseVisualStyleBackColor = false;
            // 
            // requestDescription
            // 
            this.requestDescriptionLbl.AutoSize = true;
            this.requestDescriptionLbl.Location = new System.Drawing.Point(22, 31);
            this.requestDescriptionLbl.Name = "requestDescription";
            this.requestDescriptionLbl.Size = new System.Drawing.Size(89, 13);
            this.requestDescriptionLbl.TabIndex = 8;
            this.requestDescriptionLbl.Text = "Description Label";
            // 
            // usernameTxt
            // 
            this.usernameTxt.AutoSize = true;
            this.usernameTxt.Location = new System.Drawing.Point(23, 15);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(55, 13);
            this.usernameTxt.TabIndex = 9;
            this.usernameTxt.Text = "Username";
            // 
            // adminRequestIdLbl
            // 
            this.adminRequestIdLbl.AutoSize = true;
            this.adminRequestIdLbl.Location = new System.Drawing.Point(205, 15);
            this.adminRequestIdLbl.Name = "adminRequestIdLbl";
            this.adminRequestIdLbl.Size = new System.Drawing.Size(78, 13);
            this.adminRequestIdLbl.TabIndex = 10;
            this.adminRequestIdLbl.Text = "adminRequstId";
            this.adminRequestIdLbl.Visible = false;
            // 
            // CC_Request
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.adminRequestIdLbl);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.requestDescriptionLbl);
            this.Controls.Add(this.denyBtn);
            this.Controls.Add(this.approveBtn);
            this.Name = "CC_Request";
            this.Size = new System.Drawing.Size(782, 60);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button approveBtn;
        private System.Windows.Forms.Button denyBtn;
        private System.Windows.Forms.Label requestDescriptionLbl;
        private System.Windows.Forms.Label usernameTxt;
        private System.Windows.Forms.Label adminRequestIdLbl;
    }
}
