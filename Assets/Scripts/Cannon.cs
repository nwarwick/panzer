using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour {

	public float swizzleSpeed = 5f;
	public GameObject bullet;
	public Transform bulletSpawn;
	//public Text bulletCountText;
	//private int bulletCount = 0;


	// Use this for initialization
	void Start () {
		
		if(bullet == null){
			//cannon = GameObject.Find("Bullet").gameObject;
		}
	}

	public void AimToward(Vector3 direction) {
		//transform.right = direction;
		transform.LookAt(direction);
	}

	public void Fire()
	{
		Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
	}
	
	/*// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Q))
		{
			cannon.transform.Rotate(0f, -swizzleSpeed * Time.deltaTime, 0f);
		}
		if (Input.GetKey(KeyCode.E))
		{
			canon.transform.Rotate (0f, swizzleSpeed * Time.deltaTime, 0f);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
		}
	}*/
}