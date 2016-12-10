using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartAnimation : MonoBehaviour {
	
	public Animator anim;

	public void resetAnimation() {
		StartCoroutine("Wait");
    }

	public void startAnimation(){
		anim.SetBool ("Active", true);
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(1f);
		anim.SetBool ("Active", false);
	}
}
