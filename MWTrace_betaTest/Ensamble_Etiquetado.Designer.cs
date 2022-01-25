namespace MWTrace_beta
{
    partial class Ensamble_Etiquetado
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ensamble_Etiquetado));
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_serial = new System.Windows.Forms.Label();
            this.lbl_imei = new System.Windows.Forms.Label();
            this.lbl_numeroempleado = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_ensamble = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_registrados = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_revision = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lbl_countCaja = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_caja = new System.Windows.Forms.TextBox();
            this.txt_serial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_mac = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_imei = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_partnumber = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_UnidadesCaja = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_nuevaCaja = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_modeloCaja = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ORDEN:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(662, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 30);
            this.button1.TabIndex = 13;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            this.button1.Enter += new System.EventHandler(this.Button1_Enter);
            this.button1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Button1_KeyUp);
            // 
            // lbl_serial
            // 
            this.lbl_serial.AutoSize = true;
            this.lbl_serial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_serial.ForeColor = System.Drawing.Color.Red;
            this.lbl_serial.Location = new System.Drawing.Point(95, 8);
            this.lbl_serial.Name = "lbl_serial";
            this.lbl_serial.Size = new System.Drawing.Size(61, 16);
            this.lbl_serial.TabIndex = 5;
            this.lbl_serial.Text = "SERIAL";
            // 
            // lbl_imei
            // 
            this.lbl_imei.AutoSize = true;
            this.lbl_imei.Location = new System.Drawing.Point(174, 11);
            this.lbl_imei.Name = "lbl_imei";
            this.lbl_imei.Size = new System.Drawing.Size(0, 13);
            this.lbl_imei.TabIndex = 8;
            // 
            // lbl_numeroempleado
            // 
            this.lbl_numeroempleado.AutoSize = true;
            this.lbl_numeroempleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_numeroempleado.ForeColor = System.Drawing.Color.Red;
            this.lbl_numeroempleado.Location = new System.Drawing.Point(691, 8);
            this.lbl_numeroempleado.Name = "lbl_numeroempleado";
            this.lbl_numeroempleado.Size = new System.Drawing.Size(59, 16);
            this.lbl_numeroempleado.TabIndex = 13;
            this.lbl_numeroempleado.Text = "numero";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(618, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "No. Empleado:";
            // 
            // lbl_ensamble
            // 
            this.lbl_ensamble.AutoSize = true;
            this.lbl_ensamble.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ensamble.ForeColor = System.Drawing.Color.Red;
            this.lbl_ensamble.Location = new System.Drawing.Point(387, 7);
            this.lbl_ensamble.Name = "lbl_ensamble";
            this.lbl_ensamble.Size = new System.Drawing.Size(89, 16);
            this.lbl_ensamble.TabIndex = 18;
            this.lbl_ensamble.Text = "ENSAMBLE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(313, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "ENSAMBLE:";
            // 
            // lbl_registrados
            // 
            this.lbl_registrados.AutoSize = true;
            this.lbl_registrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_registrados.ForeColor = System.Drawing.Color.Black;
            this.lbl_registrados.Location = new System.Drawing.Point(95, 358);
            this.lbl_registrados.Name = "lbl_registrados";
            this.lbl_registrados.Size = new System.Drawing.Size(93, 16);
            this.lbl_registrados.TabIndex = 20;
            this.lbl_registrados.Text = "Registrados";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 361);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Registrados:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(863, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Revision:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DIGITraceTest.Properties.Resources.logo_digi;
            this.pictureBox1.Location = new System.Drawing.Point(1290, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 195);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // txt_revision
            // 
            this.txt_revision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_revision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_revision.Location = new System.Drawing.Point(920, 8);
            this.txt_revision.Name = "txt_revision";
            this.txt_revision.Size = new System.Drawing.Size(39, 21);
            this.txt_revision.TabIndex = 0;
            this.txt_revision.TabStop = false;
            this.txt_revision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_revision.TextChanged += new System.EventHandler(this.Txt_revision_TextChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 701);
            this.splitter1.TabIndex = 28;
            this.splitter1.TabStop = false;
            // 
            // lbl_countCaja
            // 
            this.lbl_countCaja.AutoSize = true;
            this.lbl_countCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_countCaja.ForeColor = System.Drawing.Color.Black;
            this.lbl_countCaja.Location = new System.Drawing.Point(1041, 358);
            this.lbl_countCaja.Name = "lbl_countCaja";
            this.lbl_countCaja.Size = new System.Drawing.Size(53, 16);
            this.lbl_countCaja.TabIndex = 30;
            this.lbl_countCaja.Text = "N.caja";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1004, 361);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 29;
            this.label19.Text = "Caja:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(238, 313);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "Caja:";
            // 
            // txt_caja
            // 
            this.txt_caja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_caja.Location = new System.Drawing.Point(275, 306);
            this.txt_caja.Name = "txt_caja";
            this.txt_caja.Size = new System.Drawing.Size(379, 20);
            this.txt_caja.TabIndex = 11;
            // 
            // txt_serial
            // 
            this.txt_serial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_serial.Location = new System.Drawing.Point(117, 118);
            this.txt_serial.Name = "txt_serial";
            this.txt_serial.Size = new System.Drawing.Size(532, 20);
            this.txt_serial.TabIndex = 3;
            this.txt_serial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Tap_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "SERIAL NUMBER:";
            // 
            // txt_mac
            // 
            this.txt_mac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_mac.Location = new System.Drawing.Point(117, 78);
            this.txt_mac.Name = "txt_mac";
            this.txt_mac.Size = new System.Drawing.Size(532, 20);
            this.txt_mac.TabIndex = 2;
            this.txt_mac.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Tap_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MAC ADDRESS:";
            // 
            // txt_imei
            // 
            this.txt_imei.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_imei.Location = new System.Drawing.Point(117, 33);
            this.txt_imei.Name = "txt_imei";
            this.txt_imei.Size = new System.Drawing.Size(532, 20);
            this.txt_imei.TabIndex = 0;
            this.txt_imei.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Tap_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "IMEI NUMBER:";
            // 
            // txt_partnumber
            // 
            this.txt_partnumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_partnumber.Location = new System.Drawing.Point(117, 165);
            this.txt_partnumber.Name = "txt_partnumber";
            this.txt_partnumber.Size = new System.Drawing.Size(532, 20);
            this.txt_partnumber.TabIndex = 5;
            this.txt_partnumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Tap_KeyUp);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(45, 172);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "PartNumber:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txt_partnumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_imei);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_mac);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_serial);
            this.groupBox1.Location = new System.Drawing.Point(366, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 228);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unidad";
            // 
            // txt_UnidadesCaja
            // 
            this.txt_UnidadesCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UnidadesCaja.Location = new System.Drawing.Point(1100, 4);
            this.txt_UnidadesCaja.Name = "txt_UnidadesCaja";
            this.txt_UnidadesCaja.Size = new System.Drawing.Size(55, 21);
            this.txt_UnidadesCaja.TabIndex = 31;
            this.txt_UnidadesCaja.TabStop = false;
            this.txt_UnidadesCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_UnidadesCaja.TextChanged += new System.EventHandler(this.Txt_UnidadesCaja_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1013, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Unidades/Caja:";
            // 
            // btn_nuevaCaja
            // 
            this.btn_nuevaCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_nuevaCaja.Location = new System.Drawing.Point(1668, 354);
            this.btn_nuevaCaja.Name = "btn_nuevaCaja";
            this.btn_nuevaCaja.Size = new System.Drawing.Size(75, 29);
            this.btn_nuevaCaja.TabIndex = 33;
            this.btn_nuevaCaja.TabStop = false;
            this.btn_nuevaCaja.Text = "New Box";
            this.btn_nuevaCaja.UseVisualStyleBackColor = true;
            this.btn_nuevaCaja.Click += new System.EventHandler(this.Btn_nuevaCaja_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(754, 313);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Modelo:";
            // 
            // txt_modeloCaja
            // 
            this.txt_modeloCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_modeloCaja.Location = new System.Drawing.Point(805, 306);
            this.txt_modeloCaja.Name = "txt_modeloCaja";
            this.txt_modeloCaja.Size = new System.Drawing.Size(390, 20);
            this.txt_modeloCaja.TabIndex = 12;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 389);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1734, 300);
            this.dataGridView1.TabIndex = 36;
            this.dataGridView1.TabStop = false;
            // 
            // Ensamble_Etiquetado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1755, 701);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_modeloCaja);
            this.Controls.Add(this.btn_nuevaCaja);
            this.Controls.Add(this.txt_UnidadesCaja);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lbl_countCaja);
            this.Controls.Add(this.txt_caja);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.txt_revision);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_registrados);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_ensamble);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_numeroempleado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_imei);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_serial);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ensamble_Etiquetado";
            this.Text = "Empaque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ensamble_Etiquetado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_serial;
        private System.Windows.Forms.Label lbl_imei;
        private System.Windows.Forms.Label lbl_numeroempleado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_ensamble;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_registrados;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_revision;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label lbl_countCaja;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_caja;
        private System.Windows.Forms.TextBox txt_serial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_mac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_imei;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_partnumber;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_UnidadesCaja;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_nuevaCaja;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_modeloCaja;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}