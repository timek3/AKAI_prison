using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineSwitch : MonoBehaviour
{
    //Pierwszy timeline
    public GameObject timelineOne;
    //Drugi timeline
    public GameObject timelineTwo;
    //Czy jestesmy w drugim timelinie?
    public bool timelineTracker;
    //Odleglosc miedzy dwoma timelineami, nie uzywana do niczego atm
    public Vector3 timelineDistance()
    {
        Vector3 dist = timelineOne.transform.position - timelineTwo.transform.position;
        if (timelineTracker == false)
        {
            return dist;
        }
        else
        {
            return -dist;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        timelineTracker = false; //Zaczynamy w pierwszym timelinie
        Debug.Log(timelineDistance());

    }

    //Zamiana timelie'ów
    void timelineSwitch()
    {
        Vector3 defunct = new Vector3(0, 0, 40);
        if (timelineTracker == false)
        {
            timelineOne.transform.position = timelineTwo.transform.position;
            timelineTwo.transform.position = defunct;
            timelineTracker = !timelineTracker;

        }
        else
        {
            timelineTwo.transform.position = timelineOne.transform.position;
            timelineOne.transform.position = defunct;
            timelineTracker = !timelineTracker;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("v"))
        {
            timelineSwitch();
        }
    }
}
