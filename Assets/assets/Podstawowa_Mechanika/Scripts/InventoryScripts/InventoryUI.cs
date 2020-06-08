using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    //public TextMeshProUGUI opisPrzedmiotu;
    //public GameObject opisPrzedmiotuBox;
    //public GameObject pressT;
    //GameObject camera1;
    //public GameObject camera2;
    //Item itemObject;



    public Transform itemsParent;

    Inventory inventory;

    InventorySlot[] slots;

    public GameObject inventoryUI;

    [HideInInspector] public bool enable;

    void Start()
    {
        enable = true;
        //camera1 = GameObject.Find("Main Camera");
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI; //subskrybcja do delegata

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwichActive();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventoryUI.SetActive(false);
        }

    }

    public void SwichActive()
    {
        if (enable)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);

            if (inventoryUI.activeSelf == true)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

}
