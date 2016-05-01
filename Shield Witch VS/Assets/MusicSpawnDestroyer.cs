using UnityEngine;
using System.Collections;

public class MusicSpawnDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Destroy(GameObject.Find("MovingPlatform (V)"));
        GameObject.Find("musicSpawn").GetComponent<AudioSource>().mute = true;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
