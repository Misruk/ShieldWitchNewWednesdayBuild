using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour {

    public static int characterSelected = 0;
    public GameObject otherMenu;
    public GameObject mainMenu;
    public GameObject mainMenuWiz;
    public GameObject someMenu;

    public GameObject mainEvent;
    public GameObject mainWizEvent;
    public GameObject levelEvent;
    public GameObject levelWizEvent;

    public GameObject mainFirstSelected;
    public GameObject mainWizFirst;
    public GameObject levelFirst;
    public GameObject levelWizFirst;

    public GameObject witchAnim;
    public GameObject wizardAnim;

    private AudioSource music;


    void Awake()
    {
        /*mainMenu.SetActive(true);
        mainMenuWiz.SetActive(false);
        otherMenu.SetActive(false);
        someMenu.SetActive(false);

        mainEvent.SetActive(true);
        mainWizEvent.SetActive(false);
        levelEvent.SetActive(false);
        levelWizEvent.SetActive(false);


        wizardAnim.SetActive(false);
        witchAnim.SetActive(true); */

        //music = GetComponent<AudioSource>();
        //music.Play();
        //music.UnPause();

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

    public void LoadMainMenuWiz()
    {
        SceneManager.LoadScene("MAINMenuWiz");
    }

    public void MenuLevel()
    {
        mainMenu.SetActive(false);
        otherMenu.SetActive(true);
        //levelEvent.SetActive(true);

        mainEvent.SetActive(false);
        mainWizEvent.SetActive(false);
        levelEvent.SetActive(true);
        levelWizEvent.SetActive(false);
}

    public void MenuLevelWiz()
    {
        mainMenuWiz.SetActive(false);
        someMenu.SetActive(true);
       // levelWizEvent.SetActive(true);

        mainEvent.SetActive(true);
        mainWizEvent.SetActive(false);
        levelEvent.SetActive(false);
        levelWizEvent.SetActive(true);
    }

    public void ReturnToMenu()
    {
        mainMenu.SetActive(true);
        otherMenu.SetActive(false);

        mainEvent.SetActive(true);
        mainWizEvent.SetActive(false);
        levelEvent.SetActive(false);
        levelWizEvent.SetActive(false);

        //DontDestroyOnLoad(music);
        LoadMainMenu();
        //mainMenu.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(mainFirstSelected);
    }

    public void ReturnToMenuWiz()
    {
        mainMenuWiz.SetActive(true);
        someMenu.SetActive(false);

        mainEvent.SetActive(false);
        mainWizEvent.SetActive(true);
        levelEvent.SetActive(false);
        levelWizEvent.SetActive(false);

        LoadMainMenuWiz();
    }

    public void CharacterSelectWitch()
    {
        Debug.Log("Witch Selected");
        characterSelected = 0;

        mainMenu.SetActive(true);
        mainMenuWiz.SetActive(false);

        mainEvent.SetActive(true);
        mainWizEvent.SetActive(false);
        levelEvent.SetActive(false);
        levelWizEvent.SetActive(false);

        witchAnim.SetActive(true);
        wizardAnim.SetActive(false);

        LoadMainMenu();
    }

    public void CharacterSelectWizard()
    {
        Debug.Log("Wizard Selected");
        characterSelected = 1;

        mainMenuWiz.SetActive(true);
        mainMenu.SetActive(false);

        mainEvent.SetActive(false);
        mainWizEvent.SetActive(true);
        levelEvent.SetActive(false);
        levelWizEvent.SetActive(false);

        wizardAnim.SetActive(true);
        witchAnim.SetActive(false);

        LoadMainMenuWiz();
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
