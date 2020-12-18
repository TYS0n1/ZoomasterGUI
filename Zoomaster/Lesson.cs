using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Zoomaster {
    class Lesson {
        private String name;
        private String day;
        private String startTime;
        private String endTime;
        private String lessonLink;
        private ArrayList otherLinks;
        private String seperator = "   ";
        private String endChar = "/e";

        public Lesson(String nameInput, String dayInput, String startTimeInput, String endTimeInput,
            String lessonLinkInput, ArrayList otherLinksInput) {
            name = nameInput;
            day = dayInput;
            startTime = startTimeInput;
            endTime = endTimeInput;
            lessonLink = lessonLinkInput;
            otherLinks = otherLinksInput;
        }

        public String getName() {
            return name;
        }

        public void setName(String nameInput) {
            name = nameInput;
        }

        public String getDay() {
            return day;
        }

        public String getStartTime() {
            return startTime;
        }

        public String getEndTime() {
            return endTime;
        }

        public String getLessonLink() {
            return lessonLink;
        }

        public ArrayList getOtherLinks() {
            return otherLinks;
        }

        public void setLessonLink(String lessonLinkInput) {
            lessonLink = lessonLinkInput;
        }

        public void addLink(String linkInput) {
            otherLinks.Add(linkInput);
        }

        public void removeLink(String linkInput) {
            otherLinks.Remove(linkInput);
        }

        public String toString() {
            String output = name + seperator + day + seperator + startTime + seperator +
                endTime + seperator + lessonLink + seperator;
            
            for(int i = 0; otherLinks != null && i < otherLinks.Count; i++) {
                output += otherLinks[i] + seperator;
            }

            return output + endChar;
        }

        public String toDisplayString() {
            String displaySeperator = " | ";
            String nameFormat = "Name: " + name;
            String periodFormat = "Lesson timeslot: " + startTime + " - " + endTime;

            return nameFormat + displaySeperator + periodFormat;

        }

        public String toLaunchString() {
            String timeslot = day + " " + startTime + " - " + endTime;

            return name + ": " + timeslot;

        }

        public String toDisplaySelectedString() {
            String displaySeperator1 = " | ";
            String displaySeperator2 = " / ";

            String lessonLinkFormat = "Lesson Link: " + lessonLink;
            String otherLinkFormat = "Other links: ";
            for (int i = 0; i < otherLinks.Count; i++) {
                otherLinkFormat += otherLinks[i];
                if (i + 1 != otherLinks.Count) {
                    otherLinkFormat += displaySeperator2;
                }
            }

            return toDisplayString() + displaySeperator1 + lessonLinkFormat + displaySeperator1 + otherLinkFormat;
        }


        public Boolean isBefore(Lesson lessonCmp) {
            if(dateWeightage(day) < dateWeightage(lessonCmp.day)) {
                return true;
            }

            if (dateWeightage(day) == dateWeightage(lessonCmp.day)
                && String.Compare(startTime, lessonCmp.startTime) == -1) {
                return true;
            }

            return false;

        }

        public static int dateWeightage(String day) {
            Debug.Assert(stringIsDayOfWeek(day));

            int returnValue = 0;

            switch (day) {
                case "Monday":
                    returnValue = 1;
                    break;
                case "Tuesday":
                    returnValue = 2;
                    break;
                case "Wednesday":
                    returnValue = 3;
                    break;
                case "Thursday":
                    returnValue = 4;
                    break;
                case "Friday":
                    returnValue = 5;
                    break;
                case "Saturday":
                    returnValue = 6;
                    break;
                case "Sunday":
                    returnValue = 7;
                    break;
                default:
                    break;

            }

            return returnValue;
        }

        public static bool stringIsDayOfWeek(String day) {
            return (day == "Monday" || day == "Tuesday"
                || day == "Wednesday" || day == "Thursday"
                || day == "Friday" || day == "Saturday"
                || day == "Sunday");
        }
    }
}
