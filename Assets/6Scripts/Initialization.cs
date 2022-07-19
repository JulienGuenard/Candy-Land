using UnityEngine;
using System.Collections;

public class Initialization : MonoBehaviour {



	// Use this for initialization
	void Start () {
		GameObject.Find ("Fade").GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f,1f);
		StartCoroutine ("FadeOn");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator FadeOn () {


			for (int i = 0; i <= 100; i++) {
			
				yield return new WaitForSeconds (0.02f);
			GameObject.Find ("Fade").GetComponent<SpriteRenderer> ().color = GameObject.Find ("Fade").GetComponent<SpriteRenderer> ().color - new Color (0f, 0f, 0f,0.01f);
			}


	}
}
