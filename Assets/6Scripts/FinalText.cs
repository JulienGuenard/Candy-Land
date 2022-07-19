using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FinalText : MonoBehaviour {
	
	public Sprite HoverSprite;
	public Sprite NormalSprite;

	static public int Case_Actuel_Int;

	public List<GameObject> Case_GO;


	public bool AA = false;

	// Use this for initialization
	void Start () {
	//	Case_Actuel_Int = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (AA) {
			AA = false;
			Case_Actuel_Int = 0;


		}
		if (Case_Actuel_Int == 3 && this.gameObject.name != "Case") {
			this.GetComponent<SpriteRenderer> ().enabled = false;
			this.GetComponent<BoxCollider2D> ().enabled = false;
		}

		if (Case_Actuel_Int == 0 && this.gameObject.name != "Case") {
			this.GetComponent<SpriteRenderer> ().enabled = true;
			this.GetComponent<BoxCollider2D> ().enabled = true;
		}


		this.gameObject.SetActive (true);

	}

	void OnMouseOver () {
	//	if (!Bool_Clicked) {
		if (this.gameObject.name != "Case") {
			this.GetComponent<SpriteRenderer> ().sprite = HoverSprite;
		}
	//	}
	}
	void OnMouseExit () {
		//if (!Bool_Clicked) {
		if (this.gameObject.name != "Case") {
			this.GetComponent<SpriteRenderer> ().sprite = NormalSprite;
		}
		//}
	}

	void OnMouseDown () {

		if (Case_GO [Case_Actuel_Int].name == "Case" && Case_Actuel_Int <= 2) {
			
			Case_GO [Case_Actuel_Int].GetComponent<SpriteRenderer> ().sprite = NormalSprite;
			this.GetComponent<SpriteRenderer> ().enabled = false;
			this.GetComponent<BoxCollider2D> ().enabled = false;
			Case_Actuel_Int++;
		}
	}

}
