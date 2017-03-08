using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{

    public const int Patrolling = 0;
    public const int Attacking = 1;
    public const int Fleeing = 2;

    public float detectionDistance = 10;
    public float fleeThreshold = 40;
    public float patrolPeriod = 1f;
    public float cannonReloadTime = 2;
    public float followDistance = 15;

    public int state = Patrolling;

    Tank tank;

    Player player;

    Vector3 patrolDirection;
    float patrolTimer = 0;

    float cannonCooldown = 0;

    void Start()
    {

        tank = GetComponent<Tank>();
        player = GameObject.FindObjectOfType<Player>();

    }

    void Update()
    {
        // Check if player exists, if not, return
        if(player == null)
        {
            GameObject newTarget = GameObject.Find("Player");
            
            if(newTarget == null){
                return;
            }else {
                player = newTarget.GetComponent<Player>();
            }
        }

        // To get aiming position, subract firing position from target position
		// Normalize so that vector length is 1, since it is a direction
        var playerDirection = (player.transform.position - transform.position).normalized;
		var playerPosition = player.transform.position;

		Vector3 fleeDirection = (transform.position - player.transform.position).normalized;

        //Debug.Log(state);

        switch (state)
        {

            case Patrolling:

                // TODO: -------------------------
                // Add patrol behaviour
                /*do
                {
                    // Choose a direction for the AI to move in
                    patrolDirection = Random.insideUnitCircle;
                    patrolDirection = (new Vector3(0, patrolDirection.y, 0));
                    
                } while (Vector3.Dot(transform.position, patrolDirection) > 0); // Make sure the direction points towards the center of the screen (2D!!, must fix!)*/
				
                //Debug.Log(patrolDirection);
               // tank.TurnToward(patrolDirection);
                float angle = Random.Range(0, 360);

                if (patrolTimer <= 0)
                {
                    patrolTimer = patrolPeriod;
					
                    // Change patrolDirection
                    //tank.TurnToward(patrolDirection);
                    /*patrolDirection = Random.insideUnitCircle;
                    patrolDirection = (new Vector3(0, patrolDirection.y, 0));
                    tank.TurnToward(patrolDirection);*/
                    tank.Rotate(angle);
                }

                patrolTimer -= Time.deltaTime;

                // Move tank
                tank.MoveForward();



                // -------------------------------

                // TODO: -------------------------
                // Under what circumstances should state transitions occur?
                // Add logic to leave patrol state (Check for player within detection distance)

                // If distance between tank and player is lower than threshold, begin attacking
                if (Vector3.Distance(playerPosition, tank.transform.position) < detectionDistance)
                {
                    state = Attacking;
                }


                // -------------------------------

                break;

            case Attacking:

                // TODO: -------------------------
                // Add attack behaviour

				

                cannonCooldown -= Time.deltaTime;

                // Move tank
                if (Vector3.Distance(transform.position, playerPosition) > followDistance)
                {
                    //Debug.Log("Dist between = " + Vector3.Distance(transform.position, playerPosition) + "Follow dist = " + followDistance);
                    
                    tank.TurnToward(playerPosition);
                    tank.MoveForward();
                }

                tank.cannon.AimToward(playerPosition); // UPDATE TO LEAD SHOT
                if (cannonCooldown <= 0)
                {
                    cannonCooldown = cannonReloadTime;

                    // Fire cannon at player
                    tank.cannon.Fire();

                }

                // -------------------------------

                // TODO: -------------------------
                // Add logic to leave attack state (Check for tank health below flee threshold)
                if (tank.health <= fleeThreshold)
                {
					state = Fleeing;
                }


                // -------------------------------

                break;

            case Fleeing:

                // TODO: -------------------------
                // Add flee behaviour
				tank.TurnToward(fleeDirection);
				tank.MoveForward();

				// Keep shooting at the player
				tank.cannon.AimToward(playerPosition);
                if (cannonCooldown <= 0)
                {
                    cannonCooldown = cannonReloadTime;

                    // Fire cannon at player
                    tank.cannon.Fire();
					Debug.Log("Firing");

                }

                cannonCooldown -= Time.deltaTime;

                // -------------------------------

                // TODO: -------------------------
                // Add logic to leave flee state (Check for minimum distance reached)
				if(Vector3.Distance(tank.transform.position, playerPosition) > detectionDistance)
				{
					state = Patrolling;
				} 


                // -------------------------------

                break;

        }
    }

    void OnDestroy()
    {
        
    }
}
