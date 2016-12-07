using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public GameObject spawnPoint;
	public GameObject checkpointText;

	private bool firstTime = true;

	public void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player" && firstTime == true){
			firstTime = false;
			spawnPoint.transform.position = new Vector3(transform.position.x, transform.position.y, spawnPoint.transform.position.z);
			checkpointText.SetActive(true);
			checkpointText.GetComponent<restartAnimation>().resetAndPlay();
			Destroy(gameObject);
		}
	}	
}
