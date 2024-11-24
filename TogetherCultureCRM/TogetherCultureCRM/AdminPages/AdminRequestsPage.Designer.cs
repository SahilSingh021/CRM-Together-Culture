namespace TogetherCultureCRM.AdminPages
{
    partial class AdminRequestsPage
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
            this.requestPanel = new System.Windows.Forms.Panel();
            this.noIncommingRequestsLbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.requestPanel.SuspendLayout();
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
            this.label2.Location = new System.Drawing.Point(277, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Admin Requests";
            // 
            // requestPanel
            // 
            this.requestPanel.AutoScroll = true;
            this.requestPanel.Controls.Add(this.noIncommingRequestsLbl);
            this.requestPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.requestPanel.Location = new System.Drawing.Point(0, 95);
            this.requestPanel.Name = "requestPanel";
            this.requestPanel.Size = new System.Drawing.Size(804, 666);
            this.requestPanel.TabIndex = 1;
            // 
            // noIncommingRequestsLbl
            // 
            this.noIncommingRequestsLbl.AutoSize = true;
            this.noIncommingRequestsLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.noIncommingRequestsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noIncommingRequestsLbl.ForeColor = System.Drawing.Color.Black;
            this.noIncommingRequestsLbl.Location = new System.Drawing.Point(253, 48);
            this.noIncommingRequestsLbl.Name = "noIncommingRequestsLbl";
            this.noIncommingRequestsLbl.Size = new System.Drawing.Size(286, 29);
            this.noIncommingRequestsLbl.TabIndex = 3;
            this.noIncommingRequestsLbl.Text = "No incomming requests...";
            // 
            // AdminRequestsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 761);
            this.Controls.Add(this.requestPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminRequestsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminRequests";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.requestPanel.ResumeLayout(false);
            this.requestPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel requestPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label noIncommingRequestsLbl;
    }
}