using UnityEngine;
using System.Collections;

public class EnemySpawner00 : MonoBehaviour
{
	public GameObject GameManagerGO; 
	public GameObject[] Bacterias;   

	public float xRange = 0.1f;
	public float yRange = 1.0f;
	//public float minSpawnTime = 1.0f;
	//public float maxSpawnTime = 10.0f;

	float maxSpawnRateInSeconds = 9f; 

	void Start()
	{
		//Invoke("SpawnEnemy", maxSpawnRateInSeconds);
		//InvokeRepeating ("IncreaseSpawnRate", 0f, 5f); 	
	}

	void SpawnEnemy()
	{
		Vector2 min1 = Camera.main.ViewportToWorldPoint (new Vector2 (0.3f, 0.0f)); 
		Vector2 max1 = Camera.main.ViewportToWorldPoint (new Vector2 (0.5f, 1.0f));
		int BacteriasIndex = Random.Range(0,Bacterias.Length); 
		GameObject randBacteria = Bacterias[BacteriasIndex];
		GameObject newBacteria = GameObject.Instantiate(randBacteria) as GameObject;
		newBacteria.transform.position = new Vector2 (Random.Range (min1.x, max1.x), max1.y);
		ScheduleNextEnemySpawn (); 
	}




	void ScheduleNextEnemySpawn () {

		float spawnInNSeconds; 

		if (maxSpawnRateInSeconds > 1f) {

			//pick a number between 1 and maxSpawnRateinSeconds
			spawnInNSeconds = Random.Range (1f, maxSpawnRateInSeconds); 
		} else
			spawnInNSeconds = 1f; 

		Invoke ("SpawnEnemy", spawnInNSeconds); 

	}

	//Function to increase difficulty of game 

	void IncreaseSpawnRate() {

		if(maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--; 

		if (maxSpawnRateInSeconds == 1f)
			CancelInvoke ("IncreaseSpawnRate");


	}

	//Function to start enemy spawner
	public void ScheduleEnemySpawner00() {

		Invoke("SpawnEnemy", maxSpawnRateInSeconds);
		InvokeRepeating ("IncreaseSpawnRate", 0f, 10f); 	

	}

	//Function to stop enemy spawner
	public void UnScheduleEnemySpawner00() {
		CancelInvoke("SpawnEnemy");
		CancelInvoke ("IncreaseSpawnRate"); 


	}
}
