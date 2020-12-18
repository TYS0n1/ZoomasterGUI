using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoomaster {
    class LessonList : IEnumerable {
        private List<Lesson> listLesson = new List<Lesson>();
        public int noLessons = 0;

        public LessonList(List<Lesson> listLesson) {
            this.listLesson = listLesson;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return listLesson.GetEnumerator();
        }

        public Lesson this[int index] {
            get {
                return (Lesson)listLesson[index];
            }

            set {
                listLesson.Insert(index, value);
                noLessons++;
            }
        }

        public void replace(Lesson newLesson, int index) {
            if (index < noLessons) {
                listLesson.RemoveAt(index);
                listLesson.Insert(index, newLesson);
            }
            
        }

        public void delete(int index) {
            if (index < noLessons) {
                listLesson.RemoveAt(index);
                noLessons--;
            }
        }
    }
}
