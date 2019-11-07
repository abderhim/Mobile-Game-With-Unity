using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public float spawnTime = 3f; 

	public GameObject enemy;                // The enemy prefab to be spawned.
	            // How long between each spawn.
	//Transform[] spawnPoints;
	float x;
	float y;
	float z;
	Vector3 pos;


	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);

	}


	void Spawn ()
	{
		// If the player has no health left...
		x = Random.Range(-20,20);
		y = 0;
		z = 0;
		pos = new Vector3(x, y, z);



		// Find a random index between zero and one less than the number of spawn points.
		//int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (enemy, pos,Quaternion.Euler(0f,0f,0f));
	}







}
