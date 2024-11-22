namespace TogetherCultureCRM
{
    partial class MembershipPayment
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
            this.payment_title = new System.Windows.Forms.Label();
            this.name_on_card = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.security_code = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.card_number = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.expiry_date = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.pay_now = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // payment_title
            // 
            this.payment_title.AutoSize = true;
            this.payment_title.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.payment_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payment_title.Location = new System.Drawing.Point(156, 37);
            this.payment_title.Name = "payment_title";
            this.payment_title.Size = new System.Drawing.Size(113, 29);
            this.payment_title.TabIndex = 11;
            this.payment_title.Text = "Payment";
            // 
            // name_on_card
            // 
            this.name_on_card.AutoSize = true;
            this.name_on_card.Location = new System.Drawing.Point(53, 137);
            this.name_on_card.Name = "name_on_card";
            this.name_on_card.Size = new System.Drawing.Size(108, 20);
            this.name_on_card.TabIndex = 13;
            this.name_on_card.Text = "Name on card";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(57, 160);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 26);
            this.textBox1.TabIndex = 14;
            // 
            // security_code
            // 
            this.security_code.AutoSize = true;
            this.security_code.Location = new System.Drawing.Point(268, 137);
            this.security_code.Name = "security_code";
            this.security_code.Size = new System.Drawing.Size(153, 20);
            this.security_code.TabIndex = 15;
            this.security_code.Text = "Security Code / CVV";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(272, 160);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 16;
            // 
            // card_number
            // 
            this.card_number.AutoSize = true;
            this.card_number.Location = new System.Drawing.Point(53, 223);
            this.card_number.Name = "card_number";
            this.card_number.Size = new System.Drawing.Size(103, 20);
            this.card_number.TabIndex = 17;
            this.card_number.Text = "Card Number";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(57, 246);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(183, 26);
            this.textBox3.TabIndex = 18;
            // 
            // expiry_date
            // 
            this.expiry_date.AutoSize = true;
            this.expiry_date.Location = new System.Drawing.Point(54, 322);
            this.expiry_date.Name = "expiry_date";
            this.expiry_date.Size = new System.Drawing.Size(90, 20);
            this.expiry_date.TabIndex = 19;
            this.expiry_date.Text = "Expiry Date";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(57, 345);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(183, 26);
            this.textBox4.TabIndex = 20;
            // 
            // pay_now
            // 
            this.pay_now.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pay_now.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pay_now.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pay_now.Location = new System.Drawing.Point(261, 313);
            this.pay_now.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pay_now.Name = "pay_now";
            this.pay_now.Size = new System.Drawing.Size(160, 58);
            this.pay_now.TabIndex = 21;
            this.pay_now.Text = "Pay Now";
            this.pay_now.UseVisualStyleBackColor = false;
            // 
            // MembershipPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 450);
            this.Controls.Add(this.pay_now);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.expiry_date);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.card_number);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.security_code);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.name_on_card);
            this.Controls.Add(this.payment_title);
            this.Name = "MembershipPayment";
            this.Text = "MembershipPayment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label payment_title;
        private System.Windows.Forms.Label name_on_card;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label security_code;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label card_number;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label expiry_date;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button pay_now;
    }
}