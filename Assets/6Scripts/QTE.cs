using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class QTE : MonoBehaviour {

	//
	public float Temps;

	public GameObject QTE_Bloc;

	public List<Sprite> QTE_Bloc_Images;
	public List<int> Order;
	public List<Sprite> QTE_Images;
	public List<Sprite> QTE_Images_Fail;

	public GameObject Target_Anim;

	public GameObject TargetWin;
	public GameObject TargetLose;

	public GameObject up;
	public GameObject right;
	public GameObject down;
	public GameObject left;
	public GameObject plus;
	public GameObject TimerBarPlein;
	public GameObject TimerBar;

	//

	SpriteRenderer SpriteRend;

	bool QTE_Failed = false;
	bool JustOneTimeMan = true;
	bool Bool_Block1 = false;
	public bool ON = false;

	int z = 0;
	int OrderCombo = 0;

	int QCount = 0;

	public List<GameObject> QTE_Bloc_Created;
	public List<GameObject> Plus_Bloc_Created;

	//

	void Start () {
		SpriteRend = this.gameObject.GetComponent<SpriteRenderer> ();
		Order.Add (0);
		Temps = Temps / 100;
	}
	
	// Update is called once per frame
	void Update () {
	if (ON) {
		if (JustOneTimeMan) {
			JustOneTimeMan = false;
			StartCoroutine (Timer (0f));
				TimerBarPlein.transform.localScale = new Vector3 (1f, 1f, 1f);
				TimerBarPlein.GetComponent<SpriteRenderer>().color = new Color (0f, 1f, 0f);
		}
			TimerBarPlein.SetActive (true);
			TimerBar.SetActive (true);


			this.GetComponent<SpriteRenderer> ().sprite = QTE_Images [z];



				switch (Order [z]) {
			case 1:
				if (!Bool_Block1) {
					Bool_Block1 = true;
					QTE_Bloc_Created.Add ((GameObject)Instantiate (up, QTE_Bloc.transform.position, Quaternion.identity));
				}
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					
					StartCoroutine ("Green");
				}
				break;
			case 2:
				if (!Bool_Block1) {
					Bool_Block1 = true;
					QTE_Bloc_Created.Add ((GameObject)Instantiate (right, QTE_Bloc.transform.position, Quaternion.identity));
				}
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					
					StartCoroutine ("Green");
				}
				break;
			case 3:
				if (!Bool_Block1) {
					Bool_Block1 = true;
					QTE_Bloc_Created.Add ((GameObject)Instantiate (down, QTE_Bloc.transform.position, Quaternion.identity));
				}
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					
					StartCoroutine ("Green");
				}
				break;
			case 4:
				if (!Bool_Block1) {
					Bool_Block1 = true;
					QTE_Bloc_Created.Add ((GameObject)Instantiate (left, QTE_Bloc.transform.position, Quaternion.identity));
				}
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					
					StartCoroutine ("Green");
				}
					break;
			case 5:
				if (!Bool_Block1) {
					
					Bool_Block1 = true;
					QTE_Bloc_Created.Add ((GameObject)Instantiate (up, QTE_Bloc.transform.position - new Vector3 (1.5f,0,0), Quaternion.identity));
					Plus_Bloc_Created.Add ((GameObject)Instantiate (plus, QTE_Bloc.transform.position, Quaternion.identity));
					QTE_Bloc_Created.Add ((GameObject)Instantiate (right, QTE_Bloc.transform.position + new Vector3 (1.5f,0,0), Quaternion.identity));
				}
				if (Input.GetKeyDown (KeyCode.RightArrow) && OrderCombo == 1) {
					StartCoroutine ("Green");
				}
				if (Input.GetKeyDown (KeyCode.UpArrow) && OrderCombo == 0) {
					
					StartCoroutine ("Green");
				}

				break;
			case 6:
				if (!Bool_Block1) {

					Bool_Block1 = true;
					QTE_Bloc_Created.Add ((GameObject)Instantiate (up, QTE_Bloc.transform.position - new Vector3 (2.5f,0,0), Quaternion.identity));
					Plus_Bloc_Created.Add ((GameObject)Instantiate (plus, QTE_Bloc.transform.position - new Vector3 (1.5f,0,0), Quaternion.identity));
					QTE_Bloc_Created.Add ((GameObject)Instantiate (up, QTE_Bloc.transform.position - new Vector3 (0f,0,0), Quaternion.identity));
					Plus_Bloc_Created.Add ((GameObject)Instantiate (plus, QTE_Bloc.transform.position + new Vector3 (1.5f,0,0), Quaternion.identity));
					QTE_Bloc_Created.Add ((GameObject)Instantiate (right, QTE_Bloc.transform.position + new Vector3 (2.5f,0,0), Quaternion.identity));
				}
				if (Input.GetKeyDown (KeyCode.RightArrow) && OrderCombo == 2) {
					StartCoroutine ("Green");
				}
				if (Input.GetKeyDown (KeyCode.UpArrow) && OrderCombo == 1) {

					StartCoroutine ("Green");
				}
				if (Input.GetKeyDown (KeyCode.UpArrow) && OrderCombo == 0) {

					StartCoroutine ("Green");
				}


				break;
			default:

				ON = false;
				TimerBarPlein.SetActive (false);
				TimerBar.SetActive (false);
					QTE_Failed = false;
					GameObject.Find ("Main Camera").transform.position = TargetWin.transform.position - new Vector3 (0, 0, 10);
					break;
					}
				}



			






	}


