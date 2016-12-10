using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
	private bool alreadyTriggered = false;
	public AudioClip triggerSound;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player") && !alreadyTriggered){
			GameControl.control.collectedCollectables++;
			alreadyTriggered = true;
			gameObject.GetComponent<AudioSource>().PlayOneShot (triggerSound);
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			Destroy (gameObject, triggerSound.length);
		}
	}

}
