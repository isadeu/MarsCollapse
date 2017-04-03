using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followerScript : MonoBehaviour {

	//moving behind
	Rigidbody2D rb;
	public GameObject follower;
	public GameObject mainChara;
	public List<Vector2> pointList;
	//beforefollowing
	bool following = false;
	public float startLx;
	public float startLy;
	public float endLx;
	public float endLy;
	public float speed;
	//delay
	bool delay;
	public float WaitTime = .3f;
	//anim
	Animator anim;
	public bool movingRight;
	public bool movingLeft;
	public SpriteRenderer sprite;

	void Start () {

		rb = GetComponent<Rigidbody2D> ();	
		anim = GetComponent<Animator> ();
		sprite = GetComponent<SpriteRenderer> ();

	}



	// Update is called once per frame
	void Update () {
		
		//keep from rolling
		transform.rotation = Quaternion.identity;

		//when not following
		if (following == false){
			Vector2 fromM = new Vector2 (startLx, startLy); //starts here
			Vector2 toM = new Vector2 (endLx, endLy); //goes to here and loops
			transform.position = Vector2.Lerp (fromM, toM, Mathf.PingPong (Time.time * speed, 2));
		}


//		//delay supposedly
//		 StartCoroutine(smallDelay());
//	}
//
//	IEnumerator smallDelay() {
//		print(Time.time);
//		yield return new WaitForSeconds(3f);
//		print(Time.time);
		//ja està
	}


	void FixedUpdate () {

		if (following == true){
			gameObject.layer = LayerMask.NameToLayer("following");
			pointList.Add (mainChara.transform.position);
			StartCoroutine ("FollowerDelay");
		
		}


		//amnimations

		//sprite flipx
		if (following == true && Input.GetKey (KeyCode.RightArrow)) {
			sprite.flipX = false;
		}

		if (following == true && Input.GetKey (KeyCode.LeftArrow)) {
			sprite.flipX = true;
		}



		float goDir = 0;
		if (Input.GetKey(KeyCode.LeftArrow)) { 
			//goDir--;
			movingLeft = true;
			anim.SetBool ("nothing", false);
			//movingRight = false;
			//anim.SetBool ("following", true);
		} else {
			movingLeft = false;
		}


		if (Input.GetKey (KeyCode.RightArrow)) {
			goDir++;
			movingRight = true;
			anim.SetBool ("nothing", false);
		} else {
			movingRight = false;
		}

		if (!Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) {

			//anim.SetBool ("following", true);
			anim.SetBool ("moving Right", false);
			anim.SetBool ("nothing", true);
		} else { 
			anim.SetBool ("nothing", false);
		}



		if (movingLeft == true) {
			//anim.SetBool ("moving Left", true);
			anim.SetBool ("moving Right", false);
			//sprite.flipX = true;
		}

		if (movingRight == true) {
			//anim.SetBool ("moving Left", false);
			anim.SetBool ("moving Right", true);
		}

	}

	IEnumerator FollowerDelay (){
		yield return new WaitForSeconds (WaitTime);
		rb.position = pointList [0];
		pointList.RemoveAt (0);
		rb.isKinematic = true;
	}

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "colliderobjects") {//if it triggers contact with player, player will become the parent of this object
			following = true;
			anim.SetBool ("following", true);
		}
	}
}

//jump back to me b; the problem 
//		if (mainChara.position	 + 3) {
//			transform.position = Vector2.Lerp (mainChara.position);