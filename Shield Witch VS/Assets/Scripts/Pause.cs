using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {



    private bool paused;

    public GameObject player;
    public GameObject player2;


    void Start()
    {
        paused = false;

        if (MenuManager.characterSelected == 0)
        {
            Debug.Log("Camera locked onto Witch");
        }
        else if (MenuManager.characterSelected == 1)
        {
            player = player2;
        }


        //PauseMenuHolder = GameObject.Find("PauseMenuHolder");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused)
        {
            //PauseMenuHolder.SetActive(true);
            Time.timeScale = 0;

            player.GetComponent<Player_Controller>().enabled = false;
            player.GetComponent<ShieldPulse>().enabled = false;
            player.GetComponent<PulseGenerator>().enabled = false;

        }
        else if (!paused)
        {
            //PauseMenuHolder.SetActive(false);
            Time.timeScale = 1;

            player.GetComponent<Player_Controller>().enabled = true;
            player.GetComponent<ShieldPulse>().enabled = true;
            player.GetComponent<PulseGenerator>().enabled = true;
        }
    }
}
