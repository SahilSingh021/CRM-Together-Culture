namespace TogetherCultureCRM.CustomControls
{
    partial class CC_DisplayChatLogCard
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
            this.usernameDateLbl = new System.Windows.Forms.Label();
            this.chatMsgLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameDateLbl
            // 
            this.usernameDateLbl.AutoSize = true;
            this.usernameDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameDateLbl.Location = new System.Drawing.Point(13, 6);
            this.usernameDateLbl.Name = "usernameDateLbl";
            this.usernameDateLbl.Size = new System.Drawing.Size(151, 13);
            this.usernameDateLbl.TabIndex = 0;
            this.usernameDateLbl.Text = "Username - (04/06/2013)";
            // 
            // chatMsgLbl
            // 
            this.chatMsgLbl.AllowDrop = true;
            this.chatMsgLbl.Location = new System.Drawing.Point(14, 21);
            this.chatMsgLbl.Name = "chatMsgLbl";
            this.chatMsgLbl.Size = new System.Drawing.Size(934, 37);
            this.chatMsgLbl.TabIndex = 1;
            this.chatMsgLbl.Text = "Chat Message";
            // 
            // CC_DisplayChatLogCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chatMsgLbl);
            this.Controls.Add(this.usernameDateLbl);
            this.Name = "CC_DisplayChatLogCard";
            this.Size = new System.Drawing.Size(952, 64);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameDateLbl;
        private System.Windows.Forms.Label chatMsgLbl;
    }
}
