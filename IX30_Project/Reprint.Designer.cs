
namespace IX30_Project
{
    partial class Reprint
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
            this.dg_Reprint = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btn_Print = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Reprint)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Reprint
            // 
            this.dg_Reprint.AllowUserToOrderColumns = true;
            this.dg_Reprint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Reprint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Reprint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dg_Reprint.Location = new System.Drawing.Point(12, 122);
            this.dg_Reprint.Name = "dg_Reprint";
            this.dg_Reprint.Size = new System.Drawing.Size(1638, 678);
            this.dg_Reprint.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Re-Print";
            this.Column1.Name = "Column1";
            // 
            // btn_Print
            // 
            this.btn_Print.Location = new System.Drawing.Point(745, 74);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(100, 42);
            this.btn_Print.TabIndex = 8;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(716, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Reprint Labels";
            // 
            // Reprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1662, 812);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dg_Reprint);
            this.Controls.Add(this.btn_Print);
            this.Name = "Reprint";
            this.Text = "Reprint";
            this.Load += new System.EventHandler(this.Reprint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Reprint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_Reprint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Label label1;
    }
}