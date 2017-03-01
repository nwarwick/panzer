using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public float swizzleSpeed = 5f;
    public GameObject bullet;
    public Transform bulletSpawn; // Bullet spawn locaiton
    public Transform firingEffectSpawn; // Firing effect spawn location
    public Transform firingEffectPrefab; // The firing effect prefab
    //public Text bulletCountText;
    //private int bulletCount = 0;
    public AudioManager am;

    // Use this for initialization
    void Start()
    {

        if (bullet == null)
        {
            //cannon = GameObject.Find("Bullet").gameObject;
        }

        if (am == null)
        {
            am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        }

    }

    public void AimToward(Vector3 direction)
    {
        //transform.right = direction;
        transform.LookAt(direction);
    }

    public void Fire()
    {
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        am.PlaySound("Firing");
		Effect();
    }

	// Firing effect
    void Effect()
    {
		Transform effectInstance = (Transform) Instantiate(firingEffectPrefab, firingEffectSpawn.position, firingEffectSpawn.rotation);
		effectInstance.parent = firingEffectSpawn;
        effectInstance.GetComponent<ParticleSystem>().Play();
		Destroy(effectInstance.gameObject, 1f); // Destroy after 0.5f time
    }

    public float getHeight()
    {
        return transform.position.y;
    }
}