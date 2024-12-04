namespace TogetherCultureCRM.AdminPages
{
    partial class AdminViewUserEventsAndVisitsPage
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
            this.eventBookingPanel = new System.Windows.Forms.Panel();
            this.noEventsLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.visitorLogTxt = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.eventBookingPanel.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.label2.Location = new System.Drawing.Point(238, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "User Events And Visits";
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.eventBookingPanel);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainPanel.Location = new System.Drawing.Point(0, 95);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(804, 666);
            this.mainPanel.TabIndex = 1;
            // 
            // eventBookingPanel
            // 
            this.eventBookingPanel.AutoScroll = true;
            this.eventBookingPanel.Controls.Add(this.noEventsLbl);
            this.eventBookingPanel.Location = new System.Drawing.Point(45, 20);
            this.eventBookingPanel.Name = "eventBookingPanel";
            this.eventBookingPanel.Size = new System.Drawing.Size(759, 420);
            this.eventBookingPanel.TabIndex = 9;
            // 
            // noEventsLbl
            // 
            this.noEventsLbl.AutoSize = true;
            this.noEventsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noEventsLbl.ForeColor = System.Drawing.Color.Black;
            this.noEventsLbl.Location = new System.Drawing.Point(162, 63);
            this.noEventsLbl.Name = "noEventsLbl";
            this.noEventsLbl.Size = new System.Drawing.Size(377, 33);
            this.noEventsLbl.TabIndex = 4;
            this.noEventsLbl.Text = "User has no events booked.";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.visitorLogTxt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 446);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(804, 220);
            this.panel2.TabIndex = 8;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(37, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 16);
            this.label21.TabIndex = 14;
            this.label21.Text = "Visitor Log:";
            // 
            // visitorLogTxt
            // 
            this.visitorLogTxt.BackColor = System.Drawing.Color.White;
            this.visitorLogTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.visitorLogTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visitorLogTxt.Location = new System.Drawing.Point(40, 27);
            this.visitorLogTxt.Name = "visitorLogTxt";
            this.visitorLogTxt.ReadOnly = true;
            this.visitorLogTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.visitorLogTxt.Size = new System.Drawing.Size(726, 167);
            this.visitorLogTxt.TabIndex = 13;
            this.visitorLogTxt.Text = "Visitor Logs are shown here...";
            // 
            // AdminViewUserEventsAndVisitsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 761);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminViewUserEventsAndVisitsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Events And Visits";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.eventBookingPanel.ResumeLayout(false);
            this.eventBookingPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.RichTextBox visitorLogTxt;
        private System.Windows.Forms.Panel eventBookingPanel;
        private System.Windows.Forms.Label noEventsLbl;
    }
}