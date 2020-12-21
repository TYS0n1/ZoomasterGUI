using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Zoomaster {
    public partial class LaunchLessonForm : Form {
        public static string pathRoot = System.IO.Directory.GetCurrentDirectory();
        public static string pathData = Path.GetFullPath(Path.Combine(pathRoot, @"..\..\..\")) + @"Data\data.txt";

        LessonList listLesson;

        public LaunchLessonForm() {
            InitializeComponent();
            listLesson = new LessonList(new List<Lesson>());
            Storage.loadFromFile(pathData, listLesson);
            setUpComboBox(listLesson);
        }

        private void LaunchNow_Click(object sender, EventArgs e) {
            int index = getCurrentLessonIndex();

            if (index == -1) {
                return;
            }

            launchLesson(index);
        }

        private void LaunchSelected_Click(object sender, EventArgs e) {
            int index = comboBox1.SelectedIndex;
            if (index == -1) {
                resetTextBoxes();
                return;
            }

            launchLesson(index);

            resetTextBoxes();
        }

        private void launchLesson(int index) {
            String link;
            link = listLesson[index].getLessonLink();

            Process.Start("chrome.exe", link);

            for (int i = 0; i < listLesson[index].getOtherLinks().Count; i++) {
                link = listLesson[index].getOtherLinks()[i].ToString();
                Process.Start("chrome.exe", link);
            }
        }

        private void setUpComboBox(LessonList list) {
            comboBox1.Items.Clear();

            for (int i = 0; i < list.noLessons; i++) {
                comboBox1.Items.Add(list[i].toLaunchString());
            }
        }

        private void resetTextBoxes() {
            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private int getCurrentLessonIndex() {
            DateTime timeNow = DateTime.Now;
            String timeNowString = TemplateLesson.formatTime(timeNow.Hour.ToString(), timeNow.Minute.ToString()); 
            int selectedIndex = -1;
            int errorCatcher = 0;

            for (int i = 0; i < listLesson.noLessons; i++) {
                if (listLesson[i].getDay() != timeNow.DayOfWeek.ToString()) {
                    continue;
                }

                if (stringTimeWithinPeriod(timeNowString, listLesson[i].getStartTime(), listLesson[i].getEndTime()) == true) {
                    selectedIndex = i;
                    errorCatcher++;
                }
            }

            Debug.Assert(errorCatcher <= 1, "Overlapping timeslots detected.");

            return selectedIndex;
        }

        private bool stringTimeWithinPeriod(String time, String start, String end) {
            int compareToStart = String.Compare(start, time, StringComparison.OrdinalIgnoreCase);
            int compareToEnd = String.Compare(end, time, StringComparison.OrdinalIgnoreCase);

            if ((compareToStart <= 0) && compareToEnd > 0) {
                return true;
            }
            
            return false;
        }

        private void button3_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
