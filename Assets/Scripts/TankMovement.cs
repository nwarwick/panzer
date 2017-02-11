using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {
	public float forwardSpeed = 5f;
	public float backwardSpeed = 5f;
	public float turnRate = 20f;

	public Vector3 moveDirection = Vector3.zero;

	void Update() {
		// Move forward
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(0, 0, Time.deltaTime * forwardSpeed);
		}

		// Move backward
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(0, 0, -(Time.deltaTime * forwardSpeed));
		}

		// Turn left
		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(0, -(Time.deltaTime * turnRate), 0);
		}

		// Turn right
		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(0, Time.deltaTime * turnRate, 0);
		}
	}
}
