using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoomaster {
    class LinkLesson : TemplateLesson {
        public static int run(String linkInput, LessonList listLesson, int index, int setting) {
            if (linkInput == "" || setting > 2 || setting < 1) {
                return 0;
            }
            
            if (setting == 1) {
                listLesson[index].addLink(linkInput);
            } else if (setting == 2) {
                listLesson[index].removeLink(linkInput);
            }
            

            return 1;
        }
    }
}
