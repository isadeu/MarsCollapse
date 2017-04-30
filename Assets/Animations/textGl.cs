using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textGl : MonoBehaviour {


	public Sprite  [] texts;
	private SpriteRenderer currentSprite;
	private SpriteRenderer currentSprite2;
	private int counter;
	public bool goTexts;
	public GameObject gal;
	public bool onGal;

	public Sprite one;
	public Sprite two;
	public Sprite three; 
	public Sprite four;


	public Sprite  [] texts2;
	public bool onBoy;
	public Sprite one2;
	public Sprite two2;
	public Sprite three2;

	void Start(){
		//goTexts = false;
		//gal
		counter = 0;
		texts = new Sprite[4];
		texts [0] = one;//transparent
		texts [1] = two;
		texts [2] = three;
		texts [3] = four; 

		//boy
		texts2 = new Sprite[3];
		texts2 [0] = one2;//transparent
		texts2 [1] = two2;
		texts2 [2] = three2; 



		Debug.Log (texts.Length);
		currentSprite = GetComponent <SpriteRenderer> ();
		//texts = new List<Sprite>();
		//counter = 0;


		currentSprite2 = GetComponent <SpriteRenderer> ();

	}

	void Update () {
//
//		if (onGal == false || onBoy == false) {
//			currentSprite.sprite = one;
//			currentSprite2.sprite = one;
//		}



		if (Input.GetKeyDown (KeyCode.G) && goTexts == true) {//&& onGal == true) {
			counter++;
			Debug.Log ("code G");
		} 




		if (onGal == true && counter < texts.Length) { //&& goTexts == false) {
			currentSprite.sprite = texts [counter % texts.Length];
			//goTexts = false;
		}


		if (onGal == true && counter > 3) {//texts.Length) {
			//currentSprite.sprite = four;
			currentSprite.sprite = texts [0];
			counter = 0;
			goTexts = false;
			onGal = false;
		}



		if (onBoy == true && counter < texts2.Length) { //&& goTexts == false) {
			currentSprite2.sprite = texts2 [counter % texts2.Length];
			//goTexts = false;
		}

		if (onBoy == true && counter > 2) {
			Debug.Log ("boy counter stopped");
			currentSprite.sprite = texts [0];
			counter = 0;
			goTexts = false;
			onBoy = false;
		}
	}


	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "girlCollider") {
			Debug.Log ("gal");
			Destroy (c.gameObject);
			onGal = true;
			goTexts = true;
			onBoy = false;
			//onBoy = false;
		}
		
		if (c.gameObject.name == "boyCollider") {
			Debug.Log ("boy");
			Destroy (c.gameObject);
			onBoy = true;
			onGal = false;
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