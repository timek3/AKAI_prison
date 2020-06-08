using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    private GameObject hint;
    public Item itemObject;
    private float distance;
    private LookOnItemScript lookOnItemScript;

    private InventoryUI UI;

	public Sprite gala;
	public Sprite reka;
	GameObject realGala;

	private bool inRadius = false;

	private void Start()
    {
		realGala = GameObject.Find("Knob");
		lookOnItemScript = GameObject.Find("GameManager").GetComponent<SecondView>().secondView;
        UI = GameObject.Find("UI").GetComponent<InventoryUI>();
    }

    void Update()
    {
        if (!lookOnItemScript.isLooking && UI.enable)
        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.GetChild(0).position);

            if (distance <= 2.1f)
            {
				inRadius = true;
				realGala.GetComponent<Image>().sprite = reka;
				//hint.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
					//hint.SetActive(false);
					realGala.GetComponent<Image>().sprite = gala;
					realGala.SetActive(false);
                    lookOnItemScript.ShowItem(itemObject, gameObject);
                }

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    //hint.SetActive(false);
                    lookOnItemScript.PickingUp(itemObject, gameObject);
					inRadius = false;
					realGala.GetComponent<Image>().sprite = gala;
				}
            }
            else if(inRadius == true && distance > 2.1f)
            {
				inRadius = false;
				realGala.GetComponent<Image>().sprite = gala;
				//hint.SetActive(false);
			}
        }
        else
        {
            //hint.SetActive(false);
        }
    }


}
