using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEffect : MonoBehaviour {

	public float speed;
	public float dist;

	private bool goingUp;

	private float Y;

	void Start(){
		Y = gameObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		if (Y < gameObject.transform.position.y - dist) {
			goingUp = false;
		}

		if (Y > gameObject.transform.position.y + dist) {
			goingUp = true;
		}

		if(goingUp){
			gameObject.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y + speed); 
		}else{
			gameObject.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y - speed); 
		}
	}
}
