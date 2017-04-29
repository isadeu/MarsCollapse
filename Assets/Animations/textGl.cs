using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textGl : MonoBehaviour {


	public Sprite  [] texts;
	private SpriteRenderer currentSprite;
	private int counter;
	public bool goTexts;
	public GameObject gal;
	public bool onGal;

	public Sprite one;
	public Sprite two;
	public Sprite three; 
	public Sprite four;

	void Start(){
		//goTexts = false;
		counter = 0;
		texts = new Sprite[4];
		texts [0] = one;
		texts [1] = two;
		texts [2] = three;
		texts [3] = four; //transparent

	

		Debug.Log (texts.Length);
		currentSprite = GetComponent <SpriteRenderer> ();
		//texts = new List<Sprite>();
		//counter = 0;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.G)&& goTexts == true){//&& onGal == true) {
			counter++;
			Debug.Log ("code G");
		} 

		if (counter < texts.Length) { //&& goTexts == false) {
			currentSprite.sprite = texts [counter % texts.Length];
			//goTexts = false;
		}

		if (counter > 6) {//texts.Length) {
			currentSprite.sprite = four;
			Debug.Log ("??");
			counter = 0;
			//goTexts = false;
		}
	}


	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "girlCollider") {
			Debug.Log ("gal");
			Destroy (c.gameObject);
			onGal = true;
			goTexts = true;
		}
			



		//spriteRenderer.currentSprite = texts [counter % texts.Length];
		//if (counter > 4 ){
			//Debug.Log ("turnign that shit off");
			//goTexts = true;
		//}
	}

//	void FixedUpdate (){
//		if (counter >= 9) {
//			goTexts = true;}
//	}

		//currentSprite = texts[counter];
		//void OnGUI(){
			//GUI.DrawTexture(r_Sprite,currentSprite);


	
}
//}


// for ( int x = 0; x>10; x++){
//myInt = myInt +x;
//}