using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Pointeur : MonoBehaviour {


	public bool Restart;
	public GameObject Target;

	bool Bool_Clicked = false;
	public bool Fade_Desactivated;

	public List<Sprite> Sprite_Images;

	public float FadeTimer = 2;

	void Start () {
		FadeTimer = FadeTimer - 1.5f;
		FadeTimer = (FadeTimer * 100) / 2;

	}


	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		
		}

	}

	void OnMouseOver () {
		if (!Bool_Clicked) {
			this.GetComponent<SpriteRenderer> ().sprite = Sprite_Images [1];
		}
	}
	void OnMouseExit () {
		if (!Bool_Clicked) {
			this.GetComponent<SpriteRenderer> ().sprite = Sprite_Images [0];
		}
	}


	IEnumerator OnMouseDown () {
		
		this.GetComponent<SpriteRenderer> ().sprite = Sprite_Images [2];
		Bool_Clicked = true;

		if (!Restart && !Fade_Desactivated) {
			StartCoroutine ("FadeOn");
		}

		if (Fade_Desactivated) {
			GameObject.Find ("Main Camera").transform.position = Target.transform.position - new Vector3 (0, 0, 10);

			if (Target.tag == "QTE") {
				Target.GetComponentInChildren<QTE> ().ON = true;
			}
				
			Bool_Clicked = false;
			yield return new WaitForSeconds (0.1f);
			this.GetComponent<SpriteRenderer> ().sprite = Sprite_Images [0];
		}

		if (Restart) {
			GameObject.Find ("Main Camera").transform.position = Target.transform.position - new Vector3 (0, 0, 10);
			for (int i = 0; i <= 100; i++) {
				Debug.Log ("AAA");
				yield return new WaitForSeconds (0.02f);
				GameObject.Find ("Fade").GetComponent<SpriteRenderer> ().color = GameObject.Find ("Fade").GetComponent<SpriteRenderer> ().color + new Color (0f, 0f, 0f, 0.01f);
			}
			SceneManager.LoadScene("Scene1");

		}
	}

	IEnumerator FadeOn () {
		

		for (int i = 0; i <= FadeTimer; i++) {

			yield return new WaitForSeconds (0.01f);
			GameObject.Find ("Fade").GetComponent<SpriteRenderer> ().color = GameObject.Find ("Fade").GetComponent<SpriteRenderer> ().color + new Color (0f, 0f, 0f,(1/FadeTimer));
		}
		GameObject.Find ("Main Camera").transform.position = Target.transform.position - new Vector3 (0, 0, 10);

		if (Target.tag == "QTE") {
			Target.GetComponentInChildren<QTE> ().ON = true;
		}

		StartCoroutine ("FadeIn");
		Bool_Clicked = false;
		this.GetComponent<SpriteRenderer> ().sprite = Sprite_Images [0];
	}

		IEnumerator FadeIn () {


			for (int i = 0; i <= FadeTimer; i++) {

			yield return new WaitForSeconds (0.01f);
			GameObject.Find ("Fade").GetComponent<SpriteRenderer> ().color = GameObject.Find ("Fade").GetComponent<SpriteRenderer> ().color - new Color (0f, 0f, 0f,(1/FadeTimer));
			}

		}
}
