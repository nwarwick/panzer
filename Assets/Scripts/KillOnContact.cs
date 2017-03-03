using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnContact : MonoBehaviour {
    public GameObject deathEffect;
    
	void OnCollisionEnter(Collision other)
    {
        Debug.Log("HIT SOMETHING");
        // Check if a hazard was hit
        if(other.gameObject.tag == "Hazard"){
            
            Tank tank = GetComponent<Tank>();
            
            if(tank != null)
            {
                tank.Explode();
            }
            
        }
    }
}
