using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Defiler : MonoBehaviour {

	public List<GameObject> ListText;

	TextMesh TextNumber;

//	bool Bool_Clicked = false;

	public bool Bool_Left;
	public bool Bool_Right;

	int z = 0;
	int y = 0;
	public int x = 0;

	// Use this for initialization
	void Start () {
		TextNumber = GetComponentInChildren<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Bool_Left) {
			ListText [z].SetActive (false);
			Bool_Left = false;
			z--;
		}
		if (Bool_Right) {
			ListText [z].SetActive (false);
			Bool_Right = false;
			z++;
		}
			

		if (z < 0) {
			z = ListText.Count - 1;
		}
		if (z > ListText.Count - 1) {
			z = 0;
		}

		y = z + 1;
		x = ListText.Count;
		if (x == 1) {
			this.gameObject.SetActive (false);
		} else {
			TextNumber.text = y.ToString () + " / " + x.ToString ();
			ListText [z].SetActive (true);
		}
	}
}
