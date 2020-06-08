using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogScript : MonoBehaviour
{
	public Dialogue dialogue;

	float radius = 10f;
	AudioSource audioS;

	public Sprite gala;
	public Sprite ucho;
	GameObject realGala;

	GameObject player;

	float distance;

	public bool dialogOn = false;

	public GameObject dialogg;

	private bool inRadius = false;

	private DialogManager dm;

	bool endDialogTrigger = false;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(transform.position, radius);
	}

	private void Start()
	{
		player = GameObject.Find("Player");
		realGala = GameObject.Find("Knob");
		audioS = GameObject.Find("Audio Source").GetComponent<AudioSource>();
		dm = GameObject.Find("DialogManager").GetComponent<DialogManager>();
		distance = Vector3.Distance(transform.position, player.GetComponent<Transform>().position);
	}

	private void Update()
	{
		distance = Vector3.Distance(transform.position, player.GetComponent<Transform>().position);

		if (distance <= radius)
		{
			inRadius = true;
			realGala.GetComponent<Image>().sprite = ucho;
			if (dialogOn == false)
			{
				if (Input.GetKeyDown(KeyCode.Mouse1))
				{

					if (dialogOn == false)
					{
						Cursor.lockState = CursorLockMode.None;
						dialogg.SetActive(true);
						TriggerDialogue();
						audioS.Play(0);
						dialogOn = true;
					}
				}
			}			
			
			if(Input.GetKeyDown(KeyCode.C))
			{
				
				if (dialogOn == false)
				{
					Cursor.lockState = CursorLockMode.None;
					dialogg.SetActive(true);
					audioS.Play(0);
					dialogOn = true;
					TriggerDialogue();

				}
			}					
		}

		if (distance > radius || dm.trigger == true)
		{
			if(inRadius == true)
			{
				realGala.GetComponent<Image>().sprite = gala;
				inRadius = false;
			}		
			if (dialogOn)
			{
				Cursor.lockState = CursorLockMode.Locked;
				realGala.GetComponent<Image>().sprite = gala;
				audioS.Stop();
				dialogOn = false;
				dialogg.SetActive(false);
				dm.trigger = false;
			}			
		}
	}

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogManager>().StartDialogue(dialogue);
	}
}
