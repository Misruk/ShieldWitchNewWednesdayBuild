using UnityEngine;
using System.Collections;

public class MusicSpawnSavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("musicSpawn").GetComponent<AudioSource>().mute = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
