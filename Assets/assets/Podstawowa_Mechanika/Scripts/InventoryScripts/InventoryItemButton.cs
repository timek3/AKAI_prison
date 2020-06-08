using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemButton : MonoBehaviour
{
   public void ShowThisItem()
    {
		GameObject realGala = GameObject.Find("Knob");
		Debug.Log(gameObject.transform.GetSiblingIndex());
        int buttonNumber = gameObject.transform.GetSiblingIndex();
        if (buttonNumber < Inventory.instance.items.Count)
        {
            Item choosenItem = Inventory.instance.items[buttonNumber];
            LookOnItemScript lookOnItemScript = GameObject.Find("GameManager").GetComponent<SecondView>().secondView;
            lookOnItemScript.pressR.SetActive(false);
            InventoryUI UI = GameObject.Find("UI").GetComponent<InventoryUI>();
            UI.SwichActive();
            UI.enable = false;
            lookOnItemScript.ShowItem(choosenItem, null);
			realGala.SetActive(false);
        }
        
        
    }
}
