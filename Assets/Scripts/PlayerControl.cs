using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.Audio; 
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public GameObject GameManagerGO; 


	public GameObject PlayerBullet; //player bullet prefab
	public GameObject BulletPosition01;
	//public GameObject SyringeHit; //collision prefab 

	//Reference to lives ui text
	public Text TextLives; 

	const int MaxLives = 4; //max player lives
	int lives; //current player lives 

	public float speed; 

	public void Init() {

		lives = MaxLives;

		//update lives UI text
		TextLives.text = lives.ToString (); 

		//set player gameobject to active
		gameObject.SetActive(true); 

		//reset position to center of screen
		transform.position = new Vector2 (0,-20); 
	}


	// Use this for initialization
	void Start () {

	
	
	}
	
	// Update is called once per frame
	void Update () {

		//fire bullets when spacebar is pressed
		if (Input.GetKeyDown ("space")) {

			//play shooting sound
			gameObject.GetComponent<AudioSource>().Play(); 


			//Start the first bullet
			GameObject bullet01 = (GameObject)Instantiate(PlayerBullet); //instantiate = returns a copy of the object original (similar to duplicate)
			bullet01.transform.position = BulletPosition01.transform.position; //set bullet initial position


		}
	
		float x = Input.GetAxisRaw("Horizontal");//the value will be -1, 0, or 1 (for left, no input, and right) 
		float y = Input.GetAxisRaw("Vertical"); //the value will be -1, 0, or 1 (for down, no input, and up) 

		//Direction vector >> unit vector
		Vector2 direction = new Vector2(x,y).normalized; 

		//Call function that computes and sets player's position 
		Move (direction); 
	}

	void Move(Vector2 direction){

		//Find the screen limits to the player's movement (left, right, top, bottom edges of screen)
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0)); //bottom left corner
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1)); //top right corner 

		max.x = max.x - 0.403f; //subtract the player sprite half width
		min.x = min.x + 0.403f; //add player sprite half width 

		max.y = max.y - 1.00f;//subtract the player sprite half height
		min.y = min.y + 1.00f; //add the player sprite half height

		//Player's current position
		Vector2 pos = transform.position; 

		//Calculate new position
		pos += direction * speed * Time.deltaTime; 

		//New position isn't outside of screen
		pos.x= Mathf.Clamp(pos.x, min.x, max.x); 
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		//Update position
		transform.position = pos; 

	}

	void OnTriggerEnter2D (Collider2D col) {

		//detect collision between enemy with player bullet
		if ((col.tag == "EnemyTag")) {

			//PlayExplosion (); 

			lives--; //subtract one life
			TextLives.text = lives.ToString (); //update UI text

			if (lives == 0) {
				//change game manager state to game over state
				GameManagerGO.GetComponent<GameManager> ().SetGameManagerState (GameManager.GameManagerState.End);
				//Destroy enemy
				//Destroy (gameObject); 

				//hide game object
				gameObject.SetActive (false); 
			}
		}
	}

		//Function to instantiate collision explosion
		/*void PlayExplosion() {

	
			GameObject explosion = (GameObject) Instantiate (SyringeHit); 

			explosion.transform.position = transform.position; 
		
		}*/


	
}
