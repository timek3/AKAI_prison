using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
	public float rotSpeed = 40.0f;

	void OnMouseDrag()
	{
		float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
		float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

		transform.Rotate(Vector3.up, -rotX, Space.World);
		transform.Rotate(Vector3.down, rotX, Space.World);
		transform.Rotate(Vector3.right, rotY, Space.World);
		transform.Rotate(Vector3.left, -rotY, Space.World);
	}
}
