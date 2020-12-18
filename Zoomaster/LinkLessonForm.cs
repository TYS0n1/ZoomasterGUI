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
    public partial class LinkLessonForm : Form
    {
        public static string pathRoot = System.IO.Directory.GetCurrentDirectory();
        public static string pathResource = Path.GetFullPath(Path.Combine(pathRoot, @"..\..\..\")) + "Resources";
        public static string pathData = Path.GetFullPath(Path.Combine(pathRoot, @"..\..\..\")) + @"Data\data.txt";
        public static String soundPath1 = pathResource + @"\ding.wav";
        public static String soundPath2 = pathResource + @"\wrong buzzer.wav";

        LessonList listLesson;
        int lessonSelectedIndex;

        public LinkLessonForm(int index)
        {
            InitializeComponent();
            Debug.Assert(index != -1, "Assumption of index of LessonList is valid was broken.");
            lessonSelectedIndex = index;
            listLesson = new LessonList(new List<Lesson>());
            Storage.loadFromFile(pathData, listLesson);
            textBox1.Text = listLesson[index].getName();
            setUpComboBox(listLesson[index]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String soundPath;
            
            String linkInput = textBox2.Text;
            int status = LinkLesson.run(linkInput, listLesson, lessonSelectedIndex, 1);

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
            textBox2.Text = "";
            comboBox1.Text = "";
            setUpComboBox(listLesson[lessonSelectedIndex]);
        }

        private void DeleteButton_Click(object sender, EventArgs e) {
            String soundPath;

            String linkInput = comboBox1.Text;
            int status = LinkLesson.run(linkInput, listLesson, lessonSelectedIndex , 2);
            
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

        private void setUpComboBox(Lesson lesson) {
            comboBox1.Items.Clear();

            for (int i = 0; i < lesson.getOtherLinks().Count; i++) {
                comboBox1.Items.Add(lesson.getOtherLinks()[i]);
            }
        }
    }
}
