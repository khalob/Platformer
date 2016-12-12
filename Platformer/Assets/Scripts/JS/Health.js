#pragma strict
import UnityEngine.SceneManagement;

static var hp : int = 4;
private var temp = 4;

function Update () {
	if(temp != hp){
		temp = hp;
		check();
	}
	if(hp == 0){
		//end level (play the continue or quit screen here
		//the restart the whole level
		hp = 4;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

function check(){
	var AT = gameObject.GetComponent(AnimateTexture);
	if(hp == 4){
		AT.rowNumber = 4; 
	}else if(hp == 3){
		AT.rowNumber = 3; 
	}else if(hp == 2){
		AT.rowNumber = 2; 
	}else if(hp == 1){
		AT.rowNumber = 1; 
	}else if(hp == 0){
		AT.rowNumber = 0; 
	}
}