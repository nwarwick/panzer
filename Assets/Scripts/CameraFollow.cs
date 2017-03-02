using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - target.transform.position;
    }
    
    // LateUpdate is called after Update each frame
    void Update () 
    {

        if (target == null)
            {
                GameObject newTarget = GameObject.Find("Player");

                if(newTarget == null)
                    return;
                
                target = newTarget.transform;
            }

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = target.transform.position + offset;
    }
}