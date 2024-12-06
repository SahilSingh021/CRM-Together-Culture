namespace TogetherCultureCRM.CustomControls
{
    partial class CC_DisplayDigtialContentModule
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
            this.moduleNameLbl = new System.Windows.Forms.Label();
            this.moduleDateLbl = new System.Windows.Forms.Label();
            this.bookModuleBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // moduleNameLbl
            // 
            this.moduleNameLbl.AutoSize = true;
            this.moduleNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moduleNameLbl.Location = new System.Drawing.Point(60, 11);
            this.moduleNameLbl.Name = "moduleNameLbl";
            this.moduleNameLbl.Size = new System.Drawing.Size(112, 20);
            this.moduleNameLbl.TabIndex = 0;
            this.moduleNameLbl.Text = "Module Name";
            // 
            // moduleDateLbl
            // 
            this.moduleDateLbl.AutoSize = true;
            this.moduleDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moduleDateLbl.Location = new System.Drawing.Point(121, 93);
            this.moduleDateLbl.Name = "moduleDateLbl";
            this.moduleDateLbl.Size = new System.Drawing.Size(104, 20);
            this.moduleDateLbl.TabIndex = 1;
            this.moduleDateLbl.Text = "Module Date";
            // 
            // bookModuleBtn
            // 
            this.bookModuleBtn.BackColor = System.Drawing.Color.Khaki;
            this.bookModuleBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bookModuleBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.bookModuleBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.bookModuleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookModuleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookModuleBtn.Location = new System.Drawing.Point(47, 133);
            this.bookModuleBtn.Margin = new System.Windows.Forms.Padding(4);
            this.bookModuleBtn.Name = "bookModuleBtn";
            this.bookModuleBtn.Size = new System.Drawing.Size(267, 52);
            this.bookModuleBtn.TabIndex = 4;
            this.bookModuleBtn.Text = "Book Module";
            this.bookModuleBtn.UseVisualStyleBackColor = false;
            // 
            // CC_DisplayDigtialContentModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bookModuleBtn);
            this.Controls.Add(this.moduleDateLbl);
            this.Controls.Add(this.moduleNameLbl);
            this.Name = "CC_DisplayDigtialContentModule";
            this.Size = new System.Drawing.Size(350, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label moduleNameLbl;
        private System.Windows.Forms.Label moduleDateLbl;
        private System.Windows.Forms.Button bookModuleBtn;
    }
}
