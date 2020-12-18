using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Zoomaster {
    abstract class TemplateLesson {
        public static String formatTime(String hours, String mins) {
            if (!isAllDigits(hours) || !isAllDigits(mins)) {
                return null;
            }

            Debug.Assert(hours != null || mins != null, "String is asummed to be not empty.");

            if (isStandardTimeFormat(hours, mins) == false) {
                return null;
            }

            if (hours.Length == 1) {
                hours = "0" + hours;
            }

            if (mins.Length == 1) {
                mins = "0" + mins;
            }

            return hours + mins;
        }

        public static bool isAllDigits(string s) {
            if (s.Length == 0) {
                return false;
            }

            foreach (char c in s) {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public static bool isStandardTimeFormat(String hours, String mins) {
            int hoursNum = int.Parse(hours);
            int minsNum = int.Parse(mins);

            if (hoursNum > 24 || hoursNum < 0) {
                return false;
            }

            if (minsNum > 59 || minsNum < 0) {
                return false;
            }

            return true;
        }

        public static bool isVaidPeriod(String startTime, String endTime, String day, LessonList listLesson) {
            if (String.Compare(startTime, endTime, StringComparison.OrdinalIgnoreCase) > 0) {
                return false;
            }

            int stringCompare1;
            int stringCompare2;
            int stringCompare3;
            int stringCompare4;


            for (int i = 0; i < listLesson.noLessons; i++) {
                if (listLesson[i].getDay() != day) {
                    continue;
                }

                stringCompare1 = String.Compare(endTime, listLesson[i].getStartTime(), StringComparison.OrdinalIgnoreCase);
                stringCompare2 = String.Compare(endTime, listLesson[i].getEndTime(), StringComparison.OrdinalIgnoreCase);
                stringCompare3 = String.Compare(listLesson[i].getEndTime(), startTime, StringComparison.OrdinalIgnoreCase);
                stringCompare4 = String.Compare(listLesson[i].getEndTime(), endTime, StringComparison.OrdinalIgnoreCase);

                if ((stringCompare1 <= 0 && stringCompare2 < 0) ||(stringCompare3 <= 0 & stringCompare4 < 0)) {
                    continue;
                }

                return false;
            }

            return true;
        }

    }
}
