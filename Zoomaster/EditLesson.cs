using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Zoomaster {
    class EditLesson : TemplateLesson {
        public static int run(String nameInput, String dayInput, String startTimeHoursInput, String startTimeMinsInput,
                String endTimeHoursInput, String endTimeMinsInput, String linkInput, LessonList listLesson, int index) {
            String startTimeInput = formatTime(startTimeHoursInput, startTimeMinsInput);
            String endTimeInput = formatTime(endTimeHoursInput, endTimeMinsInput);

            if (nameInput == "" || dayInput == "" || linkInput == ""
                || startTimeInput == null || endTimeInput == null
                || isVaidPeriod(startTimeInput, endTimeInput, dayInput, listLesson) == false) {
                return 0;
            }

            Debug.Assert(Lesson.stringIsDayOfWeek(dayInput));

            Lesson newLesson = new Lesson(nameInput, dayInput, startTimeInput, endTimeInput, linkInput, listLesson[index].getOtherLinks());
            listLesson.replace(newLesson, index);

            return 1;
        }
    }
}
