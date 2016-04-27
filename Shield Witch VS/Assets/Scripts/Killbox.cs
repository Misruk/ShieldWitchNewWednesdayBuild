using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Killbox : MonoBehaviour {

	//public string scene;
	public Color myColor;
	public GameObject player;
	public GameObject player2;
	private SceneFadeInOut fadescript;
	// Use this for initialization
	void Start () {
		if(MenuManager.characterSelected == 0)
		{
			Debug.Log("Camera locked onto Witch");
		} else if (MenuManager.characterSelected == 1)
		{
			player = player2;
		}
		//player = GameObject.Find ("Player_Test");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
			player.GetComponent<Player_Controller> ().curHealth = 0;
			//Initiate.Fade(scene,myColor,0.5f);
			//Debug.Log("Killboxed");
			//fadescript.EndScene ();
            //Destroy(col.gameObject);
            //SceneManager.LoadScene("_GameOver");
        }
    } 
}
