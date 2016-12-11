using UnityEngine;
using System.Collections;

public class DieAfterNSeconds : MonoBehaviour {

	public float nSeconds = 5;
	private float curTime = 0f;

	void Update () {
		curTime += Time.deltaTime;
		if(curTime>=nSeconds){
			Destroy(gameObject);
		}
	}
}
