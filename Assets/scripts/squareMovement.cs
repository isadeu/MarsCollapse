using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	npcText currentNPC;



	//public float jumoAggro;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		jumpButton = KeyCode.Space;
		left = KeyCode.LeftArrow;
		right = KeyCode.RightArrow;

	}
	
	// Update is called once per frame
	void Update () {
		//level boundaries
		if (transform.position.x > 6) {
			Application.LoadLevel ("GameOver");
			Application.Quit();
		}
		if (transform.position.y < -1f) {
			Application.LoadLevel ("GameOver");
			Application.Quit ();
		}

		if (Input.GetKeyDown (jumpButton)) 
		{
			jumpFlag = true;
		}
			
	

		//npc text interaction
		if (Input.GetKeyDown (KeyCode.A)) { //supposedly click A = npc text cancel

			if (playerInTrigger) { //if the player is within the npc trigger:
				if (Input.GetKeyDown (KeyCode.A)) {
					currentNPC.PlayerCancel ();
				}
			}

		}

	}		
		
	void FixedUpdate ()
	{
		if (jumpFlag && onFloor) {
			rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);	
		}

		if (!Input.GetKey (jumpButton) && rb.velocity.y >= 0) {// ! = not
			rb.velocity = new Vector2 (rb.velocity.x, Mathf.Lerp (rb.velocity.y, 0, .25f));
			// linear: rb.velocity = new Vector2 (rb.velocity.x, Mathf.Max(rb.velocity.y - jumpAggro, 0);
		}

		float goDir = 0;
		if (Input.GetKey (left)) {
			goDir--;
		}
		if (Input.GetKey (right)) {
			goDir++;
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
		onFloor = true;
		floorObjcts++;

		//npc text interaction
		if (c.gameObject.tag == "NPCs") {
			Debug.Log ("entered trigger");
			currentNPC = c.gameObject.GetComponent<npcText> ();
			c.gameObject.GetComponent<npcText> ().TalkToPlayer ();

			playerInTrigger = true;
		}

		//critter jump back reaction
		Vector2 force = new Vector2 (10, 5);
		if (c.gameObject.name == "critterCollider") {//if it triggers contact with player, player will become the parent of this object
			rb.AddForce (force, ForceMode2D.Impulse);
		}
			


	}

	void OnTriggerExit2D(Collider2D collisions)
	{
		floorObjcts--;
		if (floorObjcts <= 0) {
			onFloor = false;
		}

		//npc text interaction
		if (collisions.gameObject.tag == "NPCs") {
			playerInTrigger = false;


		}
	}


}
