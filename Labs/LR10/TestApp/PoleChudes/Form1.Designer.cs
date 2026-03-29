namespace PoleChudes
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.FlowLayoutPanel flowLetters;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.flowLetters = new System.Windows.Forms.FlowLayoutPanel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // btnNewGame
            this.btnNewGame.Location = new System.Drawing.Point(12, 12);
            this.btnNewGame.Size = new System.Drawing.Size(100, 30);
            this.btnNewGame.Text = "Новая игра";
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);

            // btnUndo
            this.btnUndo.Location = new System.Drawing.Point(120, 12);
            this.btnUndo.Size = new System.Drawing.Size(100, 30);
            this.btnUndo.Text = "Отмена";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);

            // btnCheck
            this.btnCheck.Location = new System.Drawing.Point(230, 12);
            this.btnCheck.Size = new System.Drawing.Size(100, 30);
            this.btnCheck.Text = "Проверить";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);

            // flowLetters
            this.flowLetters.Location = new System.Drawing.Point(12, 60);
            this.flowLetters.Size = new System.Drawing.Size(320, 150);

            // txtResult
            this.txtResult.Location = new System.Drawing.Point(12, 220);
            this.txtResult.Size = new System.Drawing.Size(320, 23);

            // lblInfo
            this.lblInfo.Location = new System.Drawing.Point(12, 250);
            this.lblInfo.Size = new System.Drawing.Size(300, 23);

            // Form1
            this.ClientSize = new System.Drawing.Size(350, 300);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.flowLetters);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblInfo);
            this.Text = "Поле чудес";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}