using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Final_Text_Reset : MonoBehaviour {

	public Sprite HoverSprite;
	public Sprite NormalSprite;
	public Sprite ClickSprite;
	public Sprite RienSprite;



	public List<GameObject> Case_GO;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseOver () {
		//	if (!Bool_Clicked) {

			this.GetComponent<SpriteRenderer> ().sprite = HoverSprite;

		//	}
	}
	void OnMouseExit () {
		//if (!Bool_Clicked) {

			this.GetComponent<SpriteRenderer> ().sprite = NormalSprite;

		//}
	}

	void OnMouseDown () {

		Case_GO [0].GetComponent<FinalText> ().AA = true;;
	
		Case_GO [0].GetComponent<SpriteRenderer> ().sprite = RienSprite;
		Case_GO [1].GetComponent<SpriteRenderer> ().sprite = RienSprite;
		Case_GO [2].GetComponent<SpriteRenderer> ().sprite = RienSprite;

	}

}
