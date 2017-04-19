using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
public class squareMovement : MonoBehaviour {
	//movement

	/*//public dust systems[] 
	//void oncollisionenter2d (collider2d call)
	//for /int i = 0; i < dustsystems. length; i++){
	//

	// public height 
	public transform sprite
	public floats for basewidth and height ;
	start 
	basewidth = sprite.transfrom.localscale.x;
	baseheight = sprite.transfrom.localscale.y;
	update


/* ultimate movement base

	vector2 moveVect = Vector2.0;
	if(inputrbeifnegetkey)) { moveVect.x += 1;}
	if fieifen right^leftv, then if up down
	moveVect = moveVect.normalized;
	transform.position += moveVect * (* time.deltaTime if u want )speed;
	sprite.transform.localscale = new vector3 (basewidth + 1+ (1-height), y, 0);
	*/

	//Raycast (d, ((d-z).normalized)
	Rigidbody2D rb;
	public float jumpForce;
	public float floorDrag;
	public float airDrag;
	public float floorForce;
	public float airFoce;
	bool jumpFlag;
	bool onFloor;
	int floorObjcts;
	KeyCode jumpButton;
	KeyCode left;
	KeyCode right;

	//drag
	public float moveDeadzone;
	public float stopForce;
	bool yesDrag = (true);

	//npc text interactions
	//npcText currentNPC;

	//falling platforms
	public float fallDelay;
	public GameObject platform;

	//sound
	public AudioClip bbscream;
	public AudioSource source;
	public AudioClip crumble;
	public AudioClip jumpLand;
	public AudioClip shimmer;

	public List<Vector2> pointList;

	//anim
	Animator anim;
	public bool movingRight;
	public bool movingLeft;
	public bool moving;
	//particles 
	public ParticleSystem poofsMRight;
	public ParticleSystem poofsMLeft;
	public ParticleSystem poofsJump;


	/*public void Flahs (float Flashtime){
		flashsprite.gameobject.setactive
	*/

	public SpriteRenderer sprite; //for the sprite flipXç

	//camera
	cameraShake screenshakeScript;

	void Awake (){
		source = GetComponent <AudioSource> ();
	}
	// Use this for initialization
	void Start () {

		sprite = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();

		rb = GetComponent<Rigidbody2D> ();
		jumpButton = KeyCode.Space;
		left = KeyCode.LeftArrow;
		right = KeyCode.RightArrow;

		//text
//		for (int i = 0; i < 3; i++) {
//			dialogueLine [1] = "gneiwnlqkme";
//			dialogueLine [2] = "hhhh";
//			dialogueLine [3] = "ohu";
//		}
//
	}


	
	// Update is called once per frame
	void Update () {

		//wiggleSpd+= (if-height) *2.8f * Time.deltatime;
		//wiggleSpd -= wigglespd *5.8f * Time.deltatime;
		//fixedupdate



		if (Input.GetKeyDown (KeyCode.S)) {
			screenshakeScript.SetScreenshake (.3f, 1f, Vector3.right);
		}

		//stop rotation
		transform.rotation = Quaternion.identity;//so the obejct doesn't tilt

		//level boundaries
		if (transform.position.x > 38.3f) {
			SceneManager.LoadScene ("GameOver");
			//Application.Quit();
		}
		if (transform.position.y < -15f) {
			SceneManager.LoadScene("GameOver");
		}



		if (Input.GetKeyDown (jumpButton)) {
			if (onFloor == true) {
				jumpFlag = true;
				anim.SetBool ("jumping", true);
				poofsMLeft.Pause ();
				poofsMLeft.Clear ();
				poofsMRight.Pause ();
				poofsMRight.Clear ();
			}
		}

		if (Input.GetKeyDown (jumpButton) && onFloor == true) {
			poofsJump.Play ();
		}
			

		if (Input.GetKeyDown (left)&& onFloor == true) {
			//Debug.Log ("listen left and floor buddy");
			//particles
			poofsMLeft.Play ();
			poofsMRight.Stop ();
		}if (Input.GetKeyUp (left)) {
			poofsMLeft.Stop ();
		//} if (!onFloor) {
		//	poofsJump.Stop ();
		}

		if (Input.GetKeyDown (right)&& onFloor == true) {
			//particles
			poofsMRight.Play ();
			//Debug.Log ("do theys top tho");
			poofsMLeft.Stop ();
		}if (Input.GetKeyUp (right)) {
			poofsMRight.Stop ();
		}


	}		
		
