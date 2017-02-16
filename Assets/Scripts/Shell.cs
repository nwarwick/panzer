using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

	public float ShellSpeed = 60;
	public float lifeSpan = 2;

	void Start(){
		Object.Destroy(gameObject, lifeSpan);
	}

	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * ShellSpeed * Time.deltaTime;
	}
}
