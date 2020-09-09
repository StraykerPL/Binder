﻿using Binder.Storages;
using Binder.Tasks;
using System;
using System.Windows.Forms;

namespace Binder.UI
{
    /// <summary>
    /// IFormManager class for to prepare TaskForm for user.
    /// </summary>
    public class TaskFormManager : IFormManager
    {
        /// <summary>
        /// ITask object for loading and saving tasks.
        /// </summary>
        public ITask Task { get; set; }
        /// <summary>
        /// IStorage object for loading and saving data to storage area.
        /// </summary>
        public IStorage Strgm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TaskForm Form { get; }
        private readonly bool IfEdit;

        /// <summary>
        /// Constructor for TaskFormManager class.
        /// </summary>
        public TaskFormManager(TaskForm form, ITask task, bool editMode)
        {
            Form = form;
            Task = task;
            IfEdit = editMode;
            // There's no need in setting IStorage object, this form will not use it,
        }

        /// <summary>
        /// Closes dialog and returns to calling instruction.
        /// </summary>
        /// <returns>Always true.</returns>
        public bool CloseForm() => throw new NotSupportedException("This form manager is not using this method.");

        /// <summary>
        /// Prepares text label for user.
        /// </summary>
        public bool LoadForm()
        {
            if (IfEdit)
            {
                Form.NameTextBox.Text = Task.Name;
                Form.DateTimePicker.Value = Task.Date;
                Form.IfTodayBox.CheckState = Task.IfToday;
            }

            return true;
        }

        /// <summary>
        /// Method to handle data travel out of form.
        /// </summary>
        public bool OKButtonPressed()
        {
            if (Form.NameTextBox.Text == null || Form.NameTextBox.Text == "")
            {
                MessageBox.Show("Add the name to the task!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form.DialogResult = DialogResult.Cancel;
                return false;
            }

            Task.Name = Form.NameTextBox.Text;
            Task.Date = Form.DateTimePicker.Value;
            Task.IfToday = Form.IfTodayBox.CheckState;
            Form.Close();

            return true;
        }
    }
}
