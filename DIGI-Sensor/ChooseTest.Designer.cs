namespace DIGI_Sensor
{
    partial class ChooseTest
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
            this.btn_3 = new System.Windows.Forms.RadioButton();
            this.btn_all = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_3
            // 
            this.btn_3.AutoSize = true;
            this.btn_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_3.Location = new System.Drawing.Point(60, 57);
            this.btn_3.Name = "btn_3";
            this.btn_3.Size = new System.Drawing.Size(145, 24);
            this.btn_3.TabIndex = 0;
            this.btn_3.TabStop = true;
            this.btn_3.Text = "Current, RF, Nist";
            this.btn_3.UseVisualStyleBackColor = true;
            // 
            // btn_all
            // 
            this.btn_all.AutoSize = true;
            this.btn_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_all.Location = new System.Drawing.Point(60, 87);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(44, 24);
            this.btn_all.TabIndex = 1;
            this.btn_all.TabStop = true;
            this.btn_all.Text = "All";
            this.btn_all.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose Test:";
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit.Location = new System.Drawing.Point(91, 127);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(89, 31);
            this.btn_Submit.TabIndex = 3;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // ChooseTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 170);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.btn_3);
            this.Name = "ChooseTest";
            this.Text = "ChooseTest";
            this.Load += new System.EventHandler(this.ChooseTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton btn_3;
        private System.Windows.Forms.RadioButton btn_all;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Submit;
    }
}