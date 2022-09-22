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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lbResult = new System.Windows.Forms.Label();
            this.lbHistory = new System.Windows.Forms.Label();
            this.DgvHistory = new System.Windows.Forms.DataGridView();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.CbbLanguages = new System.Windows.Forms.ComboBox();
            this.lbInput = new System.Windows.Forms.Label();
            this.lbLanguages = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(295, 195);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(297, 75);
            this.richTextBox1.TabIndex = 17;
            this.richTextBox1.Text = "";
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbResult.Location = new System.Drawing.Point(96, 210);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(64, 28);
            this.lbResult.TabIndex = 16;
            this.lbResult.Text = "Result";
            // 
            // lbHistory
            // 
            this.lbHistory.AutoSize = true;
            this.lbHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbHistory.Location = new System.Drawing.Point(96, 327);
            this.lbHistory.Name = "lbHistory";
            this.lbHistory.Size = new System.Drawing.Size(75, 28);
            this.lbHistory.TabIndex = 15;
            this.lbHistory.Text = "History";
            // 
            // DgvHistory
            // 
            this.DgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHistory.Location = new System.Drawing.Point(96, 379);
            this.DgvHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgvHistory.Name = "DgvHistory";
            this.DgvHistory.RowHeadersWidth = 51;
            this.DgvHistory.RowTemplate.Height = 29;
            this.DgvHistory.Size = new System.Drawing.Size(496, 281);
            this.DgvHistory.TabIndex = 14;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(489, 291);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(103, 38);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(295, 131);
            this.txtInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(297, 27);
            this.txtInput.TabIndex = 12;
            // 
            // CbbLanguages
            // 
            this.CbbLanguages.FormattingEnabled = true;
            this.CbbLanguages.Location = new System.Drawing.Point(295, 52);
            this.CbbLanguages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CbbLanguages.Name = "CbbLanguages";
            this.CbbLanguages.Size = new System.Drawing.Size(297, 28);
            this.CbbLanguages.TabIndex = 11;
            // 
            // lbInput
            // 
            this.lbInput.AutoSize = true;
            this.lbInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbInput.Location = new System.Drawing.Point(96, 127);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(135, 28);
            this.lbInput.TabIndex = 10;
            this.lbInput.Text = "Input Number";
            // 
            // lbLanguages
            // 
            this.lbLanguages.AutoSize = true;
            this.lbLanguages.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbLanguages.Location = new System.Drawing.Point(96, 52);
            this.lbLanguages.Name = "lbLanguages";
            this.lbLanguages.Size = new System.Drawing.Size(158, 28);
            this.lbLanguages.TabIndex = 9;
            this.lbLanguages.Text = "Select Language:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 714);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.lbHistory);
            this.Controls.Add(this.DgvHistory);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.CbbLanguages);
            this.Controls.Add(this.lbInput);
            this.Controls.Add(this.lbLanguages);
            this.Name = "Main";
            this.Text = "Client";
            ((System.ComponentModel.ISupportInitialize)(this.DgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Label lbHistory;
        private System.Windows.Forms.DataGridView DgvHistory;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.ComboBox CbbLanguages;
        private System.Windows.Forms.Label lbInput;
        private System.Windows.Forms.Label lbLanguages;
    }
}