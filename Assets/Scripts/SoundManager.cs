using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {



		void Start()
		{
			//Create the audio source 

			//Load the audio clip
		}

		//The public function we will use to call to play the sound
		public void PlayHitSound()
		{
			//Play the sound
		gameObject.GetComponent<AudioSource>().Play();

		}
	}