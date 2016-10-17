using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class GameScore : MonoBehaviour {

	Text scoreTextUI; 

	int score; 

	public int Score {
	
		get { 
			return this.score; 
					
		}
		set {
		 
			this.score = value; 
			UpdateScoreTextUI (); 
		}

	}

	// Use this for initialization
	void Start () {

		//Get text UI component of Game Object
		scoreTextUI = GetComponent<Text> (); 
	
	}


	//Function to update score text
	void UpdateScoreTextUI() {
	
		string scoreStr = string.Format ("{0:00000}", score); 
		scoreTextUI.text = scoreStr; 
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
