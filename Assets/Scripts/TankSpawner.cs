using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour {

	public int numberOfEnemies = 6;

	public GameObject enemyPrefab;
	public float minSpawnDist = 5; // Min spawn distance from centre of map
	public float maxSpawnDist = 20; // Max spawn distance from centre of map
	private Vector3 spawnPos;
	public Transform levelCentre;

	void Start()
	{
		if(levelCentre == null) 
		{
			levelCentre = GameObject.Find("LevelCentre").transform;
		}
	}

	void SpawnTank () {
		
		var newTank = Instantiate (enemyPrefab);

		//newTank.transform.position = Random.insideUnitCircle * 20;

		// Keep generating spawnpoints until we get one that isn't within the min spawn distance
		do {
			spawnPos = new Vector3(Random.Range(-maxSpawnDist, maxSpawnDist), 0, Random.Range(-maxSpawnDist, maxSpawnDist));
		} while (Vector3.Distance(spawnPos, levelCentre.position) <= minSpawnDist );

		newTank.transform.position = spawnPos;

	}

	void Update () {

		var tanksList = GameObject.FindObjectsOfType<TankAI> ();

		if (tanksList.Length < numberOfEnemies) {
			SpawnTank ();
		}
		
	}
}
