using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankTurret : MonoBehaviour {

	public float swizzleSpeed;
	public GameObject bullet;
	public Transform bulletSpawn;
	public Text bulletCountText;
	private int bulletCount = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Q))
		{
			gameObject.transform.Rotate(0f, 0f, -swizzleSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.E))
		{
			gameObject.transform.Rotate (0f, 0f, swizzleSpeed * Time.deltaTime);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
			bulletCount += 1;
			bulletCountText.text = "Bullets: " + bulletCount;
		}
	}
}
