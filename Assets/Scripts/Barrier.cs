using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Barrier : MonoBehaviour {

	public bool Bool_Clicked = false;
	public List<GameObject> OtherSegments;
	public GameObject AnswerTarget;

	public bool Activated = false;

	// Use this for initialization
	void Start () {
		if (Activated) {
			Bool_Clicked = true;
			AnswerTarget.SetActive (true);
			this.GetComponent<SpriteRenderer> ().color = new Color (0, 1, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseOver () {
		if (!Bool_Clicked) {
			this.GetComponent<SpriteRenderer> ().color = new Color (0.6f, 0.6f, 0.6f);
		}
	}
	void OnMouseExit () {
		if (!Bool_Clicked) {
			this.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);
		}
	}

	IEnumerator OnMouseDown () {

		if (!Bool_Clicked) {



			Bool_Clicked = true;
			this.GetComponent<SpriteRenderer> ().color = new Color (0, 1, 0);
			for (int i = 0; i < 5; i++) {
				OtherSegments [i].GetComponent<SpriteRenderer> ().color = new Color(1,1,1);
				OtherSegments [i].GetComponent<Barrier> ().Bool_Clicked = true;
				OtherSegments [i].GetComponent<Barrier> ().AnswerTarget.SetActive (false);

			}
			AnswerTarget.SetActive (true);
		}

		yield return new WaitForSeconds (0.01f);
		for (int i = 0; i < 5; i++) {
			OtherSegments [i].GetComponent<Barrier> ().Bool_Clicked = false;

		}


	}

}
