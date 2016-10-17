using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject Startpage;
	public GameObject Player;
	public GameObject Endpage; 
	public GameObject EnemySpawner00;
	public GameObject EnemySpawner01;
	public GameObject EnemySpawner02;
	public GameObject EnemySpawner03;
	public GameObject EnemySpawner04;
	public GameObject scoreUITextGO; //Reference to UI text

	public enum GameManagerState
	{
		Start,
		Play,
		End,
	}

	GameManagerState GMState; 


	// Use this for initialization
	void Start () {
		Endpage.SetActive (false); 
		Player.SetActive (false); 
		Startpage.SetActive (true); 
		GMState = GameManagerState.Start;


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("s")) {
			GetComponent<GameManager> ().SetGameManagerState (GameManager.GameManagerState.Play); 
		
		}
	
	}

	void UpdateGameManagerState() {
		switch (GMState) {

		case GameManagerState.Start:
			Endpage.SetActive (false); 
			Startpage.SetActive (true);
			Player.SetActive (false); 
			break; 

		case GameManagerState.Play:
			Startpage.SetActive (false);
			Player.SetActive (true); 

			//Reset the score
			scoreUITextGO.GetComponent<GameScore>().Score = 0; 

			//Initiate lives when play starts
			Player.GetComponent <PlayerControl>().Init(); 

			EnemySpawner00.GetComponent<EnemySpawner00>().ScheduleEnemySpawner00(); 
			EnemySpawner01.GetComponent<EnemySpawner01>().ScheduleEnemySpawner01();
			EnemySpawner02.GetComponent<EnemySpawner02>().ScheduleEnemySpawner02();
			EnemySpawner03.GetComponent<EnemySpawner03>().ScheduleEnemySpawner03();
			EnemySpawner04.GetComponent<EnemySpawner04>().ScheduleEnemySpawner04();

			break; 

		case GameManagerState.End:
			Startpage.SetActive (false); 
			Player.SetActive (false); 
			Endpage.SetActive (true); 

			//Stop enemy Spawner
			EnemySpawner00.GetComponent<EnemySpawner00>().UnScheduleEnemySpawner00(); 
			EnemySpawner01.GetComponent<EnemySpawner01>().UnScheduleEnemySpawner01();
			EnemySpawner02.GetComponent<EnemySpawner02>().UnScheduleEnemySpawner02();
			EnemySpawner03.GetComponent<EnemySpawner03>().UnScheduleEnemySpawner03();
			EnemySpawner04.GetComponent<EnemySpawner04>().UnScheduleEnemySpawner04();

			//Change game manager to opening state after 8 seconds 
			Invoke ("ChangeToStartState", 8f); 

			
			break; 



		}


	}

	public void SetGameManagerState (GameManagerState state) {
		GMState = state; 
		UpdateGameManagerState ();
	
	}

	public void StartGamePlay() {
		UpdateGameManagerState ();
	
	}

	//Function to change game to opening state
	public void ChangeToStartState() {
	
		SetGameManagerState (GameManagerState.Start); 
	
	}

}
