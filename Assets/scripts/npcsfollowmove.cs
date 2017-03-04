using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcsfollowmove : MonoBehaviour {
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
//	public float moveDeadzone;
//	public float stopForce;
//	bool yesDrag = (true);
	//following
	bool following = (false);
	public GameObject mainChara;
	public GameObject tobeChild;
	//non-following movement
	public float startLx = .2f;
	public float startLy = .86f;
	public float endLx = -.4f;
	public float endLy = .86f;
	public float speed = .5f;
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		jumpButton = KeyCode.Space;
		left = KeyCode.LeftArrow;
		right = KeyCode.RightArrow;

	}

	// Update is called once per frame
	void Update () {
		//keep from rolling
		transform.rotation = Quaternion.identity;

		//non-following movement
		if (following == false){
			Vector2 fromM = new Vector2 (startLx, startLy); //starts here
			Vector2 toM = new Vector2 (endLx, endLy); //goes to here and loops
			transform.position = Vector2.Lerp (fromM, toM, Mathf.PingPong (Time.time * speed, 2));}


		if (following == true && Input.GetKeyDown (jumpButton)) 
		{
			jumpFlag = true;
		}

	}		

	void FixedUpdate ()
	{
		if (following == true && jumpFlag && onFloor) {
			rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);	
		}

		if (following == true && !Input.GetKey (jumpButton) && rb.velocity.y >= 0) {// ! = not

			rb.velocity = new Vector2 (rb.velocity.x, Mathf.Lerp (rb.velocity.y, 0, .25f));
			// linear: rb.velocity = new Vector2 (rb.velocity.x, Mathf.Max(rb.velocity.y - jumpAggro, 0);
		}

		float goDir = 0;
		if (following == true && Input.GetKey (left)) {goDir--;
		}
		if (following == true && Input.GetKey (right)) {goDir++;
		}
		if (following == true && onFloor) {
			rb.AddForce (Vector2.right * floorForce * goDir);
			//			if (Mathf.Abs (rb.velocity.x) > 0) {//no
			rb.AddForce (Vector2.left * floorDrag * Mathf.Sign (rb.velocity.x) * Mathf.Pow (rb.velocity.x, 2));
			//			} else {//no
			//				rb.AddForce (Vector2.right * airFoce * goDir);//no

			//drift prevention only after start 
//			if (following == true && goDir == 0 && yesDrag == true) {
//				if (Mathf.Abs (rb.velocity.x) < moveDeadzone) {
//					rb.velocity = new Vector2 (0, rb.velocity.y);
//				} else {
//					rb.AddForce (Vector2.left * Mathf.Sign (rb.velocity.x) * stopForce);
//				}


			jumpFlag = false;
		}
	}
	//follow script
	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "colliderobjects") {//if it triggers contact with player, player will become the parent of this object
			tobeChild.transform.SetParent (mainChara.transform);
			following = true;
		}
		//movement
		onFloor = true;
		floorObjcts++;
	}

	void OnTriggerExit2D(Collider2D collisions)
	{
		floorObjcts--;
		if (following == true && floorObjcts <= 0) {
			onFloor = false;
		}

	}


}
