namespace TogetherCultureCRM.CustomControls
{
    partial class CC_HomeInterestTagButton
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
            this.tagIdLbl = new System.Windows.Forms.Label();
            this.intrestTagBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tagIdLbl
            // 
            this.tagIdLbl.AutoSize = true;
            this.tagIdLbl.Location = new System.Drawing.Point(-3, 0);
            this.tagIdLbl.Name = "tagIdLbl";
            this.tagIdLbl.Size = new System.Drawing.Size(37, 13);
            this.tagIdLbl.TabIndex = 2;
            this.tagIdLbl.Text = "TagID";
            this.tagIdLbl.Visible = false;
            // 
            // intrestTagBtn
            // 
            this.intrestTagBtn.BackColor = System.Drawing.Color.Khaki;
            this.intrestTagBtn.Location = new System.Drawing.Point(0, 0);
            this.intrestTagBtn.Name = "intrestTagBtn";
            this.intrestTagBtn.Size = new System.Drawing.Size(110, 30);
            this.intrestTagBtn.TabIndex = 3;
            this.intrestTagBtn.Text = "Tag Name";
            this.intrestTagBtn.UseVisualStyleBackColor = false;
            // 
            // CC_HomeInterestTagButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.Controls.Add(this.tagIdLbl);
            this.Controls.Add(this.intrestTagBtn);
            this.Name = "CC_HomeInterestTagButton";
            this.Size = new System.Drawing.Size(110, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label tagIdLbl;
        private System.Windows.Forms.Button intrestTagBtn;
    }
}
