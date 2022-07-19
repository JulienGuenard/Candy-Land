using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DefilerButton : MonoBehaviour {


	public List<Sprite> Sprite_Images;

	SpriteRenderer SpriteRend;

//	int z = 0;

	// Use this for initialization
	void Start () {
		SpriteRend = this.gameObject.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseOver () {
		
			this.GetComponent<SpriteRenderer> ().sprite = Sprite_Images [1];

	}
	void OnMouseExit () {
		
			this.GetComponent<SpriteRenderer> ().sprite = Sprite_Images [0];

	}

	IEnumerator OnMouseDown () {
		if (this.gameObject.name == "ArrowL") {
			GetComponentInParent<Defiler> ().Bool_Left = true;
		}
		if (this.gameObject.name == "ArrowR") {
			GetComponentInParent<Defiler> ().Bool_Right = true;
		}
		SpriteRend.color = new Color (0f, 0f, 0f, 0f);
		for (int i = 0; i <= 20; i++) {

			yield return new WaitForSeconds (0.01f);

			SpriteRend.color = SpriteRend.color + new Color (0f, 0f, 0f, 0.05f);

		}
	}
}

