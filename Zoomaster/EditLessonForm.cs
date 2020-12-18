using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Diagnostics;

namespace Zoomaster
{
    public partial class EditLessonForm : Form
    {
        public static string pathRoot = System.IO.Directory.GetCurrentDirectory();
        public static string pathResource = Path.GetFullPath(Path.Combine(pathRoot, @"..\..\..\")) + "Resources";
        public static string pathData = Path.GetFullPath(Path.Combine(pathRoot, @"..\..\..\")) + @"Data\data.txt";

        LessonList listLesson;
        int lessonSelectedIndex;

        public EditLessonForm(int index)
        {
            InitializeComponent();
            Debug.Assert(index != -1, "Assumption of index of LessonList is valid was broken.");
            lessonSelectedIndex = index;
            listLesson = new LessonList(new List<Lesson>());
            Storage.loadFromFile(pathData, listLesson);
            setTextBoxes(listLesson[index]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nameInput = textBox1.Text;
            String dayInput = comboBox1.Text;
            String startTimeHoursInput = start1.Text;
            String startTimeMinsInput = start2.Text;
            String endTimeHoursInput = end1.Text;
            String endTimeMinsInput = end2.Text;
            String linkInput = textBox2.Text;
            int status = EditLesson.run(nameInput, dayInput, startTimeHoursInput, startTimeMinsInput,
                endTimeHoursInput, endTimeMinsInput, linkInput, listLesson, lessonSelectedIndex);

            listLesson = Storage.sortedLessons(listLesson);
            Storage.saveToFile(pathData, listLesson);


            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }
        
        private void setTextBoxes(Lesson selectedLesson) {
            textBox1.Text = selectedLesson.getName();
            comboBox1.Text = selectedLesson.getDay();
            textBox2.Text = selectedLesson.getLessonLink();
            start1.Text = selectedLesson.getStartTime().Substring(0, 2);
            start2.Text = selectedLesson.getStartTime().Substring(2, 2);
            end1.Text = selectedLesson.getEndTime().Substring(0, 2);
            end2.Text = selectedLesson.getEndTime().Substring(2, 2);
        }
    }
}
