using UnityEngine;
using System.Collections;

public class Glow : MonoBehaviour {

	private float glower = 50;
	private Color col;
	public float speed = .1f;
	public bool rising;

	// Use this for initialization
	void Start () {
		col = GetComponent<SpriteRenderer> ().color;
		StartCoroutine (Fade ());
	}
	
	IEnumerator Fade(){
		for (int i = 0; i < glower; i++) {
			col.a -= .01f; 
			GetComponent<SpriteRenderer> ().color = col;
			yield return new WaitForSeconds (.01f);
		}
		StartCoroutine (Brighten ());
	}

	IEnumerator Brighten(){
		for (int i = 0; i < glower; i++) {
			col.a += .01f;
			GetComponent<SpriteRenderer> ().color = col;
			yield return new WaitForSeconds (.01f);
		}
		StartCoroutine (Fade ());
	}
}
