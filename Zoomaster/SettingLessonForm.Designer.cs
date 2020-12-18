namespace Zoomaster {
    partial class SettingLessonForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Monday", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Tuesday", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Wednesday", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Thursday", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Friday", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Saturday", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Sunday", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingLessonForm));
            this.LessonListView = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.SelectedLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.LinkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LessonListView
            // 
            this.LessonListView.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.LessonListView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.LessonListView.AutoArrange = false;
            this.LessonListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
            this.LessonListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.LessonListView.FullRowSelect = true;
            listViewGroup1.Header = "Monday";
            listViewGroup1.Name = "Monday";
            listViewGroup2.Header = "Tuesday";
            listViewGroup2.Name = "Tuesday";
            listViewGroup3.Header = "Wednesday";
            listViewGroup3.Name = "Wednesday";
            listViewGroup4.Header = "Thursday";
            listViewGroup4.Name = "Thursday";
            listViewGroup5.Header = "Friday";
            listViewGroup5.Name = "Friday";
            listViewGroup6.Header = "Saturday";
            listViewGroup6.Name = "Saturday";
            listViewGroup7.Header = "Sunday";
            listViewGroup7.Name = "Sunday";
            this.LessonListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7});
            this.LessonListView.HideSelection = false;
            this.LessonListView.Location = new System.Drawing.Point(13, 18);
            this.LessonListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LessonListView.MultiSelect = false;
            this.LessonListView.Name = "LessonListView";
            this.LessonListView.Size = new System.Drawing.Size(1036, 470);
            this.LessonListView.TabIndex = 0;
            this.LessonListView.UseCompatibleStateImageBehavior = false;
            this.LessonListView.View = System.Windows.Forms.View.List;
            this.LessonListView.ItemActivate += new System.EventHandler(this.Item_Activated);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = -2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(836, 600);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 69);
            this.button1.TabIndex = 4;
            this.button1.Text = "Return to main menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectedLabel
            // 
            this.SelectedLabel.AutoSize = true;
            this.SelectedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectedLabel.Location = new System.Drawing.Point(16, 493);
            this.SelectedLabel.MaximumSize = new System.Drawing.Size(1036, 88);
            this.SelectedLabel.MinimumSize = new System.Drawing.Size(1036, 88);
            this.SelectedLabel.Name = "SelectedLabel";
            this.SelectedLabel.Size = new System.Drawing.Size(1036, 88);
            this.SelectedLabel.TabIndex = 2;
            this.SelectedLabel.Text = "Selected Item: ";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(16, 600);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(216, 69);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Delete item";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(238, 600);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(216, 69);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Edit item";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // LinkButton
            // 
            this.LinkButton.Location = new System.Drawing.Point(460, 600);
            this.LinkButton.Name = "LinkButton";
            this.LinkButton.Size = new System.Drawing.Size(216, 69);
            this.LinkButton.TabIndex = 3;
            this.LinkButton.Text = "Edit links";
            this.LinkButton.UseVisualStyleBackColor = true;
            this.LinkButton.Click += new System.EventHandler(this.LinkButton_Click);
            // 
            // LaunchLessonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 692);
            this.Controls.Add(this.LinkButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SelectedLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LessonListView);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1083, 731);
            this.MinimumSize = new System.Drawing.Size(1083, 731);
            this.Name = "LaunchLessonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LaunchLessonForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LessonListView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label SelectedLabel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button LinkButton;
    }
}