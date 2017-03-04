using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
	public GameObject mainChara;
	public GameObject tobeChild;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D c)
	{
		Debug.Log ("entered trigger extra");
		if (c.gameObject.name == "colliderobjects") {//if it triggers contact with player, player will become the parent of this object
			tobeChild.transform.SetParent (mainChara.transform);
//		}else {
//			Vector2 fromM = new Vector2 (startLx, startLy); //starts here
//			Vector2 toM = new Vector2 (endLx, endLy); //goes to here and loops
//
//			transform.position = Vector2.Lerp (fromM, toM, Mathf.PingPong (Time.time * speed, 2));
		}
	}
}
