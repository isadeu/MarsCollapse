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
	public float startLx = .2f;
	public float startLy = .86f;
	public float endLx = -.4f;
	public float endLy = .86f;
	public float speed = .5f;
	//delay
	bool delay;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
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
//		yield return new WaitForSeconds(10);
//		print(Time.time);
		//ja està
	}


	void FixedUpdate () {

		if (following == true){
			gameObject.layer = LayerMask.NameToLayer("following");
		pointList.Add (mainChara.transform.position);
		rb.position = pointList [0];
		pointList.RemoveAt (0);
		}
	}

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "colliderobjects") {//if it triggers contact with player, player will become the parent of this object
			Debug.Log ("entered trigger god bless");
			following = true;
		}
	}
}

