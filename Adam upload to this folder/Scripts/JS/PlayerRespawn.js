#pragma strict
var Player : GameObject; //main character
var spawnPoint : Transform;
var audioSource : AudioSource;
var deathSound : AudioClip;

private var tempHP : int = 0;

function OnTriggerEnter2D(other : Collider2D){
	if(other.tag == "Player"){
		audioSource.PlayOneShot(deathSound, deathSound.length);
		tempHP = Health.hp-1;
		Destroy(other.gameObject);
		var P : GameObject = Instantiate(Player, spawnPoint.position, Quaternion.identity);
		var sf = Camera.main.GetComponent(SmoothFollow);
		sf.target = P.transform;
		Health.hp = tempHP;
	}
}
