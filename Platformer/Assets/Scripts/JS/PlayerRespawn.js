#pragma strict
var Player : GameObject; //main character
var spawnPoint : Transform;
var smallPlatform : GameObject; //small falling platform
var platformPosition;
var currentPos;
private var tempHP : int = 0;

function OnTriggerEnter2D(other : Collider2D){
	if(other.tag != "smallPlatform" && other.tag != "Player"){
		Destroy(other.gameObject);
	}
	
	if(other.tag == "Player"){
		tempHP = Health.hp-1;
		var P : GameObject = Instantiate(Player, spawnPoint.position, Quaternion.identity);
		var sf = Camera.main.GetComponent(SmoothFollow);
		sf.target = P.transform;
		Destroy(other.gameObject);
		Health.hp = tempHP;
	}
	
}

