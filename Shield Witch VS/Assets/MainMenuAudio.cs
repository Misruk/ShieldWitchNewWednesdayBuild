using UnityEngine;
using System.Collections;

public class MainMenuAudio : MonoBehaviour {

    public static int clones = 0;
    public GameObject musicPrefab;

	// Use this for initialization
	void Start () {
        if(clones <= 0)
        {
            //GameObject instance = Instantiate(musicPrefab);
            //instance.name = "musicSpawn";
            this.gameObject.name = "musicSpawn";
            clones++;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (clones > 0)
        {
            Destroy(GameObject.Find("Music"));
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
