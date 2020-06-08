using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LookOnItemScript : MonoBehaviour
{
    public GameObject opisPrzedmiotuBox;
    public TextMeshProUGUI opisPrzedmiotu;
    public GameObject pressT;
    private GameObject camera1;
    public GameObject camera2;
    private PlayerScript playerScript;
    private InventoryUI ui;
    public GameObject pressR;

	GameObject realGala;

    [HideInInspector] public bool isLooking;
    GameObject UInstance;

    private Item item;
    GameObject choosenObject;

    private void Start()
    {
		realGala = GameObject.Find("Knob");
		isLooking = false;
        camera1 = Camera.main.gameObject;
        playerScript = GameObject.Find("World/Player").GetComponent<PlayerScript>();
        gameObject.SetActive(false);
        ui = GameObject.Find("UI").GetComponent<InventoryUI>();
    }

    public void ShowItem(Item item, GameObject choosenObject)
    {
        ui.enable = false;
        this.choosenObject = choosenObject;
        this.item = item;
        opisPrzedmiotu.text = item.opis;
        playerScript.itemInterface = true;
        Cursor.lockState = CursorLockMode.None;
        camera1.SetActive(false);
        camera2.SetActive(true);
        if (item.opis != null)
        {
            pressT.SetActive(true);
        }
        UInstance = (GameObject)Instantiate(item.prefabItemu, new Vector3(89.91f, 10.0f, 2.6f), Quaternion.identity);
        gameObject.SetActive(true);
        isLooking = true;
    }

    private void HowerItem()
    {
        playerScript.itemInterface = false;
        Cursor.lockState = CursorLockMode.Locked;
        camera1.SetActive(true);
        camera2.SetActive(false);
        pressT.SetActive(false);
        Destroy(UInstance);
        gameObject.SetActive(false);
        isLooking = false;
        ui.enable = true;

        opisPrzedmiotuBox.SetActive(false);
        pressR.SetActive(true);
    }

    void Update()
    {
        if (isLooking)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                HowerItem();
				realGala.SetActive(true);

			}

            if (choosenObject != null)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    PickingUp(item, choosenObject);
                    HowerItem();
					realGala.SetActive(true);
				}
            }
            
            if (Input.GetKeyDown(KeyCode.T) && item.opis != null)
            {
                opisPrzedmiotuBox.SetActive(!opisPrzedmiotuBox.activeSelf);
            }
        }
    }

    public void PickingUp(Item item, GameObject pickingObject)
    {
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
        {
            Destroy(pickingObject);
        }
    }

}
