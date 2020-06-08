using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	//singleton dla łatwiejszego dostępu do tego kawałka kodu. Dzięki temu że istnieje tylko jeden ekwipunek możemy w innych skryptach po prostu napisać Inventory.instance.
	#region Singleton

	public static Inventory instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of Inventory found!");
			return;
		}
		instance = this;
	}

	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 4;

	public List<Item> items = new List<Item>();

	public bool Add(Item item)
	{
		if (!item.isDefaultItem)
		{
			if (items.Count >= space)
			{
				Debug.Log("not enough space in inv");
				return false;
			}
			items.Add(item);
			if (onItemChangedCallback != null)
			{
				onItemChangedCallback.Invoke();
			}
		}
		return true;
	}

	public void Remove(Item item)
	{
		items.Remove(item);

		if (onItemChangedCallback != null)
		{
			onItemChangedCallback.Invoke();
		}
	}
}
