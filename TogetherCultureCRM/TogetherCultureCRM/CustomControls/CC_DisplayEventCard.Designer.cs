namespace TogetherCultureCRM.CustomControls
{
    partial class CC_DisplayEventCard
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
            this.eventDayLbl = new System.Windows.Forms.Label();
            this.eventNameLbl = new System.Windows.Forms.Label();
            this.eventTimeLbl = new System.Windows.Forms.Label();
            this.bookEventBtn = new System.Windows.Forms.Button();
            this.eventIdLbl = new System.Windows.Forms.Label();
            this.tagIdLbl = new System.Windows.Forms.Label();
            this.eventDateLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eventDayLbl
            // 
            this.eventDayLbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.eventDayLbl.AutoSize = true;
            this.eventDayLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventDayLbl.Location = new System.Drawing.Point(70, 30);
            this.eventDayLbl.Name = "eventDayLbl";
            this.eventDayLbl.Size = new System.Drawing.Size(71, 20);
            this.eventDayLbl.TabIndex = 0;
            this.eventDayLbl.Text = "Monday";
            // 
            // eventNameLbl
            // 
            this.eventNameLbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.eventNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventNameLbl.Location = new System.Drawing.Point(10, 83);
            this.eventNameLbl.Name = "eventNameLbl";
            this.eventNameLbl.Size = new System.Drawing.Size(200, 45);
            this.eventNameLbl.TabIndex = 1;
            this.eventNameLbl.Text = "UN Arabic Language Day Celebration";
            this.eventNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eventTimeLbl
            // 
            this.eventTimeLbl.AutoSize = true;
            this.eventTimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventTimeLbl.Location = new System.Drawing.Point(51, 127);
            this.eventTimeLbl.Name = "eventTimeLbl";
            this.eventTimeLbl.Size = new System.Drawing.Size(117, 15);
            this.eventTimeLbl.TabIndex = 2;
            this.eventTimeLbl.Text = "Starting Time: 13:00";
            // 
            // bookEventBtn
            // 
            this.bookEventBtn.BackColor = System.Drawing.Color.Khaki;
            this.bookEventBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bookEventBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.bookEventBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.bookEventBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookEventBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookEventBtn.Location = new System.Drawing.Point(10, 186);
            this.bookEventBtn.Name = "bookEventBtn";
            this.bookEventBtn.Size = new System.Drawing.Size(200, 42);
            this.bookEventBtn.TabIndex = 3;
            this.bookEventBtn.Text = "Book Event";
            this.bookEventBtn.UseVisualStyleBackColor = false;
            // 
            // eventIdLbl
            // 
            this.eventIdLbl.AutoSize = true;
            this.eventIdLbl.Location = new System.Drawing.Point(21, 17);
            this.eventIdLbl.Name = "eventIdLbl";
            this.eventIdLbl.Size = new System.Drawing.Size(43, 13);
            this.eventIdLbl.TabIndex = 4;
            this.eventIdLbl.Text = "eventId";
            this.eventIdLbl.Visible = false;
            // 
            // tagIdLbl
            // 
            this.tagIdLbl.AutoSize = true;
            this.tagIdLbl.Location = new System.Drawing.Point(70, 17);
            this.tagIdLbl.Name = "tagIdLbl";
            this.tagIdLbl.Size = new System.Drawing.Size(31, 13);
            this.tagIdLbl.TabIndex = 5;
            this.tagIdLbl.Text = "tagId";
            this.tagIdLbl.Visible = false;
            // 
            // eventDateLbl
            // 
            this.eventDateLbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.eventDateLbl.AutoSize = true;
            this.eventDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventDateLbl.Location = new System.Drawing.Point(58, 49);
            this.eventDateLbl.Name = "eventDateLbl";
            this.eventDateLbl.Size = new System.Drawing.Size(99, 20);
            this.eventDateLbl.TabIndex = 6;
            this.eventDateLbl.Text = "01/02/2025";
            // 
            // CC_DisplayEventCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.eventDateLbl);
            this.Controls.Add(this.tagIdLbl);
            this.Controls.Add(this.eventIdLbl);
            this.Controls.Add(this.bookEventBtn);
            this.Controls.Add(this.eventTimeLbl);
            this.Controls.Add(this.eventNameLbl);
            this.Controls.Add(this.eventDayLbl);
            this.Name = "CC_DisplayEventCard";
            this.Size = new System.Drawing.Size(220, 250);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label eventDayLbl;
        private System.Windows.Forms.Label eventNameLbl;
        private System.Windows.Forms.Label eventTimeLbl;
        private System.Windows.Forms.Button bookEventBtn;
        private System.Windows.Forms.Label eventIdLbl;
        private System.Windows.Forms.Label tagIdLbl;
        private System.Windows.Forms.Label eventDateLbl;
    }
}
