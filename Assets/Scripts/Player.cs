using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Deals with movement and aiming controls, as well as firing
public class Player : MonoBehaviour {

	Tank tank;

	void Start () {

		tank = GetComponent<Tank> ();

	}

	void Update () {
		// Move forward
		if (Input.GetKey(KeyCode.W))
		{
			tank.MoveForward();
		}

		// Move backward
		if (Input.GetKey(KeyCode.S))
		{
			tank.MoveBackward();
		}

		// Turn left
		if (Input.GetKey(KeyCode.A))
		{
			tank.TurnLeft();
		}

		// Turn right
		if (Input.GetKey(KeyCode.D))
		{
			tank.TurnRight();
		}

		// This code deals with mouse aiming
		Ray cameraRay; // The ray that is cast from the camera to the mouse position
     	RaycastHit cameraRayHit;

		// Cast a ray from the camera to the mouse cursor
         cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
         
         // If the ray strikes an object...
         if (Physics.Raycast(cameraRay, out cameraRayHit)) 
         {
             // ...and if that object is the ground...
            
                 // ...make the cannon rotate (only on the Y axis) to face the ray hit's position 
                 Vector3 targetPosition = new Vector3(cameraRayHit.point.x, tank.cannon.getHeight(), cameraRayHit.point.z);
				 tank.cannon.AimToward(targetPosition);
             
         }

		if (Input.GetMouseButtonDown (0)) {
			tank.cannon.Fire ();
		}
	}

	public void Kill()
	{
		Destroy(gameObject);
		
		// TODO: Play death effect/respawn stuff
	}

}
