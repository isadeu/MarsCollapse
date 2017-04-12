using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicGalSit : MonoBehaviour {
	
	Rigidbody2D rb;
	public GameObject follower;
	public GameObject mainChara;
	public List<Vector2> pointList;
	//beforefollowing
	bool following = false;

	bool delay;
	public float WaitTime = .3f;

	//animations
	Animator anim;
	public bool movingRight;
	public bool movingLeft;
	public SpriteRenderer sprite;
	public ParticleSystem particules;
	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D> ();	
		anim = GetComponent<Animator> ();
		sprite = GetComponent<SpriteRenderer> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.rotation = Quaternion.identity;
		
	}

	void FixedUpdate () {

		//following
		if (following == true){
			//confettii.Emit (1);
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
			particules = GetComponent<ParticleSystem> ();
			//particules.Play;

		}

	}
}
