using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleScript : MonoBehaviour
{ 
	//public GameObject psys;
	private CharacterController characterController;
	public float potentialPlaceRadius = 0.7f;

	private Vector3 potentialPlace;

	void Start()
	{
		characterController = gameObject.transform.GetComponent<CharacterController>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			if (gameObject.transform.position.z > 500)
			{
				potentialPlace = gameObject.transform.position + new Vector3(0, 0, -1000);

			}
			else
			{
				potentialPlace = gameObject.transform.position + new Vector3(0, 0, 1000);

			}

			Collider[] hitColliders = Physics.OverlapSphere(potentialPlace, potentialPlaceRadius);
			if (hitColliders.Length == 0)
			{
				//odpal animacje zegarka
				ChangeTime();
			}
			else
			{
				//potrząśnij kamerą
				Debug.Log("Teleportacja niemożliwa");
				foreach (Collider hit in hitColliders)
				{
					Debug.Log(hit.gameObject);
				}
			}

		}
	}

	void ChangeTime()
	{
		characterController.enabled = false;
		gameObject.transform.position = potentialPlace;
		//Instantiate(psys, transform.position, Quaternion.identity);
		characterController.enabled = true;
	}
}
