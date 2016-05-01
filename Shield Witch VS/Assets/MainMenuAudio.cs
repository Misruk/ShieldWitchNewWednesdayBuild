using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuAudio : MonoBehaviour {

    public static int clones = 0;
    public GameObject musicPrefab;
    private AudioSource music;

    public static bool scene = true;


    void Awake()
    {
        music = GetComponent<AudioSource>();
        music.UnPause();
    }
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
    void Update() {

        /*if (Application.loadedLevelName == "Level1" || Application.loadedLevelName == "Level2" || Application.loadedLevelName == "Level3" || Application.loadedLevelName == "WINScene"
            || Application.loadedLevelName == "LabDeath" || Application.loadedLevelName == "ForestDeath" || Application.loadedLevelName == "CityDeath")
        {
            music.Pause();
        }

        if (Application.loadedLevelName == "MAINMenu" || Application.loadedLevelName == "MAINMenuWiz")
        {
            music.Play();
        } 

        if(SceneManager.GetActiveScene().name == "Level")
        {
            //music.Stop();
            music.mute = true;
            scene = false;
        }

        if (SceneManager.GetActiveScene().name == "MAINMenu" && scene == false)
        {
            //music.Play();
            music.mute = false;
            scene = true;
        }
        */
    }
}
