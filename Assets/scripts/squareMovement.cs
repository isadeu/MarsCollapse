﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class squareMovement : MonoBehaviour {
	//movement
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
	bool playerInTrigger = false;
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
	//public AudioClip bkgSnds;
	// text
//	string[] dialogueLine = new string[3];
//	public Text dText;
//	public GameObject dBox;
//	public GameObject npcTalking;


	//public float jumoAggro;
	//anim
	Animator anim;
	public bool movingRight;
	public bool movingLeft;
	public bool moving;

	public SpriteRenderer sprite; //for the sprite flipX

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

		if (Input.GetKeyDown (jumpButton)) 
		{
			jumpFlag = true;
		}
			
	

		//npc text interaction
//		if (Input.GetKeyDown (KeyCode.A)) { //supposedly click A = npc text cancel
//
//			if (playerInTrigger) { //if the player is within the npc trigger:
//				if (Input.GetKeyDown (KeyCode.A)) {
//					currentNPC.PlayerCancel ();
//				}
//			}
//
//		}

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
		if (Input.GetKey (left)) { 
			goDir--;
			movingLeft = true;
			movingRight = false;
			anim.SetBool ("moving", true);
		} else {
			movingLeft = false;
		}


		if (Input.GetKey (right)) {
			goDir++;
			movingRight = true;
			movingLeft = false;
			anim.SetBool ("moving", true);
		} else {
			movingRight = false;
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
//			if (Mathf.Abs (rb.velocity.x) > 0) {//no
				rb.AddForce (Vector2.left * floorDrag * Mathf.Sign (rb.velocity.x) * Mathf.Pow (rb.velocity.x, 2));
//			} else {//no
//				rb.AddForce (Vector2.right * airFoce * goDir);//no

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
		//still on movement
		onFloor = true;
		floorObjcts++;

//		//npc text interaction
//		if (c.gameObject.tag == "NPCs") {
//			Debug.Log ("entered trigger");
//			currentNPC = c.gameObject.GetComponent<npcText> ();
//			c.gameObject.GetComponent<npcText> ().TalkToPlayer ();
//
//			playerInTrigger = true;
//		}

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

		if (c.gameObject.tag == "exit") {
			source.PlayOneShot (shimmer, .9f);
			//HeadsetSound.volume = Mathf.Lerp (6f, 0f, 2f);
		}
	}


	void OnTriggerExit2D(Collider2D collisions){
		floorObjcts--;
		if (floorObjcts <= 0) {
			onFloor = false;
		}

		//npc text interaction
//		if (collisions.gameObject.tag == "NPCs") {
//			playerInTrigger = false;
//
//
//		}
//	

	}


	//sound
//	public void PlaySound()
//	{
//		Sound.me.PlaySound (bkgSnds, 1f);
//		//audioSource.Play();
//	}

}

