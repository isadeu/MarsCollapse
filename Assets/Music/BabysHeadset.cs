using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BabysHeadset : MonoBehaviour {

//	public AudioMixerSnapshot Master;
//	public AudioMixerSnapshot Shh;
//	public AudioClip[] rand;
//	public AudioSource randSource;
//	public float bpm = 128; //tempo?? //23
//
//
//	private float mTransitionIn;
//	private float mTransitionOut; //millis fade
//	private float mQuarterNote; 
//
//
//	// Use this for initialization
//	void Start () {
//
//		mQuarterNote = 60 / bpm;
//		mTransitionIn = mQuarterNote;
//		mTransitionOut = mQuarterNote * 32;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//
//	void OnTriggerEnter (Collider c){
//		if (c.CompareTag ("audio")) {
//			Master.TransitionTo (mTransitionIn);
//		}
//	}
//
//
////	void OnTriggerExit (Collider c){
////		if (c.CompareTag ("audio")){
////			Shh.TransitionTo (mTransitionOut);
////		}
////	}
//}

	public AudioClip headsetSnd;
	public AudioSource source;

	void Awake(){
		source = GetComponent <AudioSource> ();
	}

	void Update (){
	}

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "colliderground"){
			Debug.Log ("music collider");
			source.PlayOneShot (headsetSnd, 1f);
	}
	}
}