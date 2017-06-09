namespace MainApplication
{
    partial class Admin
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtMachineGuid = new System.Windows.Forms.TextBox();
            this.txtClientHash = new System.Windows.Forms.TextBox();
            this.txtServerGuid = new System.Windows.Forms.TextBox();
            this.txtServerHash = new System.Windows.Forms.TextBox();
            this.btnGetLicenced = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.txtInstalationDate = new System.Windows.Forms.TextBox();
            this.btnGetAppData = new System.Windows.Forms.Button();
            this.btnSaveAppData = new System.Windows.Forms.Button();
            this.chValid = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLastDate = new System.Windows.Forms.TextBox();
            this.txtRunTimes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate Encrypted File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Customer",
            "Part",
            "PartByProvider",
            "PartForSubProduct",
            "Product",
            "Provider",
            "Quote",
            "Sale",
            "Stat",
            "SubProduct",
            "SubProductForTransaction"});
            this.comboBox1.Location = new System.Drawing.Point(13, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(220, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // txtMachineGuid
            // 
            this.txtMachineGuid.Location = new System.Drawing.Point(69, 64);
            this.txtMachineGuid.Name = "txtMachineGuid";
            this.txtMachineGuid.Size = new System.Drawing.Size(204, 20);
            this.txtMachineGuid.TabIndex = 5;
            // 
            // txtClientHash
            // 
            this.txtClientHash.Location = new System.Drawing.Point(69, 90);
            this.txtClientHash.Name = "txtClientHash";
            this.txtClientHash.Size = new System.Drawing.Size(204, 20);
            this.txtClientHash.TabIndex = 5;
            // 
            // txtServerGuid
            // 
            this.txtServerGuid.Location = new System.Drawing.Point(393, 64);
            this.txtServerGuid.Name = "txtServerGuid";
            this.txtServerGuid.Size = new System.Drawing.Size(204, 20);
            this.txtServerGuid.TabIndex = 5;
            // 
            // txtServerHash
            // 
            this.txtServerHash.Location = new System.Drawing.Point(393, 90);
            this.txtServerHash.Name = "txtServerHash";
            this.txtServerHash.Size = new System.Drawing.Size(204, 20);
            this.txtServerHash.TabIndex = 5;
            // 
            // btnGetLicenced
            // 
            this.btnGetLicenced.Location = new System.Drawing.Point(279, 64);
            this.btnGetLicenced.Name = "btnGetLicenced";
            this.btnGetLicenced.Size = new System.Drawing.Size(108, 46);
            this.btnGetLicenced.TabIndex = 6;
            this.btnGetLicenced.Text = "GetLicence";
            this.btnGetLicenced.UseVisualStyleBackColor = true;
            this.btnGetLicenced.Click += new System.EventHandler(this.btnGetLicenced_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Guid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hash";
            // 
            // txtLicense
            // 
            this.txtLicense.Location = new System.Drawing.Point(195, 131);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Size = new System.Drawing.Size(204, 20);
            this.txtLicense.TabIndex = 5;
            // 
            // txtInstalationDate
            // 
            this.txtInstalationDate.Location = new System.Drawing.Point(195, 157);
            this.txtInstalationDate.Name = "txtInstalationDate";
            this.txtInstalationDate.Size = new System.Drawing.Size(204, 20);
            this.txtInstalationDate.TabIndex = 5;
            // 
            // btnGetAppData
            // 
            this.btnGetAppData.Location = new System.Drawing.Point(13, 131);
            this.btnGetAppData.Name = "btnGetAppData";
            this.btnGetAppData.Size = new System.Drawing.Size(50, 48);
            this.btnGetAppData.TabIndex = 8;
            this.btnGetAppData.Text = "Get App Data";
            this.btnGetAppData.UseVisualStyleBackColor = true;
            this.btnGetAppData.Click += new System.EventHandler(this.btnGetAppData_Click);
            // 
            // btnSaveAppData
            // 
            this.btnSaveAppData.Location = new System.Drawing.Point(405, 131);
            this.btnSaveAppData.Name = "btnSaveAppData";
            this.btnSaveAppData.Size = new System.Drawing.Size(50, 48);
            this.btnSaveAppData.TabIndex = 8;
            this.btnSaveAppData.Text = "Save App Data";
            this.btnSaveAppData.UseVisualStyleBackColor = true;
            this.btnSaveAppData.Click += new System.EventHandler(this.btnSaveAppData_Click);
            // 
            // chValid
            // 
            this.chValid.AutoSize = true;
            this.chValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chValid.Location = new System.Drawing.Point(487, 138);
            this.chValid.Name = "chValid";
            this.chValid.Size = new System.Drawing.Size(178, 30);
            this.chValid.TabIndex = 9;
            this.chValid.Text = "Licencia Valida";
            this.chValid.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Licencia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Fecha Instalacion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Ultima Fecha";
            // 
            // txtLastDate
            // 
            this.txtLastDate.Location = new System.Drawing.Point(195, 183);
            this.txtLastDate.Name = "txtLastDate";
            this.txtLastDate.Size = new System.Drawing.Size(204, 20);
            this.txtLastDate.TabIndex = 5;
            // 
            // txtRunTimes
            // 
            this.txtRunTimes.Location = new System.Drawing.Point(195, 209);
            this.txtRunTimes.Name = "txtRunTimes";
            this.txtRunTimes.Size = new System.Drawing.Size(204, 20);
            this.txtRunTimes.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(88, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Arranques";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 571);
            this.Controls.Add(this.chValid);
            this.Controls.Add(this.btnSaveAppData);
            this.Controls.Add(this.btnGetAppData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetLicenced);
            this.Controls.Add(this.txtServerHash);
            this.Controls.Add(this.txtServerGuid);
            this.Controls.Add(this.txtRunTimes);
            this.Controls.Add(this.txtLastDate);
            this.Controls.Add(this.txtInstalationDate);
            this.Controls.Add(this.txtClientHash);
            this.Controls.Add(this.txtLicense);
            this.Controls.Add(this.txtMachineGuid);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtMachineGuid;
        private System.Windows.Forms.TextBox txtClientHash;
        private System.Windows.Forms.TextBox txtServerGuid;
        private System.Windows.Forms.TextBox txtServerHash;
        private System.Windows.Forms.Button btnGetLicenced;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.TextBox txtInstalationDate;
        private System.Windows.Forms.Button btnGetAppData;
        private System.Windows.Forms.Button btnSaveAppData;
        private System.Windows.Forms.CheckBox chValid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLastDate;
        private System.Windows.Forms.TextBox txtRunTimes;
        private System.Windows.Forms.Label label8;
    }
}