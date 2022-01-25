namespace DIGI_Sensor
{
    partial class AuntBattery
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
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.txt_empleado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Modelo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(220, 107);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(75, 23);
            this.btn_aceptar.TabIndex = 8;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // txt_empleado
            // 
            this.txt_empleado.Location = new System.Drawing.Point(118, 20);
            this.txt_empleado.Name = "txt_empleado";
            this.txt_empleado.Size = new System.Drawing.Size(295, 20);
            this.txt_empleado.TabIndex = 1;
            this.txt_empleado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_empleado_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "No. Empleado:";
            // 
            // cb_Modelo
            // 
            this.cb_Modelo.FormattingEnabled = true;
            this.cb_Modelo.Location = new System.Drawing.Point(118, 62);
            this.cb_Modelo.Name = "cb_Modelo";
            this.cb_Modelo.Size = new System.Drawing.Size(295, 21);
            this.cb_Modelo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Modelo:";
            // 
            // AuntBattery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 151);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_Modelo);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.txt_empleado);
            this.Controls.Add(this.label1);
            this.Name = "AuntBattery";
            this.Text = "AuntBattery";
            this.Load += new System.EventHandler(this.AuntBattery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.TextBox txt_empleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Modelo;
        private System.Windows.Forms.Label label2;
    }
}