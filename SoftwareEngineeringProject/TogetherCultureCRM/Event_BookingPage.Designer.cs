namespace TogetherCultureCRM
{
    partial class Event_BookingPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Event_BookingPage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Book_Payment_or_Booked = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Memebrship = new System.Windows.Forms.Button();
            this.Home = new System.Windows.Forms.Button();
            this.Profile = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Memebrship);
            this.panel1.Controls.Add(this.Home);
            this.panel1.Controls.Add(this.Profile);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1418, 802);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Bisque;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.Book_Payment_or_Booked);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.pictureBox7);
            this.panel2.Location = new System.Drawing.Point(12, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1394, 676);
            this.panel2.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1087, 213);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(307, 335);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Book_Payment_or_Booked
            // 
            this.Book_Payment_or_Booked.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Book_Payment_or_Booked.Location = new System.Drawing.Point(1087, 101);
            this.Book_Payment_or_Booked.Name = "Book_Payment_or_Booked";
            this.Book_Payment_or_Booked.Size = new System.Drawing.Size(255, 61);
            this.Book_Payment_or_Booked.TabIndex = 21;
            this.Book_Payment_or_Booked.Text = "Book Event";
            this.Book_Payment_or_Booked.UseVisualStyleBackColor = true;
            this.Book_Payment_or_Booked.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(48, 448);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(845, 212);
            this.textBox3.TabIndex = 20;
            this.textBox3.Text = resources.GetString("textBox3.Text");
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(48, 44);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(845, 384);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 19;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Memebrship
            // 
            this.Memebrship.Location = new System.Drawing.Point(982, 41);
            this.Memebrship.Name = "Memebrship";
            this.Memebrship.Size = new System.Drawing.Size(149, 29);
            this.Memebrship.TabIndex = 12;
            this.Memebrship.Text = "Memberships";
            this.Memebrship.UseVisualStyleBackColor = true;
            this.Memebrship.Click += new System.EventHandler(this.Memebrship_Click);
            // 
            // Home
            // 
            this.Home.Location = new System.Drawing.Point(756, 41);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(149, 29);
            this.Home.TabIndex = 11;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.button3_Click);
            // 
            // Profile
            // 
            this.Profile.Location = new System.Drawing.Point(1228, 41);
            this.Profile.Name = "Profile";
            this.Profile.Size = new System.Drawing.Size(149, 29);
            this.Profile.TabIndex = 10;
            this.Profile.Text = "Profile ";
            this.Profile.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(177, 14);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(217, 62);
            this.button5.TabIndex = 9;
            this.button5.Text = "Events";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1442, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Join Us";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Event_BookingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 802);
            this.Controls.Add(this.panel1);
            this.Name = "Event_BookingPage";
            this.Text = "Event_BookingPage";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Memebrship;
        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.Button Profile;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Book_Payment_or_Booked;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}