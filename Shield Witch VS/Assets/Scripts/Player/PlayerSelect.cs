using UnityEngine;
using System.Collections;

public class PlayerSelect : MonoBehaviour {

    //public static int characterSelected;

    public GameObject character1;
    public GameObject character2;

    // Use this for initialization
    void Start () {

        //characterSelected = 
        if(MenuManager.characterSelected == 0)
        {
            character1.SetActive(true);
            character2.SetActive(false);
        }
        else if (MenuManager.characterSelected == 1)
        {
            character1.SetActive(false);
            character2.SetActive(true);
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
