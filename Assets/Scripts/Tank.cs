using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

	public float forwardSpeed = 2f;
	public float backwardSpeed = 10f;
	public float turnRate = 200f;
	public float health = 100;

	public Cannon cannon;
	//public HealthBar healthBar;

	public void MoveForward() {
		transform.Translate(0, 0, Time.deltaTime * forwardSpeed);
	}

	public void MoveBackward() {
		transform.Translate(0, 0, -(Time.deltaTime * backwardSpeed));
	}

	public void TurnLeft(){
		transform.Rotate(0, -(Time.deltaTime * turnRate), 0);
	}

	public void TurnRight(){
		transform.Rotate(0, Time.deltaTime * turnRate, 0);
	}

	/*public void TurnToward(Vector3 direction) {
		
		var axis = Vector3.Cross (direction, transform.position);

		if (axis.magnitude < 0.03) {
			axis = Vector3.zero;
		}
		var sign = -Vector3.Dot (Vector3.forward, axis.normalized);

		transform.RotateAround (transform.position, Vector3.forward, sign * Time.deltaTime * turnRate);

	}*/ 

	public void TurnToward(Vector3 position)
	{
		var targetDir = position - transform.position;
		
	    // The step size is equal to speed times frame time.
	    var step = 2 * Time.deltaTime;
	    
	    var newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
	    Debug.DrawRay(transform.position, newDir, Color.red);
	    // Move our position a step closer to the target.
	    transform.rotation = Quaternion.LookRotation(newDir);
	}



	public void ApplyDamage(float damage) {
		
		health -= damage;

		//healthBar.SetHealth (health);

		var ai = GetComponent<TankAI> ();
		if (ai != null) {

			// TODO: -------------------------
			// Make AI respond to attack
			ai.state = TankAI.Attacking;


			// -------------------------------

		}

		if (health <= 0) {

			var player = GetComponent<Player> ();

			if (player == null) {
				
				Destroy (gameObject);

			} else {
				
				health = 100;
				//healthBar.SetHealth (100);

				transform.position = Vector3.zero;

				var aiTanks = GameObject.FindObjectsOfType<TankAI> ();
				foreach (var tank in aiTanks) {
					Destroy (tank.gameObject);
				}

			}
		}

	}
}
