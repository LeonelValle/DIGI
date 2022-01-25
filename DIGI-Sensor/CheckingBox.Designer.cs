namespace DIGI_Sensor
{
    partial class CheckingBox
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
            this.btn_Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Box = new System.Windows.Forms.TextBox();
            this.txt_SN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_CompareBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pb_Box = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_NewBox = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit.Location = new System.Drawing.Point(179, 327);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(88, 39);
            this.btn_Submit.TabIndex = 1;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            this.btn_Submit.Enter += new System.EventHandler(this.btn_Submit_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Box:";
            // 
            // txt_Box
            // 
            this.txt_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Box.Location = new System.Drawing.Point(52, 274);
            this.txt_Box.Name = "txt_Box";
            this.txt_Box.Size = new System.Drawing.Size(347, 26);
            this.txt_Box.TabIndex = 0;
            // 
            // txt_SN
            // 
            this.txt_SN.Enabled = false;
            this.txt_SN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SN.Location = new System.Drawing.Point(501, 274);
            this.txt_SN.Name = "txt_SN";
            this.txt_SN.Size = new System.Drawing.Size(347, 26);
            this.txt_SN.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(498, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Serial Number:";
            // 
            // txt_CompareBox
            // 
            this.txt_CompareBox.Enabled = false;
            this.txt_CompareBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CompareBox.Location = new System.Drawing.Point(501, 340);
            this.txt_CompareBox.Name = "txt_CompareBox";
            this.txt_CompareBox.Size = new System.Drawing.Size(347, 26);
            this.txt_CompareBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Box:";
            // 
            // pb_Box
            // 
            this.pb_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Box.Location = new System.Drawing.Point(339, 64);
            this.pb_Box.Name = "pb_Box";
            this.pb_Box.Size = new System.Drawing.Size(187, 166);
            this.pb_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Box.TabIndex = 7;
            this.pb_Box.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(358, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Box Compare:";
            // 
            // btn_NewBox
            // 
            this.btn_NewBox.Location = new System.Drawing.Point(654, 207);
            this.btn_NewBox.Name = "btn_NewBox";
            this.btn_NewBox.Size = new System.Drawing.Size(75, 23);
            this.btn_NewBox.TabIndex = 9;
            this.btn_NewBox.TabStop = false;
            this.btn_NewBox.Text = "New Box";
            this.btn_NewBox.UseVisualStyleBackColor = true;
            this.btn_NewBox.Click += new System.EventHandler(this.btn_NewBox_Click);
            // 
            // CheckingBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 516);
            this.Controls.Add(this.btn_NewBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pb_Box);
            this.Controls.Add(this.txt_CompareBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_SN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Submit);
            this.Name = "CheckingBox";
            this.Text = "CheckingBox";
            this.Load += new System.EventHandler(this.CheckingBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Box;
        private System.Windows.Forms.TextBox txt_SN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_CompareBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pb_Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_NewBox;
    }
}