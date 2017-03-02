using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

	public float ShellSpeed = 60;
	public float lifeSpan = 2;
	public GameObject explosionEffect;

	public AudioManager am;

	void Start(){
		Object.Destroy(gameObject, lifeSpan);

		if (am == null)
        {
            am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        }
	}

	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * ShellSpeed * Time.deltaTime;
	}


	// Play explosion effect and destroy the shell
	void Explode(){
		if(explosionEffect != null)
		{ 
			Instantiate (explosionEffect,this.transform.position,this.transform.rotation);
		}

		am.PlaySound("ShellExplosion");
		GameObject.Destroy(this.gameObject);
	}

	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Blowing up shell");
		// Check if it hit a tank
		Tank tank = other.GetComponent<Tank>();

		if(tank != null)
		{
			tank.ApplyDamage(20);
		}

		Explode();
	}
}