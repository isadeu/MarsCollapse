using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkConnect : MonoBehaviour {
	public AudioClip boyWalk;
	bool walking = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			walking = true;
		}
		
	}


	public void PlayWalkSound()
	{
		Sound.me.PlaySound (boyWalk, .3f);
		//audioSource.Play();
	}
}