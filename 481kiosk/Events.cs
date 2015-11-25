using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _481kiosk
{

    public class Events
    {
        private string eventName;
        private string eventDescription;
        private string image;


        public Events(string name, string desc, string img)
        {
            eventName = name;
            eventDescription = desc;
            image = img;
        }

        public string getName()
        {
            return eventName;
        }
        
        public string getDescription()
        {
            return eventDescription;
        }

        public string getImg()
        {
            return image;
        }
    }


}
