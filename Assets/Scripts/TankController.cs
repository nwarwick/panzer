using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {
	public float forwardSpeed = 15f;
	public float backwardSpeed = 5f;
	public float turnRate = 200f;

	public GameObject cannonObject;
	public Cannon cannon;

	public Vector3 moveDirection = Vector3.zero;

	public void Start() 
	{
		
	}

	void Update() {
		// Move forward
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(0, 0, Time.deltaTime * forwardSpeed);
		}

		// Move backward
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(0, 0, -(Time.deltaTime * backwardSpeed));
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


		Ray cameraRay;                // The ray that is cast from the camera to the mouse position
     	RaycastHit cameraRayHit;

		// Cast a ray from the camera to the mouse cursor
         cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
         
         // If the ray strikes an object...
         if (Physics.Raycast(cameraRay, out cameraRayHit)) 
         {
             // ...and if that object is the ground...
             if(cameraRayHit.transform.tag=="Ground")
             {
				 Debug.Log("Hit the ground");
                 // ...make the cube rotate (only on the Y axis) to face the ray hit's position 
                 Vector3 targetPosition = new Vector3(cameraRayHit.point.x, cannonObject.transform.position.y, cameraRayHit.point.z);
				 cannon.AimToward(targetPosition);
             }
         }

		if (Input.GetMouseButtonDown (0)) {
			cannon.Fire ();
		}
	}
}