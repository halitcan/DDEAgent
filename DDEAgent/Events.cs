﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DDEAgent {
    class Events {
        public static List<Events> list = new List<Events>();
        public string unifiedEvent { get; set; }
        public string foreignEvent { get; set; }

        private Events() {}                   
       
        public static void ListAdd(string attrUnifiedEvent, string attrForeignEvent) {
            list.Add(new Events() { unifiedEvent = attrUnifiedEvent, foreignEvent = attrForeignEvent });
            Console.WriteLine("DataItem added: " + attrUnifiedEvent + "<->" + attrForeignEvent);
        }

        public static string searchEvent(string myEvent) {
            string temp = null;
            for (int i = 0; i < list.Count; i++) {
                if (list[i].foreignEvent.Equals(myEvent)) {
                    // Console.WriteLine("Event " + list[i].unifiedEvent + " Equals " + myEvent);
                    temp = list[i].unifiedEvent;
                    break;
                } else {
                    temp = "unknown Event :-(";
                }  
            }
            return temp;
        }

        public static string createMessage(string clientId, string eventTime, string eventEvent, string eventValue) {
		/*	string xmlMessage = "<?xml  version=\"1.0\"  encoding=\"utf-8\"  ?><message dataPointID=\"se.kth.xpres.cnc\">"
              + clientId + "</id><datetime>"
              + eventTime + "</datetime><event>"
              + Events.searchEvent(eventEvent) + "</event><value>"
              + eventValue + "</value></message>"; */

		/* string xmlMessage = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><message dataPointID=\"se.kth.xpres.cnc\"><header><type>EventNotification</type><timestamp>" 
			+ eventTime + "</timestamp><sender>"
			+ clientId + "</sender></header><body><int name=\""
			+ Events.searchEvent(eventEvent) +  "\" value=\"" 
			+ eventValue + "\" type=\"\" /></body></message>";
            return xmlMessage;
        } */ 

		string xmlMessage = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><message><header><type>EventNotification</type><timestamp>" 
				+ eventTime + "</timestamp><sender>"
				+ clientId + "</sender></header><body><int name=\""
				+ Events.searchEvent(eventEvent) +  "\" value=\"" 
				+ eventValue + "\" type=\"\" /></body></message>";
		return xmlMessage;
		}
    }
}