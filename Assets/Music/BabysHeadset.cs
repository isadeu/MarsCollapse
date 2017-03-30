using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BabysHeadset : MonoBehaviour {


	public AudioClip headsetSnd;
	public AudioSource source;

	//fade
	public float fadeTime = 1f;

	void Awake(){
		source = GetComponent <AudioSource> ();
	}
		

	void Start(){

	}


	void Update (){
		
		//pause volume
		if (Time.timeScale == 0f) {
			source.volume = .15f;
		} else {
			source.volume = .2f;
		}
			
	}

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "colliderground") {
			Debug.Log ("music collider");
			source.PlayOneShot (headsetSnd, .2f);
			Destroy (c.gameObject);
			Debug.Log ("destroyed");
		}
		if (c.gameObject.tag == "exit") {
			Debug.Log ("it found my musical gal");
			StartCoroutine ("AudioFadeOut");
			//audioFadeOut 
			//source.volume = Mathf.Lerp (.4f, 0, 1f);//Time.deltaTime);
		}
	}

			IEnumerator AudioFadeOut (){
			source = GetComponent <AudioSource> ();

			while (source.volume > 0.01f)
			{
				source.volume -= Time.deltaTime / 20f;
				yield return null;
			}
//				while (source.volume > 0) {
//			Debug.Log ("source vol is more than 0");
//					source.volume -= source.volume  * Time.deltaTime / fadeTime;
//				yield return 0;
//			}

//			IEnumerator fadeheadsetSnd = AudioFadeOut.FadeOut (headsetSnd, 0.5f);
//			StartCoroutine (headsetSnd);
//			StopCoroutine (headsetSnd);

				//StartCoroutine (AudioFadeOut.FadeOut (headsetSnd, 0.1f));
			}
		}
		//audio.volume = mathf.lerp(audio.volume, 0 , time.deltatime)	
	