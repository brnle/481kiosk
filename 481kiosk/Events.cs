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
        private string address;
        private string hoursOfOperation;


        public Events(string name, string desc, string img, string addr, string hours)
        {
            eventName = name;
            eventDescription = desc;
            image = img;
            address = addr;
            hoursOfOperation = hours;
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
        
        public string getAddress()
        {
            return address;
        }

        public string getHours()
        {
            return hoursOfOperation;
        }
    }


}
