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
    public partial class AddLessonForm : Form
    {
        public static string pathRoot = System.IO.Directory.GetCurrentDirectory();
        public static string pathResource = Path.GetFullPath(Path.Combine(pathRoot, @"..\..\..\")) + "Resources";
        public static string pathData = Path.GetFullPath(Path.Combine(pathRoot, @"..\..\..\")) + @"Data\data.txt";
        public static String soundPath1 = pathResource + @"\ding.wav";
        public static String soundPath2 = pathResource + @"\wrong buzzer.wav";

        LessonList listLesson;

        public AddLessonForm()
        {
            InitializeComponent();
            listLesson = new LessonList(new List<Lesson>());
            Storage.loadFromFile(pathData, listLesson);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String soundPath;

            String nameInput = textBox1.Text;
            String dayInput = comboBox1.Text;
            String startTimeHoursInput = start1.Text;
            String startTimeMinsInput = start2.Text;
            String endTimeHoursInput = end1.Text;
            String endTimeMinsInput = end2.Text;
            String linkInput = textBox2.Text;
            int status = AddLesson.run(nameInput, dayInput, startTimeHoursInput, startTimeMinsInput,
                endTimeHoursInput, endTimeMinsInput, linkInput, listLesson);

            listLesson = Storage.sortedLessons(listLesson);
            Storage.saveToFile(pathData, listLesson);

            if (status == 0) {
                soundPath = soundPath2;
            } else {
                soundPath = soundPath1;
            }

            SoundPlayer player = new SoundPlayer(soundPath);
            player.Load();
            player.Play();

            resetTextBoxes();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void resetTextBoxes() {
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox2.Text = "";
            start1.Text = "";
            start2.Text = "";
            end1.Text = "";
            end2.Text = "";
        }

        
    }
}
