using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Zoomaster {
    class AddLesson : TemplateLesson {
        public static int run(String nameInput, String dayInput, String startTimeHoursInput, String startTimeMinsInput,
                String endTimeHoursInput, String endTimeMinsInput, String linkInput, LessonList listLesson) {
            String startTimeInput = formatTime(startTimeHoursInput, startTimeMinsInput);
            String endTimeInput = formatTime(endTimeHoursInput, endTimeMinsInput);

            if (nameInput == "" || dayInput == "" || linkInput == "" 
                || startTimeInput == null || endTimeInput == null 
                || isVaidPeriod(startTimeInput, endTimeInput, dayInput, listLesson, 1, -1) == false
                || Lesson.stringIsDayOfWeek(dayInput) == false) {
                return 0;
            }

            Lesson newLesson = new Lesson(nameInput, dayInput, startTimeInput, endTimeInput, linkInput, new System.Collections.ArrayList());
            listLesson[listLesson.noLessons] = newLesson;
            
            return 1;
        }
    }
}
