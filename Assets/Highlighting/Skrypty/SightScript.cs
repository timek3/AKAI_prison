using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightScript : MonoBehaviour
{
    //Zmienne
    public bool unlimitedRange; //Chcemy nieograniczony zasięg?
    public bool noClickRequired = true; //Czy trzeba mieć przytrzymany M1 by podświetlać?
    public Camera cam; //kamera
    public float range; //zasięg

    // Update is called once per frame
    void Update()
    {
        if (noClickRequired || Input.GetButtonDown("Fire1"))
        {
            pointAt();
        }
    }

    //Czy gracz na coś patrzy?
    void pointAt()
    {
        RaycastHit hit;

        //jeżeli w coś trafimy raycastem...
        //TODO if tag == interactable
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {

            //Podświetlamy obiekt
            HighlightObject highlighted = hit.transform.GetComponent<HighlightObject>();
            if (highlighted != null)
            {
                //Debug.Log(highlighted.name); //nazwa obiektu w konsoli
                highlighted.lightUp(); //funkcja od podświetlania;
            }
        }
    }
}
