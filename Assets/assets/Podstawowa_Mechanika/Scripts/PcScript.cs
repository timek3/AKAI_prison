using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PcScript : MonoBehaviour
{
	float distance;

	GameObject item;
	GameObject tempParent;

	public bool PCoff = true;

	public GameObject uIPC;

	Inventory inventory;

	public Sprite gala;
	public Sprite konkuter;
	GameObject realGala;

	bool inRadius = false;

	void Start()
	{
		realGala = GameObject.Find("Knob");
		item = GameObject.Find("PC");
		tempParent = GameObject.Find("Guide");
		inventory = Inventory.instance;
	}

	void Update()
	{


		distance = Vector3.Distance(item.transform.position, tempParent.transform.position);

		if (distance <= 2f && PCoff == true)
		{
			inRadius = true;
			Debug.Log("dis <= 2 na pc");
			realGala.GetComponent<Image>().sprite = konkuter;
			//interText.text = "[Press R to open the turn on PC]";
			//inter.SetActive(true);
		}
		else if(inRadius == true)
		{
			realGala.GetComponent<Image>().sprite = gala;
			inRadius = false;
			//inter.SetActive(false);
		}


		if (Input.GetKeyDown(KeyCode.Mouse0) && distance <= 2f)
		{
			Debug.Log("otwieram pc");
			uIPC.SetActive(true);
			realGala.SetActive(false);
			Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0f;
			PCoff = false;

		}
	}

	public void pcTurnOff()
	{
		uIPC.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
		Time.timeScale = 1f;
		PCoff = true;
		realGala.SetActive(true);
	}
}
