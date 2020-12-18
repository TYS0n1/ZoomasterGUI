using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Diagnostics;


namespace Zoomaster {
    class Storage {
        private static String seperator = "   ";
        private static String endChar = "/e";

        public static void saveToFile(String path, LessonList listLesson) {
            File.Delete(path);

            StreamWriter sw = File.CreateText(path);

            for(int i = 0; i < listLesson.noLessons; i++) {
                sw.WriteLine(listLesson[i].toString());
            }

            sw.Close();
        }

        public static void loadFromFile(String path, LessonList listLesson) {
            StreamReader sr = File.OpenText(path);

            String line;
            int i = 0;

            while ((line = sr.ReadLine()) != null) {
                listLesson[i] = decodeLine(line);
                i++;
            }

            sr.Close();
        }

        public static void reloadFromFile(String path, LessonList listLesson) {
            StreamReader sr = File.OpenText(path);

            String line;
            int i = 0;

            while ((line = sr.ReadLine()) != null) {
                listLesson.replace(decodeLine(line), i);
                i++;
            }

            sr.Close();
        }

        public static Lesson decodeLine(String line) {
            String name;
            String day;
            String startTime;
            String endTime;
            String lessonLink;
            ArrayList otherLinks = new ArrayList();
            Lesson newLesson;

            int seperatorIndex = 0;
            int noOtherLink = 0;

            Debug.Assert(line != "", "No name field of lesson from data");
            seperatorIndex = line.IndexOf(seperator);
            name = line.Substring(0, seperatorIndex);
            line = line.Replace(name + seperator, "");

            Debug.Assert(line != "", "No day field of lesson from data");
            seperatorIndex = line.IndexOf(seperator);
            day = line.Substring(0, seperatorIndex);
            Debug.Assert(day == "Monday" || day == "Tuesday"
                || day == "Wednesday" || day == "Thursday"
                || day == "Friday" || day == "Saturday"
                || day == "Sunday", "Corrupted day field of lesson from data");
            line = line.Replace(day + seperator, "");

            Debug.Assert(line != "", "No start time field of lesson from data");
            seperatorIndex = line.IndexOf(seperator);
            startTime = line.Substring(0, seperatorIndex);
            line = line.Replace(startTime + seperator, "");

            Debug.Assert(line != "", "No end time field of lesson from data");
            seperatorIndex = line.IndexOf(seperator);
            endTime = line.Substring(0, seperatorIndex);
            line = line.Replace(endTime + seperator, "");

            Debug.Assert(line != "", "No link field of lesson from data");
            seperatorIndex = line.IndexOf(seperator);
            lessonLink = line.Substring(0, seperatorIndex);
            line = line.Replace(lessonLink + seperator, "");

            while (line != endChar) {
                seperatorIndex = line.IndexOf(seperator);
                otherLinks.Add(line.Substring(0, seperatorIndex));
                line = line.Replace(otherLinks[noOtherLink] + seperator, "");
                noOtherLink++;
            }

            newLesson = new Lesson(name, day, startTime, endTime, lessonLink, otherLinks);

            return newLesson;
        }

        public static LessonList sortedLessons(LessonList listLesson) {
            Debug.Assert(listLesson.noLessons > 0, "Cannot sort empty list.");

            LessonList newListLesson = new LessonList(new List<Lesson>());
            int count = 0;
            int index;
            int noLessons = listLesson.noLessons;

            while (noLessons > 1) {
                index = 0;

                for (int i = 1; i <= noLessons - 1; i++) {

                    if (listLesson[i].isBefore(listLesson[index])) {
                        index = i;
                    }
                }

                newListLesson[count] = listLesson[index];
                count++;
                if (index != noLessons - 1) {
                    listLesson.replace(listLesson[noLessons - 1], index);
                }

                noLessons--;
            }

            newListLesson[count] = listLesson[0];

            return newListLesson;
        }
    }
}
