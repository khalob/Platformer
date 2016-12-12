using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
	public static GameControl control;
	public GameObject pauseMenu;
	public GameObject player;
	public GameObject eventSystem;

	private bool paused = false;
	private bool pausable = true;
	private Vector2 storedVel;
	private float totalCollectables = 0;
	public float collectedCollectables = 0;

	void Awake () {
		//if(control == null){
		//	DontDestroyOnLoad(gameObject);
			collectedCollectables = 0;
			control = this;
		//}else if(control != this){
		//	Destroy(gameObject);
		//}
	}

	void Start(){
		totalCollectables = GameObject.Find("Collectables").transform.childCount;
	}
		
	void Update () {
		if(Input.GetKeyDown(KeyCode.P) && Pausable){
			PauseGame();
		}
	}
	
	public void PauseGame(){
		paused = !paused; //inverts pause to the opposite
		if(paused == true){
			pauseMenu.SetActive(true);
			updateCollectables ();
			storedVel = player.GetComponent<Rigidbody2D> ().velocity;
			player.GetComponent<Rigidbody2D> ().isKinematic = true;
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

			//Sets default option highlight to "no" in pausemenu
			EventSystem es = eventSystem.GetComponent<EventSystem>();
			es.SetSelectedGameObject(null);
			es.SetSelectedGameObject(es.firstSelectedGameObject);
		}else{
			pauseMenu.SetActive(false);
			player.GetComponent<Rigidbody2D> ().isKinematic = false;
			player.GetComponent<Rigidbody2D> ().velocity = storedVel;
		}
	}
	
	public bool Paused{
		get{ return paused;}
		set{ paused = value;}
	}
	
	public bool Pausable{
		get{ return pausable;}
		set{ pausable = value;}
	}

	public void Quit(){
		Application.Quit ();
	}

	//For mobile controls
	public void PlayerJump(){
		if(player != null){
			player.GetComponent<PlayerController> ().PlayerJump (true);
		}
	}	

	public void updateCollectables(){
		pauseMenu.transform.GetChild(1).GetComponent<Text>().text = collectedCollectables + "/" + totalCollectables;
	}
}
