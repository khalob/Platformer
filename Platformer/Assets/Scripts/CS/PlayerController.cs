using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.5f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	public bool doubleJumpEnabled = false;

	private bool doubleJump = false;
	public bool usingMobileControls = false;
	public float curMove = 0;

	void Start () {
		anim = GetComponent<Animator>();
		GameControl.control.player = gameObject; //GameControl needs to know the new player object
	}

	void FixedUpdate () {
		if (!GameControl.control.Paused) {
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
			anim.SetBool ("Ground", grounded);

			if (doubleJumpEnabled && grounded)
				doubleJump = false;
			
			anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);
			float move = 0;
			if (!usingMobileControls) {
				move = Input.GetAxis ("Horizontal");
			} else {
				foreach (Touch touch in Input.touches){
					int id = touch.fingerId;

					string curPressName= "";
					if(ExtendedStandaloneInputModule.GetPointerEventData (id).pointerPress != null){
						curPressName = ExtendedStandaloneInputModule.GetPointerEventData (id).pointerPress.name;
					}

					if (curPressName == "Left") {
						move = -1;
					} else if (curPressName == "Right") {
						move = 1;
					} 
				}
					
			}
			PlayerMove (move);
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Update(){
		PlayerJump (false);
	}

	public void PlayerJump(bool mobileJump){
		if (!GameControl.control.Paused) {
			if ((grounded || (doubleJumpEnabled && !doubleJump)) && (Input.GetButtonDown ("Jump") || mobileJump)) {
				gameObject.GetComponent<AudioSource>().Play();
				anim.SetBool ("Ground", false);
				GetComponent<Rigidbody2D> ().velocity = Vector2.zero; //remove current force (so that double jump isn't multiplied)
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce)); //add vertical jump force

				if (doubleJumpEnabled && !doubleJump && !grounded)
					doubleJump = true;
			}
		}
	}

	public void PlayerMove(float move){
		anim.SetFloat ("Speed", Mathf.Abs (move));
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

}
