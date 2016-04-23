using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public static int characterSelected = 0;
    public GameObject otherMenu;
    public GameObject mainMenu;
    public GameObject mainMenuWiz;
    public GameObject someMenu;

    public GameObject witchAnim;
    public GameObject wizardAnim;

    void Awake()
    {
        mainMenu.SetActive(true);
        mainMenuWiz.SetActive(false);
        otherMenu.SetActive(false);


        wizardAnim.SetActive(false);
        witchAnim.SetActive(true);
    }

    public void LoadLab()
    {
		SceneManager.LoadScene ("Level");
    }

    public void LoadForest()
    {
		SceneManager.LoadScene ("Level2");
    }

    public void LoadCity()
    {
        SceneManager.LoadScene("Level3");
    }

	public void LoadMainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}

    public void MenuLevel()
    {
        mainMenu.SetActive(false);
        otherMenu.SetActive(true);
    }

    public void MenuLevelWiz()
    {
        mainMenuWiz.SetActive(false);
        someMenu.SetActive(true);
    }

    public void ReturnToMenu()
    {
        mainMenu.SetActive(true);
        otherMenu.SetActive(false);
    }

    public void ReturnToMenuWiz()
    {
        mainMenuWiz.SetActive(true);
        someMenu.SetActive(false);
    }

    public void CharacterSelectWitch()
    {
        Debug.Log("Witch Selected");
        characterSelected = 0;

        mainMenu.SetActive(true);
        mainMenuWiz.SetActive(false);

        witchAnim.SetActive(true);
        wizardAnim.SetActive(false);
    }

    public void CharacterSelectWizard()
    {
        Debug.Log("Wizard Selected");
        characterSelected = 1;

        mainMenuWiz.SetActive(true);
        mainMenu.SetActive(false);

        wizardAnim.SetActive(true);
        witchAnim.SetActive(false);
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
