using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Cannon : MonoBehaviour {

	public float swizzleSpeed = 5f;
	public GameObject bullet;
	public Transform bulletSpawn;
	//public Text bulletCountText;
	//private int bulletCount = 0;
	public AudioManager am;

	public AudioClip clip;
    private AudioSource source;
	
	// Use this for initialization
	void Start () {
		
		if(bullet == null){
			//cannon = GameObject.Find("Bullet").gameObject;
		}

		if(am == null){
			am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		}

	}

	public void AimToward(Vector3 direction) {
		//transform.right = direction;
		transform.LookAt(direction);
	}

	public void Fire()
	{
		Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
		am.PlaySound("Firing");
	}
}