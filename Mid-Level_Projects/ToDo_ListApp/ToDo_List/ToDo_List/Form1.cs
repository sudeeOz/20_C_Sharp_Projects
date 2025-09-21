using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo_List
{
    public partial class Form1 : Form
    {
        List<Task> tasks = new List<Task>();
        public Form1()
        {
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task newTask = new Task
            {
                Title = textBox1.Text,
                DueTime = dateTimePicker1.Value,
                IsCompleted = false,
            };
            tasks.Add(newTask);
            checkedListBox1.Items.Add(newTask, false);

            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem is Task selectedTask)
            {
                tasks.Remove(selectedTask);
                checkedListBox1.Items.Remove(selectedTask);
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir görev seçiniz!");
            }
        }


        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Task selectedTask = (Task)checkedListBox1.Items[e.Index];

            if (e.NewValue == CheckState.Checked)
                selectedTask.IsCompleted = true;
            else
                selectedTask.IsCompleted = false;

            checkedListBox1.Items[e.Index] = selectedTask;
        }
    }
    public class Task
    {
        public string Title { get; set; }
        public DateTime DueTime { get; set; }
        public bool IsCompleted { get; set; }
        
        public override string ToString()
        {
            return $"{Title} - Tarih: {DueTime.ToShortTimeString()} - : {(IsCompleted ? "Tamamlandı" : "Beklemede" )}";
        }
    } 
}
