namespace TogetherCultureCRM.AdminPages
{
    partial class AdminViewEventDetailsPage
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
            this.totalGuestsLbl = new System.Windows.Forms.Label();
            this.noEventsLbl = new System.Windows.Forms.Label();
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
            this.label2.Location = new System.Drawing.Point(306, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Event Details";
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.noEventsLbl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainPanel.Location = new System.Drawing.Point(0, 126);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(804, 635);
            this.mainPanel.TabIndex = 1;
            // 
            // totalGuestsLbl
            // 
            this.totalGuestsLbl.AutoSize = true;
            this.totalGuestsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalGuestsLbl.ForeColor = System.Drawing.Color.Black;
            this.totalGuestsLbl.Location = new System.Drawing.Point(12, 98);
            this.totalGuestsLbl.Name = "totalGuestsLbl";
            this.totalGuestsLbl.Size = new System.Drawing.Size(140, 25);
            this.totalGuestsLbl.TabIndex = 3;
            this.totalGuestsLbl.Text = "Total Guests:";
            // 
            // noEventsLbl
            // 
            this.noEventsLbl.AutoSize = true;
            this.noEventsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noEventsLbl.ForeColor = System.Drawing.Color.Black;
            this.noEventsLbl.Location = new System.Drawing.Point(172, 94);
            this.noEventsLbl.Name = "noEventsLbl";
            this.noEventsLbl.Size = new System.Drawing.Size(447, 33);
            this.noEventsLbl.TabIndex = 5;
            this.noEventsLbl.Text = "No users have booked this event.";
            // 
            // AdminViewEventDetailsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 761);
            this.Controls.Add(this.totalGuestsLbl);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminViewEventDetailsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Details";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalGuestsLbl;
        private System.Windows.Forms.Label noEventsLbl;
    }
}