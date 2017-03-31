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

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.rotation = Quaternion.identity;
		
	}

	void FixedUpdate () {

		if (following == true){
			gameObject.layer = LayerMask.NameToLayer("following");
			pointList.Add (mainChara.transform.position);
			StartCoroutine ("FollowerDelay");

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
			Debug.Log ("entered trigger god bless 2 ");
			following = true;
		}
	}
}
