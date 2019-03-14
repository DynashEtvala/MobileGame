using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Sector : MonoBehaviour {

    public string sName;
    public string sEvent;
    public List<string> sSubEvents;
    public static int MAX_SUB_EVENTS = 5;

    string[] events = { "Pirtates!", "Shop", "Station", "Asteroid Field"};
    string[] sEvents = { "Landmines", "Scavengers", "Slave Runners", "Idk what else", "Fuck", "shit", "UPP" };


    public void Generate() {
        int sID = Random.Range(0, 9999);
        sName = "Sector" + sID;
        int sEventIndex = Random.Range(0, events.Length);
        sEvent = events[sEventIndex];
        List<string> temp = new List<string>();
        for(int i = 0; i < Random.Range(0, MAX_SUB_EVENTS); i++)
        {
            //temp.Add(sEvents[Random.Range(0, sEvents.Length)]);
            sSubEvents.Add(sEvents[Random.Range(0, sEvents.Length)]);
        }
        //IEnumerable<string> iStrings = temp.Distinct();
        //sSubEvents = iStrings.ToList();
    }



	void Start () {
        Generate();
	}
}
