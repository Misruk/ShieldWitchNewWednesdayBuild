using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public static int characterSelected;

    public void CharacterSelectWitch()
    {
        characterSelected = 0;
    }

    public void CharacterSelectWizard()
    {
        characterSelected = 1;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("APPLICATION QUIT");
        Application.Quit();
    }
}
