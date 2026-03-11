namespace TestingApp
{
    partial class FormFinish
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTimeInfo;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblResult = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTimeInfo = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblHistory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblResult.Location = new System.Drawing.Point(50, 30);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(132, 26);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Результат:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblName.Location = new System.Drawing.Point(50, 70);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Имя: ...";
            // 
            // lblTimeInfo
            // 
            this.lblTimeInfo.AutoSize = true;
            this.lblTimeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTimeInfo.Location = new System.Drawing.Point(50, 110);
            this.lblTimeInfo.Name = "lblTimeInfo";
            this.lblTimeInfo.Size = new System.Drawing.Size(90, 17);
            this.lblTimeInfo.TabIndex = 2;
            this.lblTimeInfo.Text = "Время: ... - ...";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(50, 170);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.Size = new System.Drawing.Size(500, 150);
            this.dgvHistory.TabIndex = 3;
            // 
            // btnRestart
            // 
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRestart.Location = new System.Drawing.Point(100, 350);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(150, 40);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "Пройти заново";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExit.Location = new System.Drawing.Point(300, 350);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 40);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblHistory.Location = new System.Drawing.Point(50, 150);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(147, 17);
            this.lblHistory.TabIndex = 6;
            this.lblHistory.Text = "История прохождений:";
            // 
            // FormFinish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.lblTimeInfo);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblResult);
            this.Name = "FormFinish";
            this.Text = "Результаты";
            this.Load += new System.EventHandler(this.FormFinish_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}