using System;
using System.Windows.Forms;

namespace DailyPlanner
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ListBox listBoxNotes;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        private void InitializeComponent()
        {
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.listBoxNotes = new System.Windows.Forms.ListBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            this.SuspendLayout();

            this.monthCalendar1.Location = new System.Drawing.Point(10, 10);
            this.monthCalendar1.DateChanged += new DateRangeEventHandler(this.monthCalendar1_DateChanged);

            this.listBoxNotes.Location = new System.Drawing.Point(250, 10);
            this.listBoxNotes.Size = new System.Drawing.Size(300, 200);
            this.listBoxNotes.SelectedIndexChanged += new EventHandler(this.listBoxNotes_SelectedIndexChanged);

            this.txtNote.Location = new System.Drawing.Point(250, 220);
            this.txtNote.Size = new System.Drawing.Size(300, 23);

            this.timePicker.Format = DateTimePickerFormat.Time;
            this.timePicker.ShowUpDown = true;
            this.timePicker.Location = new System.Drawing.Point(250, 250);

            this.btnAdd.Text = "Добавить";
            this.btnAdd.Location = new System.Drawing.Point(250, 280);
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            this.btnEdit.Text = "Редактировать";
            this.btnEdit.Location = new System.Drawing.Point(350, 280);
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);

            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new System.Drawing.Point(480, 280);
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            this.ClientSize = new System.Drawing.Size(600, 330);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.listBoxNotes);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);

            this.Text = "Заметки";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}