using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwitcher : MonoBehaviour
{
    //Pierwszy timeline
    public GameObject timelineOne;
    //Drugi timeline
    public GameObject timelineTwo;
    //Czy jestesmy w drugim timelinie?
    public bool timelineTracker;

    // Start is called before the first frame update
    void Start()
    {
        timelineTracker = false; //Zaczynamy w pierwszym timelinie
    }

    void timelineSwitcherEngage()
    {
        if (timelineTracker == false)
        {
            timelineOne.transform.position = new Vector3(0, 0, 50);
            timelineTwo.transform.position = new Vector3(0, 0, 0);
            timelineTracker = !timelineTracker;
        }
        else
        {
            timelineTwo.transform.position = new Vector3(0, 0, 50);
            timelineOne.transform.position = new Vector3(0, 0, 0);
            timelineTracker = !timelineTracker;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("v"))
        {
            timelineSwitcherEngage();
        }
    }
}
