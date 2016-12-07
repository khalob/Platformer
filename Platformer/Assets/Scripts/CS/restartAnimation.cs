using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartAnimation : MonoBehaviour {
	
	public float nSeconds = 3;
	public Animator anim;
	private float curTime = 0f;

	// Use this for initialization
	public void resetAndPlay () {
		anim.Play("Text", -1, 0f);
		curTime = 0f;
    }

	void Update(){
		curTime += Time.deltaTime;
		if(curTime>=nSeconds){
			gameObject.SetActive (false);
		}
	}
}
