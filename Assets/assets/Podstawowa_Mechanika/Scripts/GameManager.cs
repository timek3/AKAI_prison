using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public bool pause = false;
	GameObject PausePanel;

    // Start is called before the first frame update
    void Start()
    {
		PausePanel = GameObject.Find("PausePanel");
		Cursor.lockState = CursorLockMode.Locked;
		PausePanel.SetActive(false);

	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!pause)
			{
				Cursor.lockState = CursorLockMode.None;
				Time.timeScale = 0f;
				PausePanel.SetActive(true);
				pause = true;
			}
			else if(pause)
			{
				Cursor.lockState = CursorLockMode.Locked;
				Time.timeScale = 1f;
				PausePanel.SetActive(false);
				pause = false;
			}
		}
	}

	public void UnPauseGame()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Time.timeScale = 1f;
		PausePanel.SetActive(false);
		pause = false;
	}

	public void ReturnToMenu()
	{
		Time.timeScale = 1f;
		Cursor.lockState = CursorLockMode.None;
		pause = false;
		Debug.Log("Wracam Do Menu");
	}
}
