using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeyTerminalScript : MonoBehaviour
{
	float distance;

	PlayerScript playa;

	GameObject cialo;

	GameObject item;
	GameObject tempParent;

	public GameObject door;

	bool key = false;

	Inventory inventory;

	bool open = false;

	Item invItem;

	// to sprite-y ikonek gałki
	public Sprite gala;
	public Sprite badDoors;
	public Sprite doors;
	GameObject realGala;

	bool inRadius = false;

	void Start()
	{
		item = GameObject.Find("KeyTerminal");
		tempParent = GameObject.Find("Guide");
		cialo = GameObject.Find("Guide");
		playa = GameObject.Find("Player").GetComponent<PlayerScript>();
		realGala = GameObject.Find("Knob");
		inventory = Inventory.instance;
	}

		void Update()
    {


		distance = Vector3.Distance(item.transform.position, tempParent.transform.position);

		if (distance <= 2f && key == true && open == false )
		{
			inRadius = true;
			Debug.Log("dis <= 2 i jest klucz");
			realGala.GetComponent<Image>().sprite = doors;
			//inter.SetActive(true);
		}
		else if(distance <= 2f && open == false)
		{
			inRadius = true;
			Debug.Log("dis <= 2 i nie ma klucza");
			HasKey();
			realGala.GetComponent<Image>().sprite = badDoors;
		}
		else if (distance > 2f && inRadius == true)
		{
			inRadius = false;
			realGala.GetComponent<Image>().sprite = gala;
		}


		if (Input.GetKeyDown(KeyCode.Mouse0) && distance <= 2f && key == true)
		{
			Debug.Log("otwieram drzwi");
			door.SetActive(false);
			open = true;
			inventory.Remove(invItem);
			realGala.GetComponent<Image>().sprite = gala;
		}
	}


	void HasKey()
	{
		for(int i =0; i < inventory.items.Count; i++)
		{
			if(inventory.items[i].name == "Key")
			{
				key = true;
				Debug.Log("w eq jest klucz!");
				invItem = inventory.items[i];
			}
		}
	}
}
