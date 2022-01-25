
namespace IX30_Project
{
    partial class Generate
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cb_pn = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_IMEI = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.link_reprint = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(781, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 282);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1710, 524);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.VirtualMode = true;
            // 
            // cb_pn
            // 
            this.cb_pn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_pn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_pn.FormattingEnabled = true;
            this.cb_pn.Location = new System.Drawing.Point(169, 12);
            this.cb_pn.Name = "cb_pn";
            this.cb_pn.Size = new System.Drawing.Size(239, 33);
            this.cb_pn.TabIndex = 3;
            this.cb_pn.SelectedIndexChanged += new System.EventHandler(this.cb_pn_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Part N#:";
            // 
            // txt_IMEI
            // 
            this.txt_IMEI.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IMEI.Location = new System.Drawing.Point(591, 145);
            this.txt_IMEI.Name = "txt_IMEI";
            this.txt_IMEI.Size = new System.Drawing.Size(494, 29);
            this.txt_IMEI.TabIndex = 5;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(473, 150);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(100, 24);
            this.lbl.TabIndex = 6;
            this.lbl.Text = "Scan IMEI:";
            // 
            // link_reprint
            // 
            this.link_reprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.link_reprint.AutoSize = true;
            this.link_reprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_reprint.Location = new System.Drawing.Point(1671, 9);
            this.link_reprint.Name = "link_reprint";
            this.link_reprint.Size = new System.Drawing.Size(51, 16);
            this.link_reprint.TabIndex = 7;
            this.link_reprint.TabStop = true;
            this.link_reprint.Text = "Reprint";
            this.link_reprint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_reprint_LinkClicked);
            // 
            // Generate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1734, 818);
            this.Controls.Add(this.link_reprint);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txt_IMEI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_pn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Generate";
            this.Text = "Generate Labels IX30 [V1.5.8]";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cb_pn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_IMEI;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.LinkLabel link_reprint;
    }
}

