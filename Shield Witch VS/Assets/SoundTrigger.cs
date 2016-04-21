using UnityEngine;
using System.Collections;

public class SoundTrigger : MonoBehaviour {

	//Audio
	private AudioSource[] allAudioSources;
	private AudioSource trigSource;
	public AudioClip trigsound;
	// Use this for initialization
	void Start () {
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		trigSource = allAudioSources [1];

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player"){
			trigSource.clip = trigsound;
			trigSource.Play ();
		}
	} 

}
