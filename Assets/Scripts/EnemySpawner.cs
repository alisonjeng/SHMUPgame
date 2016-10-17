using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject Bacteria; //bacteria1 prefab
	//public GameObject Bacteria1; //bacteria2 prefab
	//public GameObject Bacteria2; //bacteria3 prefab
	//public GameObject Bacteria3; //bacteria4 prefab

	//public GameObject[] Bacterias;
	//GameObject Bacteria;


	float maxSpawnRateInSeconds = 4f; 

	// Use this for initialization
	void Start () {

		//Bacterias = (GameObject[]) Resources.LoadAll("Bacteria");

	
		Invoke ("SpawnEnemy", maxSpawnRateInSeconds); 

		//increase spawn rate every 5 seconds
		InvokeRepeating ("IncreaseSpawnRate", 0f, 10f); 	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//function to spawn enemy
	void SpawnEnemy() {

		//GameObject Bacteria = Bacterias[Random.Range (0, Bacterias.Length)];

		//bacteria 1 min
		Vector2 min1 = Camera.main.ViewportToWorldPoint (new Vector2 (0.1f, 0.0f)); 

		//bacteria 1 max 
		Vector2 max1 = Camera.main.ViewportToWorldPoint (new Vector2 (0.3f,1.0f)); 

		//bacteria 2 min
		//Vector2 min2 = Camera.main.ViewportToWorldPoint (new Vector2 (0.3f, 0.0f)); 

		//bacteria 2 max 
		//Vector2 max2 = Camera.main.ViewportToWorldPoint (new Vector2 (0.5f,1.0f)); 

		//bacteria 3 min
		//Vector2 min3 = Camera.main.ViewportToWorldPoint (new Vector2 (0.5f, 0.0f)); 
	
		//bacteria 3 max 
		//Vector2 max3 = Camera.main.ViewportToWorldPoint (new Vector2 (0.7f,1.0f)); 

		//bacteria 4 min
		//Vector2 min4 = Camera.main.ViewportToWorldPoint (new Vector2 (0.7f, 0.0f)); 

		//bacteria 4 max 
		//Vector2 max4 = Camera.main.ViewportToWorldPoint (new Vector2 (0.9f,1.0f)); 



		//Instantiate bacteria
		//Instantiate (Bacteria); 
		//Bacteria.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y); 
		GameObject anEnemy= (GameObject)Instantiate (Bacteria);
		//GameObject anEnemy2 = (GameObject)Instantiate (Bacteria1); 
		//GameObject anEnemy3 = (GameObject)Instantiate (Bacteria2); 
		//GameObject anEnemy4 = (GameObject)Instantiate (Bacteria3); 
		anEnemy.transform.position = new Vector2 (Random.Range (min1.x, max1.x), max1.y); 
		//anEnemy2.transform.position = new Vector2 (Random.Range (min2.x, max2.x), max2.y); 
		//anEnemy3.transform.position = new Vector2 (Random.Range (min3.x, max3.x), max3.y);
		//anEnemy4.transform.position = new Vector2 (Random.Range (min4.x, max4.x), max4.y); 


		//Schedule when to spawn next bacteria
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
}
