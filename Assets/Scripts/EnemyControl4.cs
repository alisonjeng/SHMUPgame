using UnityEngine;
using System.Collections;

public class EnemyControl4 : MonoBehaviour {

	float speed; //bacteria4 speed

	GameObject scoreUITextGO; //Reference to text UI game object 

	// Use this for initialization
	void Start () {

		speed = 3f; 

		//Get score text UI 
		scoreUITextGO = GameObject.FindGameObjectWithTag ("ScoreTextTag"); 

	}

	// Update is called once per frame
	void Update () {

		//Bacteria4 current position 
		Vector2 position = transform.position; 

		//Compute bacteria4 new position
		position = new Vector2 (position.x, position.y - speed * Time.deltaTime); 

		//Update bacteria4 position 
		transform.position = position; 

		//bottom left of the screen 
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//if bacteria4 goes outside the screen, then destroy it 
		if (transform.position.y < min.y) {

			Destroy (gameObject);
		}

	}

	void OnTriggerEnter2D (Collider2D col) {

		//detect collision between enemy with player bullet
		if ((col.tag == "PlayerBulletTag")) {

			GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayHitSound();

			//Add 10 points when enemy is shot
			scoreUITextGO.GetComponent<GameScore>().Score +=10; 

			//Destroy enemy
			Destroy (gameObject); 
		}
	}
}
