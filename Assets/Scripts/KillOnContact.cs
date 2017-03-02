using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnContact : MonoBehaviour {
    public GameObject deathEffect;
    
	void Start()
	{
		
	}

	void OnCollisionEnter(Collision other)
    {
        Debug.Log("HIT SOMETHING");
        // Check if a hazard was hit
        if(other.gameObject.tag == "Hazard"){
            Player player = GetComponent<Player>();
            Tank tank = GetComponent<Tank>();
            // See if we are the player
            if(player != null)
            {
                player.Kill();

            }

            if(tank != null)
            {
                tank.Explode();
            }
            
        }
    }
}
