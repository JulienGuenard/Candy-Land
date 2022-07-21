using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Anim_Script : MonoBehaviour {
	public GameObject Target;
	public bool ON = false;
	public float Temps;

	public List<GameObject> ListAnim;


	Animation Anim;
	// Use this for initialization
	void Start () {
		Anim = GetComponent<Animation> ();
		Debug.Log (Anim);
	}
	
	// Update is called once per frame
	void Update () {



		if (ON) {
			ON = false;
			Anim.Play ();
			StartCoroutine ("Pointeur");
		}
	}

	IEnumerator Pointeur () {
		yield return new WaitForSeconds (Temps);
		GameObject.Find ("Main Camera").transform.position = Target.transform.position - new Vector3 (0, 0, 10);
	}
}
