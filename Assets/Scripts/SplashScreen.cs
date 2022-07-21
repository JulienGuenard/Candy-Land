using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public class SplashScreen : MonoBehaviour {

	public float FadeTimer = 1f;

	// Use this for initialization
	void Start () {
		
		FadeTimer = (FadeTimer * 100) / 2;
		StartCoroutine (FadeOn());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator FadeOn () {
		yield return new WaitForSeconds (1f);
		for (int i = 0; i <= FadeTimer; i++) {

			yield return new WaitForSeconds (0.01f);
			GameObject.Find ("Fade").GetComponent<SpriteRenderer> ().color = GameObject.Find ("Fade").GetComponent<SpriteRenderer> ().color + new Color (0f, 0f, 0f,(1/FadeTimer));
		}

		yield return new WaitForSeconds (1f);


		StartCoroutine ("FadeIn");

	}

	IEnumerator FadeIn () {


		for (int i = 0; i <= FadeTimer; i++) {

			yield return new WaitForSeconds (0.01f);
			GameObject.Find ("Fade").GetComponent<SpriteRenderer> ().color = GameObject.Find ("Fade").GetComponent<SpriteRenderer> ().color - new Color (0f, 0f, 0f,(1/FadeTimer));
		}

		SceneManager.LoadScene ("Scene1");

	}
}
