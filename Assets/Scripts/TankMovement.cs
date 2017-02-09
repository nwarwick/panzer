using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {
	public float forwardMovement;
	public float backwardMovement;
	public float turnRate;

	void Update() {
		if (Input.GetKey(KeyCode.W))
		{
			gameObject.transform.position += gameObject.transform.up * forwardMovement * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S))
		{
			gameObject.transform.position -= gameObject.transform.up * backwardMovement * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.A))
		{
			gameObject.transform.Rotate(0f, 0f, turnRate * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D))
		{
			gameObject.transform.Rotate(0f, 0f, -turnRate * Time.deltaTime);
		}
		//and the same for A and D
	}
}