IEnumerator Green () {
		QTE_Bloc_Created [OrderCombo].transform.FindChild ("Vert").gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
		OrderCombo++;
		if (OrderCombo == QTE_Bloc_Created.Count) {
			for (int i = 0; i <= 20; i++) {

				yield return new WaitForSeconds (0.01f);
				for (int a = 0; a <= QTE_Bloc_Created.Count - 1; a++) {
					QTE_Bloc_Created [a].transform.FindChild ("Vert").gameObject.GetComponent<SpriteRenderer> ().color = QTE_Bloc_Created [a].transform.FindChild ("Vert").gameObject.GetComponent<SpriteRenderer> ().color - new Color (0f, 0f, 0f, 0.05f);
				}
			}

			Bool_Block1 = false;
			QCount = QTE_Bloc_Created.Count - 1;
			for (int a = 0; a <= QCount; a++) {
			
				Destroy (QTE_Bloc_Created [0]);
				QTE_Bloc_Created.Remove (QTE_Bloc_Created [0]);
			}
					
			QCount = Plus_Bloc_Created.Count-1;
			for (int a = 0; a <= QCount; a++) {

				Destroy (Plus_Bloc_Created [0]);
				Plus_Bloc_Created.Remove (Plus_Bloc_Created [0]);
			}
			z++;
			OrderCombo = 0;
		}
}








	IEnumerator Timer (float waitTime) {
		QTE_Failed = true;
		for (int g = 0; g <= 100; g++) {
			yield return new WaitForSeconds (Temps);
			if (g >= 45 && g <= 55) {
				TimerBarPlein.GetComponent<SpriteRenderer> ().color = TimerBarPlein.GetComponent<SpriteRenderer> ().color + new Color (0.1f, 0, 0);
			} 
			if (g >= 75 && g <= 85) {
				TimerBarPlein.GetComponent<SpriteRenderer> ().color = TimerBarPlein.GetComponent<SpriteRenderer> ().color - new Color (0f, 0.1f, 0);
			}

			TimerBarPlein.transform.localScale = TimerBarPlein.transform.localScale - new Vector3 (0.01f, 0, 0);
		}
		if (QTE_Failed == true) {
			QTE_Failed = false;
			z = -20;
			ON = false;
			TimerBarPlein.SetActive (false);
			TimerBar.SetActive (false);
			for (int y = 0; y <= QTE_Images_Fail.Count - 1; y++) {
				
				SpriteRend.sprite = QTE_Images_Fail [y];
				yield return new WaitForSeconds (1f);
			}


			if (Target_Anim != null) {
				Target_Anim.GetComponent<Anim_Script> ().ON = true;

			}
			GameObject.Find ("Main Camera").transform.position = TargetLose.transform.position - new Vector3 (0, 0, 10);
		}

	}

}
