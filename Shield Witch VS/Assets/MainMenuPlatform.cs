using UnityEngine;
using System.Collections;

public class MainMenuPlatform : MonoBehaviour {

    public static int clones = 0;
    public GameObject platform;

    // Use this for initialization
    void Start()
    {
        if (clones <= 0)
        {
            //GameObject instance = Instantiate(musicPrefab);
            //instance.name = "musicSpawn";
            this.gameObject.name = "platformSpawn";
            clones++;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (clones > 0)
        {
            Destroy(GameObject.Find("MovingPlatform (V)"));
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
