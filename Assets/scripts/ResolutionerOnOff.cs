using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionerOnOff : MonoBehaviour
{
    public Component resolutioner;
    public bool onoff;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Resolutioner>().enabled = onoff;
            onoff = !onoff;
        }
    }
}
