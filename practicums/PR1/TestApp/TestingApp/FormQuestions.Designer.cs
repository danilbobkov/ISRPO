namespace TestingApp
{
    partial class FormQuestions
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.RadioButton rbOption1;
        private System.Windows.Forms.RadioButton rbOption2;
        private System.Windows.Forms.RadioButton rbOption3;
        private System.Windows.Forms.RadioButton rbOption4;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblQuestionNumber;

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
            this.components = new System.ComponentModel.Container();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.rbOption1 = new System.Windows.Forms.RadioButton();
            this.rbOption2 = new System.Windows.Forms.RadioButton();
            this.rbOption3 = new System.Windows.Forms.RadioButton();
            this.rbOption4 = new System.Windows.Forms.RadioButton();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblQuestionNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblQuestion.Location = new System.Drawing.Point(50, 50);
            this.lblQuestion.MaximumSize = new System.Drawing.Size(500, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(81, 24);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Вопрос:";
            // 
            // rbOption1
            // 
            this.rbOption1.AutoSize = true;
            this.rbOption1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbOption1.Location = new System.Drawing.Point(70, 120);
            this.rbOption1.Name = "rbOption1";
            this.rbOption1.Size = new System.Drawing.Size(101, 24);
            this.rbOption1.TabIndex = 1;
            this.rbOption1.TabStop = true;
            this.rbOption1.Text = "Вариант1";
            this.rbOption1.UseVisualStyleBackColor = true;
            // 
            // rbOption2
            // 
            this.rbOption2.AutoSize = true;
            this.rbOption2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbOption2.Location = new System.Drawing.Point(70, 160);
            this.rbOption2.Name = "rbOption2";
            this.rbOption2.Size = new System.Drawing.Size(101, 24);
            this.rbOption2.TabIndex = 2;
            this.rbOption2.TabStop = true;
            this.rbOption2.Text = "Вариант2";
            this.rbOption2.UseVisualStyleBackColor = true;
            // 
            // rbOption3
            // 
            this.rbOption3.AutoSize = true;
            this.rbOption3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbOption3.Location = new System.Drawing.Point(70, 200);
            this.rbOption3.Name = "rbOption3";
            this.rbOption3.Size = new System.Drawing.Size(101, 24);
            this.rbOption3.TabIndex = 3;
            this.rbOption3.TabStop = true;
            this.rbOption3.Text = "Вариант3";
            this.rbOption3.UseVisualStyleBackColor = true;
            // 
            // rbOption4
            // 
            this.rbOption4.AutoSize = true;
            this.rbOption4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbOption4.Location = new System.Drawing.Point(70, 240);
            this.rbOption4.Name = "rbOption4";
            this.rbOption4.Size = new System.Drawing.Size(101, 24);
            this.rbOption4.TabIndex = 4;
            this.rbOption4.TabStop = true;
            this.rbOption4.Text = "Вариант4";
            this.rbOption4.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnNext.Location = new System.Drawing.Point(200, 300);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(150, 40);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblTimer.Location = new System.Drawing.Point(450, 20);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(143, 24);
            this.lblTimer.TabIndex = 6;
            this.lblTimer.Text = "25:00 осталось";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblQuestionNumber
            // 
            this.lblQuestionNumber.AutoSize = true;
            this.lblQuestionNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblQuestionNumber.Location = new System.Drawing.Point(473, 276);
            this.lblQuestionNumber.Name = "lblQuestionNumber";
            this.lblQuestionNumber.Size = new System.Drawing.Size(120, 20);
            this.lblQuestionNumber.TabIndex = 7;
            this.lblQuestionNumber.Text = "Вопрос 1 из 15";
            // 
            // FormQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.lblQuestionNumber);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.rbOption4);
            this.Controls.Add(this.rbOption3);
            this.Controls.Add(this.rbOption2);
            this.Controls.Add(this.rbOption1);
            this.Controls.Add(this.lblQuestion);
            this.Name = "FormQuestions";
            this.Text = "Тестирование";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormQuestions_FormClosing);
            this.Load += new System.EventHandler(this.FormQuestions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}