using UnityEngine;
using System.Collections;

public class EnemyControl1 : MonoBehaviour {

	GameObject scoreUITextGO; //Reference to text UI game object 

	float speed; //bacteria1 speed

	public Material mat; 


	// Use this for initialization
	void Start () {

		speed = 3f; 
	
		//Get score text UI 
		scoreUITextGO = GameObject.FindGameObjectWithTag ("ScoreTextTag"); 
	}
	
	// Update is called once per frame
	void Update () {
	
	//Bacteria1 current position 
		Vector2 position = transform.position; 

	//Compute bacteria1 new position
		position = new Vector2 (position.x, position.y - speed * Time.deltaTime); 

	//Update bacteria1 position 
		transform.position = position; 

		//bottom left of the screen 
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//if bacteria1 goes outside the screen, then destroy it 
		if (transform.position.y < min.y) {

			Destroy (gameObject);
		}

	}


	void OnTriggerEnter2D (Collider2D col) {

		//detect collision between enemy with player bullet
		if ((col.tag == "PlayerBulletTag")) {

			gameObject.GetComponent<AudioSource>().Play();

			//Subtract 5 points when enemy is shot
			scoreUITextGO.GetComponent<GameScore>().Score-= 5; 

			//Make bacteria smaller >> still resistant 
			transform.localScale = new Vector2 (0.1f, 0.1f); 

			//Change color of gameobject >> Resistant bacteria 
			this.GetComponent<Renderer>().material = mat; 
		}
	}


}
