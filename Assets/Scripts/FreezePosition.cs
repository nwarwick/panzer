using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePosition : MonoBehaviour {

	
	void OnCollisionEnter(Collision other)
	{
		Debug.Log("Freezing position");
		gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}
	
}
