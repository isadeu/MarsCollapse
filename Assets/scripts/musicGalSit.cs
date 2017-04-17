using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicGalSit : MonoBehaviour {
	
	Rigidbody2D rb;
	public GameObject follower;
	public GameObject mainChara;
	public List<Vector2> pointList;
	//beforefollowing
	public bool following = false;
	//public bool pausing = false;

	bool delay;
	public float WaitTime = .3f;
	public GameObject buddy;
	public float beginFollow = 1f;
	public float dontTouchMe =.1f;
	public Vector2 howFar;

	public float Xdis;
	public float Ydis;
	//public float positionX;

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
//			gameObject.layer = LayerMask.NameToLayer("following");
//			pointList.Add (mainChara.transform.position);
//			StartCoroutine ("FollowerDelay");
		}
	

		//howFar = new Vector2 ((mainChara.transform.position.magnitude) - (buddy.transform.position.magnitude), 0);///((mainChara.transform.position.magnitude) - (buddy.transform.position.magnitude)));//if this works add y

		//Xdis = howFar.x;

		//if (Xdis >= 1f) {
			//following = true; 
			//Debug.Log ("he is too far!");
		//}
		//if (Xdis < 1f) {
		//	following = false;
			//Debug.Log ("stop it");
//		}
			

//		if
//			((buddy.transform.position.magnitude) - (mainChara.transform.position.magnitude) > beginFollow){
//			following = true;
//			Debug.Log ("he is too far!");
//		} //else { 
//		//following = false;
//		//	}
//		if ((buddy.transform.position.magnitude) - (mainChara.transform.position.magnitude) < dontTouchMe) {
//			following = false;
//			Debug.Log ("stop it");
//k		}



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

//	void OnTriggerEnter2D (Collider2D c){
//		if (c.gameObject.name == "colliderobjects") {//if it triggers contact with player, player will become the parent of this object
//			following = true;
//			anim.SetBool ("following", true);
//			//particules.Play;
//
//		}

//		if (c.gameObject.name == "dontTouchMe"){ //&& following == true) {
//			Debug.Log ("noticed stop collider");
//			//rb.position + Vector2.one;
//		//}else{ rb.position = pointList [0];
//			pausing = true;
//			following = false;

			//StartCoroutine ("LetaBoyBreathe");
			//rb.transform.position = new Vector2 (Mathf.Clamp(transform.position.x, Mayydgasi,fbwefe), transform.position.y); 
	
		}
	
	//IEnumerator LetaBoyBreathe(){
//		yield return new WaitForSeconds (.001f);
//		//rb.position = new Vector2(1,1);// Vector2.zero;
//		//rb.velocity = Vector2.zero; 
//
//		if (Input.GetKeyDown (KeyCode.RightArrow)||Input.GetKeyDown (KeyCode.LeftArrow) ||Input.GetKeyDown (KeyCode.Space) ){
//			following = true;
//			yield return 0;
//		}

//	}