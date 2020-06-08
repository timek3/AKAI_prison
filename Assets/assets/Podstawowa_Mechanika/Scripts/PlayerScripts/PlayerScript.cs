using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public bool itemInterface = false;

	CharacterController controller;

	float speed = 12f;
	float gravity = -9.81f * 2;
	float jumpHeight = 3f;

	Transform groundCheck;
	float groundDistance = 0.4f;
	public LayerMask groundMask;

	Vector3 velocity;
	bool isGrounded;

	bool przejscie = true;

	int czyMin = 1;

	void Start()
	{
		groundCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();
		controller = gameObject.GetComponent<CharacterController>();
		//Cursor.lockState = CursorLockMode.None;
	}

	void Update()
	{
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;
		if (itemInterface == false)
		{
			controller.Move(move * speed * Time.deltaTime);
		}
		if (Input.GetButtonDown("Jump"))
		{
			Debug.Log("Space działa");
		}

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			Debug.Log("Skok działa");
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);




	}
}
