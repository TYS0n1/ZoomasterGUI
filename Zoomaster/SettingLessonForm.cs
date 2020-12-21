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
    public partial class SettingLessonForm : Form {
        public static string pathRoot = System.IO.Directory.GetCurrentDirectory();
        public static string pathData = Path.GetFullPath(Path.Combine(pathRoot, @"..\..\..\")) + @"Data\data.txt";
        String defaultText = "Selected item: ";

        LessonList listLesson;

        int lessonSelectedIndex = -1;

        public SettingLessonForm() {
            InitializeComponent();
            listLesson = new LessonList(new List<Lesson>());
            Storage.loadFromFile(pathData, listLesson);
            displayLessonList();
        }

        private void displayLessonList() {
            int noLesson = listLesson.noLessons;
            int noItem = noLesson + 7;
            ListViewItem[] listviewItems = new ListViewItem[noItem];
            String[] days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int dayIndex = 0;
            int itemIndex = 0;
            bool donePrintingDays = false;
            
            for (int i = 0; i < noLesson; i++) {
                if (donePrintingDays == false) {
                    while (hasPrintedDate(days[dayIndex], listLesson[i].getDay()) == false) {
                        listviewItems[itemIndex] = new ListViewItem(days[dayIndex], itemIndex);
                        listviewItems[itemIndex].Font = new Font(listviewItems[itemIndex].Font, FontStyle.Bold | FontStyle.Underline);
                        itemIndex++;
                        if (dayIndex < 6) {
                            dayIndex++;
                        } else {
                            donePrintingDays = true;
                            break;
                        }
                    }
                }

                listviewItems[itemIndex] = new ListViewItem(listLesson[i].toDisplayString(), itemIndex);
                itemIndex++;
            }

            if (donePrintingDays == false) {
                while (hasPrintedDate(days[dayIndex], "Sunday") == false) {
                    listviewItems[itemIndex] = new ListViewItem(days[dayIndex], itemIndex);
                    listviewItems[itemIndex].Font = new Font(listviewItems[itemIndex].Font, FontStyle.Bold | FontStyle.Underline);
                    itemIndex++;
                    if (dayIndex < 6) {
                        dayIndex++;
                    } else {
                        break;
                    }
                }
            }

            SelectedLabel.Text = defaultText + "NIL";
            LessonListView.Items.Clear();
            LessonListView.Items.AddRange(listviewItems);
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private bool hasPrintedDate(String day, String itemDate) {
            return !(Lesson.dateWeightage(day) <= Lesson.dateWeightage(itemDate));
        }

        private void Item_Activated(object sender, EventArgs e) {
            ListView.SelectedListViewItemCollection selectedItems =
                this.LessonListView.SelectedItems;

            if (Lesson.stringIsDayOfWeek(selectedItems[0].Text)) {
                lessonSelectedIndex = -1;
                SelectedLabel.Text = defaultText + "NIL";
                return;
            }

            int index = LessonListView.Items.IndexOf(selectedItems[0]);
            lessonSelectedIndex = index - numOfDateIndex(index);

            SelectedLabel.Text = defaultText + "{" + listLesson[lessonSelectedIndex].toDisplaySelectedString() + "}";
        }

        private int numOfDateIndex(int index) {
            int count = 0;
            ListView.ListViewItemCollection items = LessonListView.Items;

            for (int i = 0; i < index; i++) {
                String text = items[i].Text;
                if (Lesson.stringIsDayOfWeek(text)) {
                    count++;
                }
            }

            return count;
        }

        private void DeleteButton_Click(object sender, EventArgs e) {
            if (lessonSelectedIndex == -1) {
                return;
            }

            listLesson.delete(lessonSelectedIndex);
            if (listLesson.noLessons > 0) {
                listLesson = Storage.sortedLessons(listLesson);
            }
            Storage.saveToFile(pathData, listLesson);

            Storage.reloadFromFile(pathData, listLesson);
            displayLessonList();
            lessonSelectedIndex = -1;
        }

        private void EditButton_Click(object sender, EventArgs e) {
            if (lessonSelectedIndex == -1) {
                return;
            }

            EditLessonForm newForm = new EditLessonForm(lessonSelectedIndex);
            newForm.ShowDialog();

            Storage.reloadFromFile(pathData, listLesson);
            displayLessonList();
            lessonSelectedIndex = -1;
        }

        private void LinkButton_Click(object sender, EventArgs e) {
            if (lessonSelectedIndex == -1) {
                return;
            }

            LinkLessonForm newForm = new LinkLessonForm(lessonSelectedIndex);
            newForm.ShowDialog();

            Storage.reloadFromFile(pathData, listLesson);
            displayLessonList();
            lessonSelectedIndex = -1;
        }
    }
}
