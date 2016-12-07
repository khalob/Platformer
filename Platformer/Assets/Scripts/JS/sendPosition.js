#pragma strict

var smallPlatform : GameObject;
private var pos : Vector3;
private var currentPos : Vector3;
private var elaspeTime : float;

function Start(){
	pos = transform.position;
}

function Update(){
	currentPos = transform.position;
	if(currentPos.y != pos.y){
	elaspeTime += Time.deltaTime;
		if(elaspeTime >= 1.2){
			Instantiate(smallPlatform, pos, Quaternion.identity);
			Destroy(gameObject);
		}
	}

}
