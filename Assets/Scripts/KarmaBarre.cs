using UnityEngine;
using System.Collections;

public class KarmaBarre : MonoBehaviour {

	public float Karma = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3 (Karma, 0, -1);

		if (Karma >= 0.01f) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0, 1);
		}
		if (Karma <= -0.01f) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (0, 1, 0, 1);
		}

		if (Karma < 0.01f && Karma > -0.01f) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.7f, 1, 0, 1);
		}
	}
}
