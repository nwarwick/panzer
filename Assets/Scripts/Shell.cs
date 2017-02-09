using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float bulletSpeed = 60;
	public float lifeSpan = 2;

	void Start(){
		Object.Destroy(gameObject, lifeSpan);
	}

	// Update is called once per frame
	void Update () {
		transform.position += transform.up * bulletSpeed * Time.deltaTime;
	}
}
