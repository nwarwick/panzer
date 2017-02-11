using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankTurret : MonoBehaviour {

	public GameObject turret;
	public float swizzleSpeed = 5f;
	public GameObject bullet;
	public Transform bulletSpawn;
	public Text bulletCountText;
	//private int bulletCount = 0;


	// Use this for initialization
	void Start () {
		if(turret == null){
			turret = GameObject.Find("TankTurret").gameObject;
		}

		if(bullet == null){
			//turret = GameObject.Find("Bullet").gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Q))
		{
			turret.transform.Rotate(0f, -swizzleSpeed * Time.deltaTime, 0f);
		}
		if (Input.GetKey(KeyCode.E))
		{
			turret.transform.Rotate (0f, swizzleSpeed * Time.deltaTime, 0f);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
		}
	}
}
