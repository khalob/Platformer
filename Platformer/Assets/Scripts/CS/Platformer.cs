using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour {
	
	public bool Vert;
	public bool Timelimit;
	public float time;
	public float maxAmount;
	public float speed = 3f;
	public enum hDirections {Left, Right};
	public enum vDirections {Up, Down};
	public hDirections startingHorizontalDirection = hDirections.Right;
	public vDirections startingVerticalDirection = vDirections.Up;

	private float Xpos;
	private float Ypos;
	private bool max;
	private float elaspeTime;
	private float minY;
	private float minX;
	private float maxY;
	private float maxX;

	void Start () {
		Xpos = gameObject.transform.position.x;
		Ypos = gameObject.transform.position.y;
		if (startingHorizontalDirection == hDirections.Left) {
			minX = Xpos - maxAmount;
			maxX = Xpos;
		} else {
			minX = Xpos;
			maxX = Xpos + maxAmount;
		}
		if (startingVerticalDirection == vDirections.Down) {
			minY = Ypos - maxAmount;
			maxY = Ypos;
		} else {
			minY = Ypos;
			maxY = Ypos + maxAmount;
		}
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
					if(gameObject.transform.position.y >= maxY){
						max = true;
						elaspeTime = 0;
					}else if(gameObject.transform.position.y < minY){
						max = false;
						elaspeTime = 0;
					}
				}else{ //Horizontal
					if(gameObject.transform.position.x >= maxX){
						max = true;
						elaspeTime = 0;
					}else if(gameObject.transform.position.x < minX){
						max = false;
						elaspeTime = 0;
					}
				}

				//Moving the platform!
				if(Vert){ //Vertical movement
					if(!max){
						GetComponent<Rigidbody2D> ().velocity = new Vector2 ( GetComponent<Rigidbody2D> ().velocity.x, speed);
					}else{
						GetComponent<Rigidbody2D> ().velocity = new Vector2 ( GetComponent<Rigidbody2D> ().velocity.x, -speed);
					}
				}else{ //Horizontal movement
					if(!max){
						GetComponent<Rigidbody2D> ().velocity = new Vector2 ( speed, GetComponent<Rigidbody2D> ().velocity.y);
					}else{
						GetComponent<Rigidbody2D> ().velocity = new Vector2 ( -speed, GetComponent<Rigidbody2D> ().velocity.y);
					}
				}
			}
		}
	}
		
}