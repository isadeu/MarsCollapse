﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcsfollowmove : MonoBehaviour {
	Rigidbody2D rb;
	public float jumpForce;
	public float floorDrag;
	public float airDrag;
	public float floorForce;
	public float airFoce;
	bool jumpFlag;
	bool onFloor;
	int floorObjcts;
	public float moveDeadzone;
	public float stopForce;
	KeyCode jumpButton;
	KeyCode left;
	KeyCode right;
	//public Texture PauseTexture;

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

		if (Input.GetKeyDown (jumpButton)) 
		{
			jumpFlag = true;
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
		if (Input.GetKey (left)) {goDir--;
		}
		if (Input.GetKey (right)) {goDir++;
		}
		if (onFloor) {
			rb.AddForce (Vector2.right * floorForce * goDir);
			//			if (Mathf.Abs (rb.velocity.x) > 0) {//no
			rb.AddForce (Vector2.left * floorDrag * Mathf.Sign (rb.velocity.x) * Mathf.Pow (rb.velocity.x, 2));
			//			} else {//no
			//				rb.AddForce (Vector2.right * airFoce * goDir);//no

			//drift prevention
			if (goDir == 0) {
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


	}

	void OnTriggerExit2D(Collider2D collisions)
	{
		floorObjcts--;
		if (floorObjcts <= 0) {
			onFloor = false;

		}
	}


}