namespace ClientApp.View
{
    partial class Main
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
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.lbResult = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.CbbLanguages = new System.Windows.Forms.ComboBox();
            this.lbInput = new System.Windows.Forms.Label();
            this.lbLanguages = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lbConnecting = new System.Windows.Forms.Label();
            this.GbConnect = new System.Windows.Forms.GroupBox();
            this.GbInput = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DgvHistory = new System.Windows.Forms.DataGridView();
            this.GbConnect.SuspendLayout();
            this.GbInput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(115, 117);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(377, 57);
            this.txtResult.TabIndex = 17;
            this.txtResult.Text = "";
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbResult.Location = new System.Drawing.Point(18, 117);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(46, 19);
            this.lbResult.TabIndex = 16;
            this.lbResult.Text = "Result";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(402, 190);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 28);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(115, 29);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(377, 23);
            this.txtInput.TabIndex = 12;
            // 
            // CbbLanguages
            // 
            this.CbbLanguages.FormattingEnabled = true;
            this.CbbLanguages.Location = new System.Drawing.Point(114, 70);
            this.CbbLanguages.Name = "CbbLanguages";
            this.CbbLanguages.Size = new System.Drawing.Size(378, 23);
            this.CbbLanguages.TabIndex = 11;
            // 
            // lbInput
            // 
            this.lbInput.AutoSize = true;
            this.lbInput.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbInput.Location = new System.Drawing.Point(18, 31);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(59, 19);
            this.lbInput.TabIndex = 10;
            this.lbInput.Text = "Number";
            // 
            // lbLanguages
            // 
            this.lbLanguages.AutoSize = true;
            this.lbLanguages.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbLanguages.Location = new System.Drawing.Point(18, 70);
            this.lbLanguages.Name = "lbLanguages";
            this.lbLanguages.Size = new System.Drawing.Size(69, 19);
            this.lbLanguages.TabIndex = 9;
            this.lbLanguages.Text = "Language";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "IP Address";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(10, 40);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(140, 23);
            this.txtIpAddress.TabIndex = 19;
            this.txtIpAddress.Text = "127.0.0.1";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbPort.Location = new System.Drawing.Point(6, 74);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(34, 19);
            this.lbPort.TabIndex = 20;
            this.lbPort.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(10, 97);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(140, 23);
            this.txtPort.TabIndex = 21;
            this.txtPort.Text = "8000";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(11, 188);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(144, 30);
            this.btnConnect.TabIndex = 22;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lbConnecting
            // 
            this.lbConnecting.BackColor = System.Drawing.Color.IndianRed;
            this.lbConnecting.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lbConnecting.ForeColor = System.Drawing.Color.White;
            this.lbConnecting.Location = new System.Drawing.Point(10, 144);
            this.lbConnecting.Name = "lbConnecting";
            this.lbConnecting.Size = new System.Drawing.Size(140, 30);
            this.lbConnecting.TabIndex = 23;
            this.lbConnecting.Text = "Idle";
            this.lbConnecting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GbConnect
            // 
            this.GbConnect.Controls.Add(this.label1);
            this.GbConnect.Controls.Add(this.btnConnect);
            this.GbConnect.Controls.Add(this.lbConnecting);
            this.GbConnect.Controls.Add(this.txtIpAddress);
            this.GbConnect.Controls.Add(this.lbPort);
            this.GbConnect.Controls.Add(this.txtPort);
            this.GbConnect.Location = new System.Drawing.Point(516, 11);
            this.GbConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbConnect.Name = "GbConnect";
            this.GbConnect.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbConnect.Size = new System.Drawing.Size(161, 240);
            this.GbConnect.TabIndex = 24;
            this.GbConnect.TabStop = false;
            this.GbConnect.Text = "Connect";
            // 
            // GbInput
            // 
            this.GbInput.Controls.Add(this.lbLanguages);
            this.GbInput.Controls.Add(this.CbbLanguages);
            this.GbInput.Controls.Add(this.txtResult);
            this.GbInput.Controls.Add(this.lbInput);
            this.GbInput.Controls.Add(this.btnSend);
            this.GbInput.Controls.Add(this.lbResult);
            this.GbInput.Controls.Add(this.txtInput);
            this.GbInput.Location = new System.Drawing.Point(12, 11);
            this.GbInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbInput.Name = "GbInput";
            this.GbInput.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbInput.Size = new System.Drawing.Size(498, 240);
            this.GbInput.TabIndex = 25;
            this.GbInput.TabStop = false;
            this.GbInput.Text = "Input";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DgvHistory);
            this.groupBox1.Location = new System.Drawing.Point(12, 279);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 245);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Requests";
            // 
            // DgvHistory
            // 
            this.DgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHistory.Location = new System.Drawing.Point(6, 22);
            this.DgvHistory.Name = "DgvHistory";
            this.DgvHistory.RowTemplate.Height = 25;
            this.DgvHistory.Size = new System.Drawing.Size(653, 217);
            this.DgvHistory.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 536);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GbInput);
            this.Controls.Add(this.GbConnect);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main";
            this.Text = "Client";
            this.GbConnect.ResumeLayout(false);
            this.GbConnect.PerformLayout();
            this.GbInput.ResumeLayout(false);
            this.GbInput.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.ComboBox CbbLanguages;
        private System.Windows.Forms.Label lbInput;
        private System.Windows.Forms.Label lbLanguages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lbConnecting;
        private System.Windows.Forms.GroupBox GbConnect;
        private System.Windows.Forms.GroupBox GbInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DgvHistory;
    }
}