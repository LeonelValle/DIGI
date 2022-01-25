
namespace IX30_Project
{
    partial class CreateWO
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.cb_PN = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Rev = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Qty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_WO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(427, 375);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(109, 34);
            this.btn_Cancel.TabIndex = 19;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(202, 375);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(109, 34);
            this.btn_Submit.TabIndex = 18;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // cb_PN
            // 
            this.cb_PN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PN.FormattingEnabled = true;
            this.cb_PN.Location = new System.Drawing.Point(202, 151);
            this.cb_PN.Name = "cb_PN";
            this.cb_PN.Size = new System.Drawing.Size(334, 21);
            this.cb_PN.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Part #:";
            // 
            // txt_Rev
            // 
            this.txt_Rev.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Rev.Location = new System.Drawing.Point(202, 303);
            this.txt_Rev.Name = "txt_Rev";
            this.txt_Rev.Size = new System.Drawing.Size(334, 20);
            this.txt_Rev.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Revision";
            // 
            // txt_Qty
            // 
            this.txt_Qty.Location = new System.Drawing.Point(202, 225);
            this.txt_Qty.Name = "txt_Qty";
            this.txt_Qty.Size = new System.Drawing.Size(334, 20);
            this.txt_Qty.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Quantity:";
            // 
            // txt_WO
            // 
            this.txt_WO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_WO.Location = new System.Drawing.Point(202, 78);
            this.txt_WO.Name = "txt_WO";
            this.txt_WO.Size = new System.Drawing.Size(334, 20);
            this.txt_WO.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Work Order:";
            // 
            // CreateWO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 475);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.cb_PN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Rev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Qty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_WO);
            this.Controls.Add(this.label1);
            this.Name = "CreateWO";
            this.Text = "CreateWO";
            this.Load += new System.EventHandler(this.CreateWO_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.ComboBox cb_PN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Rev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Qty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_WO;
        private System.Windows.Forms.Label label1;
    }
}