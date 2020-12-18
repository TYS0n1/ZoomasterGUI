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

namespace Zoomaster {
    public partial class MainMenuForm : Form {
        public static string pathRoot = System.IO.Directory.GetCurrentDirectory();
        public static string pathResource = Path.GetFullPath(Path.Combine(pathRoot, @"..\..\..\")) + "Resources";
        public static string pathData = Path.GetFullPath(Path.Combine(pathRoot, @"..\..\..\")) + @"Data\data.txt";

        public MainMenuForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            AddLessonForm newForm = new AddLessonForm();
            newForm.ShowDialog();
        }

        private void launch_Click(object sender, EventArgs e) {
            SettingLessonForm newForm = new SettingLessonForm();
            newForm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e) {
            LaunchLessonForm newForm = new LaunchLessonForm();
            newForm.ShowDialog();
        }
    }
}
