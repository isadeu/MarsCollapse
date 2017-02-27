using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : MonoBehaviour {
//	public GameObject tobeChild;
//	public GameObject mainChara;

	public float startLx = .2f;
	public float startLy = .86f;
	public float endLx = -.4f;
	public float endLy = .86f;
	public float speed = .5f;
	bool moving;

	void Start(){
		moving = (true);
	}
	void Update() {

		if (moving = true) {
			Vector2 fromM = new Vector2 (startLx, startLy); //starts here
			Vector2 toM = new Vector2 (endLx, endLy); //goes to here and loops
			transform.position = Vector2.Lerp (fromM, toM, Mathf.PingPong (Time.time * speed, 2));//mlem the two is how many numbers it will be looking for (xy)
	
		} 

	}

	void OnTriggerEnter2D (Collider2D c)
	{
		Debug.Log ("entered trigger extra");
		moving = false;
//		if (c.gameObject.name   == "colliderobjects") {//if it triggers contact with player, player will become the parent of this object
//			tobeChild.transform.SetParent(mainChara.transform);
//
//		}
	
	}
}   