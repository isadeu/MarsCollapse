using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
	public GameObject mainChara;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.name   == "sprite") {//if it triggers contact with player, player will become the parent of this object ie.follow
		transform.parent = c.transform;
	}

	}
}

