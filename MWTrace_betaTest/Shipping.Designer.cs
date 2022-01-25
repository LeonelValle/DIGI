namespace MWTrace_beta
{
    partial class Shipping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shipping));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_caja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_generar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_registros = new System.Windows.Forms.Label();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.lbl_regAdd = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_cajas = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_borrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 153);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1154, 410);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.DataGridView1_CurrentCellDirtyStateChanged);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DataGridView1_RowPrePaint);
            // 
            // txt_caja
            // 
            this.txt_caja.Location = new System.Drawing.Point(51, 28);
            this.txt_caja.Name = "txt_caja";
            this.txt_caja.Size = new System.Drawing.Size(374, 20);
            this.txt_caja.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Caja:";
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(138, 65);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(75, 23);
            this.btn_agregar.TabIndex = 3;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.Btn_agregar_Click);
            this.btn_agregar.Enter += new System.EventHandler(this.Btn_agregar_Enter);
            // 
            // btn_generar
            // 
            this.btn_generar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_generar.Location = new System.Drawing.Point(1089, 120);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(82, 27);
            this.btn_generar.TabIndex = 11;
            this.btn_generar.TabStop = false;
            this.btn_generar.Text = "Generar";
            this.btn_generar.UseVisualStyleBackColor = true;
            this.btn_generar.Click += new System.EventHandler(this.Btn_generar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Total Registros:";
            // 
            // lbl_registros
            // 
            this.lbl_registros.AutoSize = true;
            this.lbl_registros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_registros.Location = new System.Drawing.Point(101, 135);
            this.lbl_registros.Name = "lbl_registros";
            this.lbl_registros.Size = new System.Drawing.Size(16, 16);
            this.lbl_registros.TabIndex = 13;
            this.lbl_registros.Text = "0";
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_nuevo.Location = new System.Drawing.Point(1096, 12);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(75, 23);
            this.btn_nuevo.TabIndex = 14;
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.Btn_nuevo_Click);
            // 
            // lbl_regAdd
            // 
            this.lbl_regAdd.AutoSize = true;
            this.lbl_regAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_regAdd.Location = new System.Drawing.Point(475, 135);
            this.lbl_regAdd.Name = "lbl_regAdd";
            this.lbl_regAdd.Size = new System.Drawing.Size(16, 16);
            this.lbl_regAdd.TabIndex = 16;
            this.lbl_regAdd.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Registros Agregados:";
            // 
            // lbl_cajas
            // 
            this.lbl_cajas.AutoSize = true;
            this.lbl_cajas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cajas.Location = new System.Drawing.Point(550, 30);
            this.lbl_cajas.Name = "lbl_cajas";
            this.lbl_cajas.Size = new System.Drawing.Size(16, 16);
            this.lbl_cajas.TabIndex = 18;
            this.lbl_cajas.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(448, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Cantidad de Cajas:";
            // 
            // btn_borrar
            // 
            this.btn_borrar.Location = new System.Drawing.Point(263, 65);
            this.btn_borrar.Name = "btn_borrar";
            this.btn_borrar.Size = new System.Drawing.Size(75, 23);
            this.btn_borrar.TabIndex = 19;
            this.btn_borrar.TabStop = false;
            this.btn_borrar.Text = "Borrar";
            this.btn_borrar.UseVisualStyleBackColor = true;
            this.btn_borrar.Click += new System.EventHandler(this.Btn_borrar_Click);
            // 
            // Shipping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 575);
            this.Controls.Add(this.btn_borrar);
            this.Controls.Add(this.lbl_cajas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_regAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_nuevo);
            this.Controls.Add(this.lbl_registros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_generar);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_caja);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Shipping";
            this.Text = "Shipping";
            this.Load += new System.EventHandler(this.Shipping_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_caja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Button btn_generar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_registros;
        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.Label lbl_regAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_cajas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_borrar;
    }
}