	void FixedUpdate ()
	{
		if (jumpFlag && onFloor) {
			rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);	
			source.PlayOneShot (jumpLand, .3f);
		}

		if (!Input.GetKey (jumpButton) && rb.velocity.y >= 0) {// ! = not
			rb.velocity = new Vector2 (rb.velocity.x, Mathf.Lerp (rb.velocity.y, 0, .25f));
			// linear: rb.velocity = new Vector2 (rb.velocity.x, Mathf.Max(rb.velocity.y - jumpAggro, 0);
		
		}

		float goDir = 0;
		//moving left
		if (Input.GetKey (left)) { 
			goDir--;
			movingLeft = true;
			movingRight = false;
			anim.SetBool ("moving", true);
		} else {
			movingLeft = false;
			//poofsMLeft.Stop ();
		}


		//moving right
		if (Input.GetKey (right)) {
			goDir++;
			movingRight = true;
			movingLeft = false;
			anim.SetBool ("moving", true);
		} else {
			movingRight = false;
			//poofsMLeft.Stop ();
		}
	


		if (! Input.GetKey (right) && !Input.GetKey (left)) {

			anim.SetBool ("moving", false);
			anim.SetBool ("moving Right", false);
			anim.SetBool ("moving Left", false);
		}
			

		//animations

		if (movingLeft == true) {
			anim.SetBool ("moving Left", true);
			anim.SetBool ("moving Right", false);
			sprite.flipX = true;
		}
			
		if (movingRight == true) {
			anim.SetBool ("moving Left", false);
			anim.SetBool ("moving Right", true);
			sprite.flipX = false;
		}

	

		if (onFloor) {
			rb.AddForce (Vector2.right * floorForce * goDir);
				rb.AddForce (Vector2.left * floorDrag * Mathf.Sign (rb.velocity.x) * Mathf.Pow (rb.velocity.x, 2));

				//drift prevention only after start 
			if (yesDrag == true && goDir == 0 ) {
					if (Mathf.Abs (rb.velocity.x) < moveDeadzone) {
						rb.velocity = new Vector2 (0, rb.velocity.y);
					} else {
						rb.AddForce (Vector2.left * Mathf.Sign (rb.velocity.x) * stopForce);
					}
		
				}
		
			jumpFlag = false;
		}
			
			
	}

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.layer == LayerMask.NameToLayer("ground")){
			Debug.Log ("only if the gorund buddy");
			Debug.Log (c.name);
	//	gameObject.layer = LayerMask.NameToLayer("following");
		//still on movement
			onFloor = true;
			floorObjcts++;
			Debug.Log ("on the floor");
		}


		//critter jump back reaction
		Vector2 force = new Vector2 (10, 5);
		if (c.gameObject.name == "critterCollider") {
			rb.AddForce (force, ForceMode2D.Impulse);
			source.PlayOneShot (bbscream, .5f);
		}

		//touchdie
		if (c.gameObject.tag == "enemy") {
			SceneManager.LoadScene("GameOver");
			//Application.Quit ();
		}

		//sfx
		if (c.gameObject.tag == "exit") {
			source.PlayOneShot (shimmer, .9f);
		}
			
	}


	void OnTriggerExit2D(Collider2D c){
		if (c.gameObject.layer == LayerMask.NameToLayer ("ground")) {
			floorObjcts--;
			if (floorObjcts <= 0) {
				onFloor = false;
				Debug.Log ("collision is false");
			}
		}


	}

}
