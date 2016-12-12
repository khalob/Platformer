using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")){
			int	 i = SceneManager.GetActiveScene().buildIndex;
			if ((i + 1) < SceneManager.sceneCountInBuildSettings) {
				SceneManager.LoadScene (i + 1);
			} else {
				SceneManager.LoadScene (0);
			}
		}
	}
}
