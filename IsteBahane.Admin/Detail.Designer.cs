namespace IsteBahane.Admin
{
    partial class Detail
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
            this.txtExcuse = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.txtLike = new System.Windows.Forms.TextBox();
            this.txtDislike = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtExcuse
            // 
            this.txtExcuse.Location = new System.Drawing.Point(72, 12);
            this.txtExcuse.Multiline = true;
            this.txtExcuse.Name = "txtExcuse";
            this.txtExcuse.Size = new System.Drawing.Size(331, 85);
            this.txtExcuse.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(412, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(333, 167);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Yayınla";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bahane";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Like";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dislike";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Author";
            // 
            // txtNick
            // 
            this.txtNick.Location = new System.Drawing.Point(72, 110);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(331, 20);
            this.txtNick.TabIndex = 9;
            // 
            // txtLike
            // 
            this.txtLike.Location = new System.Drawing.Point(72, 137);
            this.txtLike.Name = "txtLike";
            this.txtLike.Size = new System.Drawing.Size(100, 20);
            this.txtLike.TabIndex = 10;
            // 
            // txtDislike
            // 
            this.txtDislike.Location = new System.Drawing.Point(72, 170);
            this.txtDislike.Name = "txtDislike";
            this.txtDislike.Size = new System.Drawing.Size(100, 20);
            this.txtDislike.TabIndex = 11;
            // 
            // Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 220);
            this.Controls.Add(this.txtDislike);
            this.Controls.Add(this.txtLike);
            this.Controls.Add(this.txtNick);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtExcuse);
            this.Name = "Detail";
            this.Text = "Detail";
            this.Load += new System.EventHandler(this.Detail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExcuse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.TextBox txtLike;
        private System.Windows.Forms.TextBox txtDislike;
    }
}