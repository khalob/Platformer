using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour {
	private float Xpos;
	private float Ypos;
	private bool max;
	private float elaspeTime;

	public bool Vert;
	public bool Timelimit;
	public float time;
	public float maxAmount;
	public float step;

	void Start () {
		Xpos = gameObject.transform.position.x;
		Ypos = gameObject.transform.position.y;
	}

	void Update () {
		if(!GameControl.control.Paused){
			if(Timelimit){
				elaspeTime += Time.deltaTime;
			}else {
				time = 0;
			}

			if(elaspeTime >= time){
				//Set the max
				if(Vert){//Vertical
					if(gameObject.transform.position.y >= Ypos + maxAmount){
						max = true;
						elaspeTime = 0;
					}else if(gameObject.transform.position.y <= Ypos){
						max = false;
						elaspeTime = 0;
					}
				}else{ //Horizontal
					if(gameObject.transform.position.x >= Xpos + maxAmount){
						max = true;
						elaspeTime = 0;
					}else if(gameObject.transform.position.x <= Xpos){
						max = false;
						elaspeTime = 0;
					}
				}

				//Moving the platform!
				if(Vert){ //Vertical movement
					if(!max){
						gameObject.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y + step); 
					}else{
						gameObject.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y - step); 
					}
				}else{ //Horizontal movement
					if(!max){
						gameObject.transform.position = new Vector2 (gameObject.transform.position.x + step, gameObject.transform.position.y); 
					}else{
						gameObject.transform.position = new Vector2 (gameObject.transform.position.x - step, gameObject.transform.position.y); 
					}
				}
			}
		}
	}
}