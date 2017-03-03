using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{

    public float forwardSpeed = 2;
    public float backwardSpeed = 10;
    public float turnRate = 200;
    public float health = 100;

    public GameObject deathEffect;
    public AudioManager am;

    public Cannon cannon;
    //public HealthBar healthBar;


    public void Start()
    {
        if (am == null)
        {
            am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        }
    }

    public void MoveForward()
    {
        transform.Translate(0, 0, Time.deltaTime * forwardSpeed);
    }

    public void MoveBackward()
    {
        transform.Translate(0, 0, -(Time.deltaTime * backwardSpeed));
    }

    public void TurnLeft()
    {
        transform.Rotate(0, -(Time.deltaTime * turnRate), 0);
    }

    public void TurnRight()
    {
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

	/*public void TurnToward(Vector3 direction) {
		
		var axis = Vector3.Cross (direction, transform.position);

		if (axis.magnitude < 0.03) {
			axis = Vector3.zero;
		}
		var sign = -Vector3.Dot (Vector3.forward, axis.normalized);

		transform.RotateAround (transform.position, Vector3.up, sign * Time.deltaTime * turnRate);

	}*/

    public void TurnToward(Vector3 target)
    {
		transform.LookAt(target);
    }

	public void Rotate(float angle) 
	{
		transform.RotateAround(transform.position, Vector3.up, angle);
	}

    public void MoveTowards(Vector3 target)
    {
        var speed = 20f;
        // The step size is equal to speed times frame time.
        var step = speed * Time.deltaTime;

        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }


    public void ApplyDamage(float damage)
    {

        health -= damage;

        //healthBar.SetHealth (health);

        var ai = GetComponent<TankAI>();
        if (ai != null)
        {

            // TODO: -------------------------
            // Make AI respond to attack
            ai.state = TankAI.Attacking;


            // -------------------------------

        }

        if (health <= 0)
        {

            var player = GetComponent<Player>();

            if (player == null)
            {

                Destroy(gameObject);

            }
            else
            {

                health = 100;
                //healthBar.SetHealth (100);

                transform.position = Vector3.zero;

                var aiTanks = GameObject.FindObjectsOfType<TankAI>();
                foreach (var tank in aiTanks)
                {
                    Destroy(tank.gameObject);
                }

            }
            
            Explode();
        }
    }

    public void Explode()
    {
        if(deathEffect != null)
		{ 
			Instantiate (deathEffect,this.transform.position,this.transform.rotation);
		}
        am.PlaySound("TankExplosion");
		GameObject.Destroy(this.gameObject);
    }
}
