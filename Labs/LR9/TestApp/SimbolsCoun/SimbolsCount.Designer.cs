namespace FilesApp
{
    partial class SimbolsCount
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnCountUp;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;

        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtPath;

        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.Label lblInfo2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnCountUp = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();

            this.txtText = new System.Windows.Forms.TextBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();

            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();

            // txtText
            this.txtText.Multiline = true;
            this.txtText.SetBounds(20, 60, 400, 150);

            // txtPath
            this.txtPath.SetBounds(20, 30, 400, 20);

            // txtCount
            this.txtCount.SetBounds(20, 240, 150, 20);

            // Labels
            this.lblInfo1.Text = "Введите текст или выберите файл";
            this.lblInfo1.SetBounds(20, 10, 300, 20);

            this.lblInfo2.Text = "Количество символов";
            this.lblInfo2.SetBounds(20, 220, 200, 20);

            // Buttons
            this.btnOpen.Text = "Открыть";
            this.btnOpen.SetBounds(450, 30, 100, 30);
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);

            this.btnCountUp.Text = "Подсчитать";
            this.btnCountUp.SetBounds(450, 70, 100, 30);
            this.btnCountUp.Click += new System.EventHandler(this.btnCountUp_Click);

            this.btnSave.Text = "Сохранить";
            this.btnSave.SetBounds(450, 110, 100, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnClear.Text = "Очистить";
            this.btnClear.SetBounds(450, 150, 100, 30);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.btnExit.Text = "Выход";
            this.btnExit.SetBounds(450, 190, 100, 30);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(580, 300);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtCount);

            this.Controls.Add(this.lblInfo1);
            this.Controls.Add(this.lblInfo2);

            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnCountUp);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);

            this.Text = "Подсчет символов";
        }
    }
}