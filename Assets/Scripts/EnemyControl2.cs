using UnityEngine;
using System.Collections;

public class EnemyControl2 : MonoBehaviour {

	GameObject scoreUITextGO; //Reference to text UI game object 

	float speed; //bacteria2 speed


	public Material mat; 





	// Use this for initialization
	void Start () {

		speed = 3f; 

		//Get score text UI 
		scoreUITextGO = GameObject.FindGameObjectWithTag ("ScoreTextTag"); 
	}

	// Update is called once per frame
	void Update () {

		//Bacteria2 current position 
		Vector2 position = transform.position; 

		//Compute bacteria2 new position
		position = new Vector2 (position.x, position.y - speed * Time.deltaTime); 

		//Update bacteria2 position 
		transform.position = position; 

		//bottom left of the screen 
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//if bacteria2 goes outside the screen, then destroy it 
		if (transform.position.y < min.y) {

			Destroy (gameObject);
		}

	}
		

	void OnTriggerEnter2D (Collider2D col) {

		//detect collision between enemy with player bullet
		if ((col.tag == "PlayerBulletTag")) {

			gameObject.GetComponent<AudioSource>().Play();

			//Subtract 10 points when enemy is shot
			scoreUITextGO.GetComponent<GameScore>().Score-=10; 

			//Destroy enemy
			//Destroy (gameObject); 

			//Change color of gameobject >> Resistant bacteria 
			this.GetComponent<Renderer>().material = mat; 


		}
	}
}