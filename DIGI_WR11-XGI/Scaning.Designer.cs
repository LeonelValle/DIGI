namespace DIGI_WR11_XGI
{
    partial class Scaning
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
            this.lbl_imeiPCBA = new System.Windows.Forms.Label();
            this.txt_ScanTablero = new System.Windows.Forms.TextBox();
            this.dg_Scan = new System.Windows.Forms.DataGridView();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.lbl_WO = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Employ = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Records = new System.Windows.Forms.Label();
            this.txt_ScanSN = new System.Windows.Forms.TextBox();
            this.lbl_snPCBA = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_ensamble = new System.Windows.Forms.Label();
            this.gb_PCBA = new System.Windows.Forms.GroupBox();
            this.lbl_eui64 = new System.Windows.Forms.Label();
            this.txt_eui64 = new System.Windows.Forms.TextBox();
            this.gb_EtiquetaCover = new System.Windows.Forms.GroupBox();
            this.txt_SNEtiqueta = new System.Windows.Forms.TextBox();
            this.lbl_imeiEtiqueta = new System.Windows.Forms.Label();
            this.txt_IMEIEtiqueta = new System.Windows.Forms.TextBox();
            this.lbl_macCover = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_MACEtiqueta = new System.Windows.Forms.TextBox();
            this.gb_EtiquetaSuelta = new System.Windows.Forms.GroupBox();
            this.txt_SNSuelta = new System.Windows.Forms.TextBox();
            this.lbl_imeiSuelta = new System.Windows.Forms.Label();
            this.txt_IMEISuelta = new System.Windows.Forms.TextBox();
            this.lbl_macSuelta = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_MACSuelta = new System.Windows.Forms.TextBox();
            this.gb_EtiquetaCaja = new System.Windows.Forms.GroupBox();
            this.lbl_imeiCajas = new System.Windows.Forms.Label();
            this.txt_PN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_SNCaja = new System.Windows.Forms.TextBox();
            this.txt_IMEICaja = new System.Windows.Forms.TextBox();
            this.lbl_macCaja = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_MACCaja = new System.Windows.Forms.TextBox();
            this.btn_Submit2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Scan)).BeginInit();
            this.gb_PCBA.SuspendLayout();
            this.gb_EtiquetaCover.SuspendLayout();
            this.gb_EtiquetaSuelta.SuspendLayout();
            this.gb_EtiquetaCaja.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_imeiPCBA
            // 
            this.lbl_imeiPCBA.AutoSize = true;
            this.lbl_imeiPCBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_imeiPCBA.Location = new System.Drawing.Point(21, 19);
            this.lbl_imeiPCBA.Name = "lbl_imeiPCBA";
            this.lbl_imeiPCBA.Size = new System.Drawing.Size(135, 13);
            this.lbl_imeiPCBA.TabIndex = 0;
            this.lbl_imeiPCBA.Text = "SCAN IMEI TABLERO:";
            // 
            // txt_ScanTablero
            // 
            this.txt_ScanTablero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ScanTablero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ScanTablero.Location = new System.Drawing.Point(24, 38);
            this.txt_ScanTablero.Name = "txt_ScanTablero";
            this.txt_ScanTablero.Size = new System.Drawing.Size(389, 20);
            this.txt_ScanTablero.TabIndex = 1;
            // 
            // dg_Scan
            // 
            this.dg_Scan.AllowUserToAddRows = false;
            this.dg_Scan.AllowUserToDeleteRows = false;
            this.dg_Scan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Scan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_Scan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Scan.Location = new System.Drawing.Point(12, 314);
            this.dg_Scan.Name = "dg_Scan";
            this.dg_Scan.ReadOnly = true;
            this.dg_Scan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Scan.Size = new System.Drawing.Size(1516, 475);
            this.dg_Scan.TabIndex = 2;
            this.dg_Scan.TabStop = false;
            this.dg_Scan.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dg_Scan_RowsAdded);
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit.Location = new System.Drawing.Point(416, 253);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(121, 44);
            this.btn_Submit.TabIndex = 4;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            this.btn_Submit.Enter += new System.EventHandler(this.btn_Submit_Enter);
            // 
            // lbl_WO
            // 
            this.lbl_WO.AutoSize = true;
            this.lbl_WO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_WO.Location = new System.Drawing.Point(111, 9);
            this.lbl_WO.Name = "lbl_WO";
            this.lbl_WO.Size = new System.Drawing.Size(38, 20);
            this.lbl_WO.TabIndex = 4;
            this.lbl_WO.Text = "WO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "WorkOrder:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1008, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Employ #:";
            // 
            // lbl_Employ
            // 
            this.lbl_Employ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Employ.AutoSize = true;
            this.lbl_Employ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Employ.Location = new System.Drawing.Point(1101, 9);
            this.lbl_Employ.Name = "lbl_Employ";
            this.lbl_Employ.Size = new System.Drawing.Size(65, 20);
            this.lbl_Employ.TabIndex = 6;
            this.lbl_Employ.Text = "employ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Records:";
            // 
            // lbl_Records
            // 
            this.lbl_Records.AutoSize = true;
            this.lbl_Records.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Records.Location = new System.Drawing.Point(102, 291);
            this.lbl_Records.Name = "lbl_Records";
            this.lbl_Records.Size = new System.Drawing.Size(76, 20);
            this.lbl_Records.TabIndex = 8;
            this.lbl_Records.Text = "Records";
            // 
            // txt_ScanSN
            // 
            this.txt_ScanSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ScanSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ScanSN.Location = new System.Drawing.Point(24, 144);
            this.txt_ScanSN.Name = "txt_ScanSN";
            this.txt_ScanSN.Size = new System.Drawing.Size(389, 20);
            this.txt_ScanSN.TabIndex = 3;
            // 
            // lbl_snPCBA
            // 
            this.lbl_snPCBA.AutoSize = true;
            this.lbl_snPCBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_snPCBA.Location = new System.Drawing.Point(21, 125);
            this.lbl_snPCBA.Name = "lbl_snPCBA";
            this.lbl_snPCBA.Size = new System.Drawing.Size(149, 13);
            this.lbl_snPCBA.TabIndex = 12;
            this.lbl_snPCBA.Text = "SCAN SERIAL NUMBER:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(578, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Ensamble:";
            // 
            // lbl_ensamble
            // 
            this.lbl_ensamble.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ensamble.AutoSize = true;
            this.lbl_ensamble.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ensamble.Location = new System.Drawing.Point(677, 9);
            this.lbl_ensamble.Name = "lbl_ensamble";
            this.lbl_ensamble.Size = new System.Drawing.Size(86, 20);
            this.lbl_ensamble.TabIndex = 14;
            this.lbl_ensamble.Text = "ensamble";
            // 
            // gb_PCBA
            // 
            this.gb_PCBA.Controls.Add(this.lbl_eui64);
            this.gb_PCBA.Controls.Add(this.txt_eui64);
            this.gb_PCBA.Controls.Add(this.txt_ScanSN);
            this.gb_PCBA.Controls.Add(this.lbl_imeiPCBA);
            this.gb_PCBA.Controls.Add(this.txt_ScanTablero);
            this.gb_PCBA.Controls.Add(this.lbl_snPCBA);
            this.gb_PCBA.Location = new System.Drawing.Point(19, 43);
            this.gb_PCBA.Name = "gb_PCBA";
            this.gb_PCBA.Size = new System.Drawing.Size(469, 192);
            this.gb_PCBA.TabIndex = 16;
            this.gb_PCBA.TabStop = false;
            this.gb_PCBA.Text = "PCBA";
            // 
            // lbl_eui64
            // 
            this.lbl_eui64.AutoSize = true;
            this.lbl_eui64.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_eui64.Location = new System.Drawing.Point(21, 70);
            this.lbl_eui64.Name = "lbl_eui64";
            this.lbl_eui64.Size = new System.Drawing.Size(144, 13);
            this.lbl_eui64.TabIndex = 13;
            this.lbl_eui64.Text = "SCAN EUI64 TABLERO:";
            // 
            // txt_eui64
            // 
            this.txt_eui64.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_eui64.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_eui64.Location = new System.Drawing.Point(24, 89);
            this.txt_eui64.Name = "txt_eui64";
            this.txt_eui64.Size = new System.Drawing.Size(389, 20);
            this.txt_eui64.TabIndex = 14;
            // 
            // gb_EtiquetaCover
            // 
            this.gb_EtiquetaCover.Controls.Add(this.txt_SNEtiqueta);
            this.gb_EtiquetaCover.Controls.Add(this.lbl_imeiEtiqueta);
            this.gb_EtiquetaCover.Controls.Add(this.txt_IMEIEtiqueta);
            this.gb_EtiquetaCover.Controls.Add(this.lbl_macCover);
            this.gb_EtiquetaCover.Controls.Add(this.label10);
            this.gb_EtiquetaCover.Controls.Add(this.txt_MACEtiqueta);
            this.gb_EtiquetaCover.Location = new System.Drawing.Point(569, 43);
            this.gb_EtiquetaCover.Name = "gb_EtiquetaCover";
            this.gb_EtiquetaCover.Size = new System.Drawing.Size(469, 192);
            this.gb_EtiquetaCover.TabIndex = 17;
            this.gb_EtiquetaCover.TabStop = false;
            this.gb_EtiquetaCover.Text = "ETIQUETA COVER";
            // 
            // txt_SNEtiqueta
            // 
            this.txt_SNEtiqueta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_SNEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SNEtiqueta.Location = new System.Drawing.Point(24, 144);
            this.txt_SNEtiqueta.Name = "txt_SNEtiqueta";
            this.txt_SNEtiqueta.Size = new System.Drawing.Size(389, 20);
            this.txt_SNEtiqueta.TabIndex = 3;
            // 
            // lbl_imeiEtiqueta
            // 
            this.lbl_imeiEtiqueta.AutoSize = true;
            this.lbl_imeiEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_imeiEtiqueta.Location = new System.Drawing.Point(21, 19);
            this.lbl_imeiEtiqueta.Name = "lbl_imeiEtiqueta";
            this.lbl_imeiEtiqueta.Size = new System.Drawing.Size(74, 13);
            this.lbl_imeiEtiqueta.TabIndex = 0;
            this.lbl_imeiEtiqueta.Text = "SCAN IMEI:";
            // 
            // txt_IMEIEtiqueta
            // 
            this.txt_IMEIEtiqueta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_IMEIEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IMEIEtiqueta.Location = new System.Drawing.Point(24, 38);
            this.txt_IMEIEtiqueta.Name = "txt_IMEIEtiqueta";
            this.txt_IMEIEtiqueta.Size = new System.Drawing.Size(389, 20);
            this.txt_IMEIEtiqueta.TabIndex = 1;
            // 
            // lbl_macCover
            // 
            this.lbl_macCover.AutoSize = true;
            this.lbl_macCover.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_macCover.Location = new System.Drawing.Point(21, 70);
            this.lbl_macCover.Name = "lbl_macCover";
            this.lbl_macCover.Size = new System.Drawing.Size(74, 13);
            this.lbl_macCover.TabIndex = 10;
            this.lbl_macCover.Text = "SCAN MAC:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "SCAN SERIAL NUMBER:";
            // 
            // txt_MACEtiqueta
            // 
            this.txt_MACEtiqueta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_MACEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MACEtiqueta.Location = new System.Drawing.Point(24, 89);
            this.txt_MACEtiqueta.Name = "txt_MACEtiqueta";
            this.txt_MACEtiqueta.Size = new System.Drawing.Size(389, 20);
            this.txt_MACEtiqueta.TabIndex = 2;
            // 
            // gb_EtiquetaSuelta
            // 
            this.gb_EtiquetaSuelta.Controls.Add(this.txt_SNSuelta);
            this.gb_EtiquetaSuelta.Controls.Add(this.lbl_imeiSuelta);
            this.gb_EtiquetaSuelta.Controls.Add(this.txt_IMEISuelta);
            this.gb_EtiquetaSuelta.Controls.Add(this.lbl_macSuelta);
            this.gb_EtiquetaSuelta.Controls.Add(this.label13);
            this.gb_EtiquetaSuelta.Controls.Add(this.txt_MACSuelta);
            this.gb_EtiquetaSuelta.Location = new System.Drawing.Point(145, 37);
            this.gb_EtiquetaSuelta.Name = "gb_EtiquetaSuelta";
            this.gb_EtiquetaSuelta.Size = new System.Drawing.Size(469, 192);
            this.gb_EtiquetaSuelta.TabIndex = 17;
            this.gb_EtiquetaSuelta.TabStop = false;
            this.gb_EtiquetaSuelta.Text = "Etiqueta Suelta";
            // 
            // txt_SNSuelta
            // 
            this.txt_SNSuelta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_SNSuelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SNSuelta.Location = new System.Drawing.Point(24, 144);
            this.txt_SNSuelta.Name = "txt_SNSuelta";
            this.txt_SNSuelta.Size = new System.Drawing.Size(389, 20);
            this.txt_SNSuelta.TabIndex = 3;
            // 
            // lbl_imeiSuelta
            // 
            this.lbl_imeiSuelta.AutoSize = true;
            this.lbl_imeiSuelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_imeiSuelta.Location = new System.Drawing.Point(21, 19);
            this.lbl_imeiSuelta.Name = "lbl_imeiSuelta";
            this.lbl_imeiSuelta.Size = new System.Drawing.Size(74, 13);
            this.lbl_imeiSuelta.TabIndex = 0;
            this.lbl_imeiSuelta.Text = "SCAN IMEI:";
            // 
            // txt_IMEISuelta
            // 
            this.txt_IMEISuelta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_IMEISuelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IMEISuelta.Location = new System.Drawing.Point(24, 38);
            this.txt_IMEISuelta.Name = "txt_IMEISuelta";
            this.txt_IMEISuelta.Size = new System.Drawing.Size(389, 20);
            this.txt_IMEISuelta.TabIndex = 1;
            // 
            // lbl_macSuelta
            // 
            this.lbl_macSuelta.AutoSize = true;
            this.lbl_macSuelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_macSuelta.Location = new System.Drawing.Point(21, 70);
            this.lbl_macSuelta.Name = "lbl_macSuelta";
            this.lbl_macSuelta.Size = new System.Drawing.Size(74, 13);
            this.lbl_macSuelta.TabIndex = 10;
            this.lbl_macSuelta.Text = "SCAN MAC:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(21, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(149, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "SCAN SERIAL NUMBER:";
            // 
            // txt_MACSuelta
            // 
            this.txt_MACSuelta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_MACSuelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MACSuelta.Location = new System.Drawing.Point(24, 89);
            this.txt_MACSuelta.Name = "txt_MACSuelta";
            this.txt_MACSuelta.Size = new System.Drawing.Size(389, 20);
            this.txt_MACSuelta.TabIndex = 2;
            // 
            // gb_EtiquetaCaja
            // 
            this.gb_EtiquetaCaja.Controls.Add(this.lbl_imeiCajas);
            this.gb_EtiquetaCaja.Controls.Add(this.txt_PN);
            this.gb_EtiquetaCaja.Controls.Add(this.label5);
            this.gb_EtiquetaCaja.Controls.Add(this.txt_SNCaja);
            this.gb_EtiquetaCaja.Controls.Add(this.txt_IMEICaja);
            this.gb_EtiquetaCaja.Controls.Add(this.lbl_macCaja);
            this.gb_EtiquetaCaja.Controls.Add(this.label16);
            this.gb_EtiquetaCaja.Controls.Add(this.txt_MACCaja);
            this.gb_EtiquetaCaja.Location = new System.Drawing.Point(693, 32);
            this.gb_EtiquetaCaja.Name = "gb_EtiquetaCaja";
            this.gb_EtiquetaCaja.Size = new System.Drawing.Size(469, 221);
            this.gb_EtiquetaCaja.TabIndex = 17;
            this.gb_EtiquetaCaja.TabStop = false;
            this.gb_EtiquetaCaja.Text = "Etiqueta de Caja";
            // 
            // lbl_imeiCajas
            // 
            this.lbl_imeiCajas.AutoSize = true;
            this.lbl_imeiCajas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_imeiCajas.Location = new System.Drawing.Point(21, 22);
            this.lbl_imeiCajas.Name = "lbl_imeiCajas";
            this.lbl_imeiCajas.Size = new System.Drawing.Size(74, 13);
            this.lbl_imeiCajas.TabIndex = 15;
            this.lbl_imeiCajas.Text = "SCAN IMEI:";
            // 
            // txt_PN
            // 
            this.txt_PN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_PN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PN.Location = new System.Drawing.Point(24, 189);
            this.txt_PN.Name = "txt_PN";
            this.txt_PN.Size = new System.Drawing.Size(389, 20);
            this.txt_PN.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "SCAN Part N#:";
            // 
            // txt_SNCaja
            // 
            this.txt_SNCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_SNCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SNCaja.Location = new System.Drawing.Point(24, 144);
            this.txt_SNCaja.Name = "txt_SNCaja";
            this.txt_SNCaja.Size = new System.Drawing.Size(389, 20);
            this.txt_SNCaja.TabIndex = 3;
            // 
            // txt_IMEICaja
            // 
            this.txt_IMEICaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_IMEICaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IMEICaja.Location = new System.Drawing.Point(24, 38);
            this.txt_IMEICaja.Name = "txt_IMEICaja";
            this.txt_IMEICaja.Size = new System.Drawing.Size(389, 20);
            this.txt_IMEICaja.TabIndex = 1;
            // 
            // lbl_macCaja
            // 
            this.lbl_macCaja.AutoSize = true;
            this.lbl_macCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_macCaja.Location = new System.Drawing.Point(21, 70);
            this.lbl_macCaja.Name = "lbl_macCaja";
            this.lbl_macCaja.Size = new System.Drawing.Size(74, 13);
            this.lbl_macCaja.TabIndex = 10;
            this.lbl_macCaja.Text = "SCAN MAC:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(21, 125);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(149, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "SCAN SERIAL NUMBER:";
            // 
            // txt_MACCaja
            // 
            this.txt_MACCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_MACCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MACCaja.Location = new System.Drawing.Point(24, 89);
            this.txt_MACCaja.Name = "txt_MACCaja";
            this.txt_MACCaja.Size = new System.Drawing.Size(389, 20);
            this.txt_MACCaja.TabIndex = 2;
            // 
            // btn_Submit2
            // 
            this.btn_Submit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit2.Location = new System.Drawing.Point(543, 253);
            this.btn_Submit2.Name = "btn_Submit2";
            this.btn_Submit2.Size = new System.Drawing.Size(121, 44);
            this.btn_Submit2.TabIndex = 18;
            this.btn_Submit2.Text = "Submit";
            this.btn_Submit2.UseVisualStyleBackColor = true;
            this.btn_Submit2.Click += new System.EventHandler(this.btn_Submit2_Click);
            // 
            // Scaning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 801);
            this.Controls.Add(this.gb_EtiquetaSuelta);
            this.Controls.Add(this.gb_PCBA);
            this.Controls.Add(this.btn_Submit2);
            this.Controls.Add(this.gb_EtiquetaCaja);
            this.Controls.Add(this.gb_EtiquetaCover);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_ensamble);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_Records);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Employ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_WO);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.dg_Scan);
            this.Name = "Scaning";
            this.Text = "Scaning";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Scaning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Scan)).EndInit();
            this.gb_PCBA.ResumeLayout(false);
            this.gb_PCBA.PerformLayout();
            this.gb_EtiquetaCover.ResumeLayout(false);
            this.gb_EtiquetaCover.PerformLayout();
            this.gb_EtiquetaSuelta.ResumeLayout(false);
            this.gb_EtiquetaSuelta.PerformLayout();
            this.gb_EtiquetaCaja.ResumeLayout(false);
            this.gb_EtiquetaCaja.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_imeiPCBA;
        private System.Windows.Forms.TextBox txt_ScanTablero;
        private System.Windows.Forms.DataGridView dg_Scan;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Label lbl_WO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Employ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Records;
        private System.Windows.Forms.TextBox txt_ScanSN;
        private System.Windows.Forms.Label lbl_snPCBA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_ensamble;
        private System.Windows.Forms.GroupBox gb_PCBA;
        private System.Windows.Forms.GroupBox gb_EtiquetaCover;
        private System.Windows.Forms.TextBox txt_SNEtiqueta;
        private System.Windows.Forms.Label lbl_imeiEtiqueta;
        private System.Windows.Forms.TextBox txt_IMEIEtiqueta;
        private System.Windows.Forms.Label lbl_macCover;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_MACEtiqueta;
        private System.Windows.Forms.GroupBox gb_EtiquetaSuelta;
        private System.Windows.Forms.GroupBox gb_EtiquetaCaja;
        private System.Windows.Forms.TextBox txt_SNCaja;
        private System.Windows.Forms.TextBox txt_IMEICaja;
        private System.Windows.Forms.Label lbl_macCaja;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_MACCaja;
        private System.Windows.Forms.TextBox txt_SNSuelta;
        private System.Windows.Forms.Label lbl_imeiSuelta;
        private System.Windows.Forms.TextBox txt_IMEISuelta;
        private System.Windows.Forms.Label lbl_macSuelta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_MACSuelta;
        private System.Windows.Forms.Button btn_Submit2;
        private System.Windows.Forms.TextBox txt_PN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_imeiCajas;
        private System.Windows.Forms.Label lbl_eui64;
        private System.Windows.Forms.TextBox txt_eui64;
    }
}