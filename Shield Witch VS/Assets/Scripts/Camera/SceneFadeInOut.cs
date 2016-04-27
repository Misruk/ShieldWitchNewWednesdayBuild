using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour
{
    public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	//public int levelint;
	public Image image;
    private bool sceneStarting = true;      // Whether or not the scene is still fading in.
	public bool sceneEnding = false;
	public string scenery;
	//public Text text;
    
    
    void Awake ()
    {
        // Set the texture so that it is the the size of the screen and covers it.
		image.rectTransform.sizeDelta = new Vector2(Screen.width*3, Screen.height*3);
        //guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }
    
    
    void Update ()
    {
        // If the scene is starting...
        if(sceneStarting)
            // ... call the StartScene function.
            StartScene();
		if (sceneEnding)
			EndScene ();
    }
    
    
    void FadeToClear ()
    {
        // Lerp the colour of the texture between itself and transparent.
		GetComponent<Image>().color = Color.Lerp(image.color, Color.clear, fadeSpeed * Time.deltaTime);
        //guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
    
    
    void FadeToBlack ()
    {
        // Lerp the colour of the texture between itself and black.
		GetComponent<Image>().color = Color.Lerp(image.color, Color.black, fadeSpeed * Time.deltaTime);
        //guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
    }
    
    
    void StartScene ()
    {
        // Fade the texture to clear.
        FadeToClear();
        
        // If the texture is almost clear...
		if(image.color.a <= 0.05f)
        {
            // ... set the colour to clear and disable the GUITexture.
			image.color = Color.clear;
			image.enabled = false;
            
            // The scene is no longer starting.
            sceneStarting = false;
        }
    }
    
    
    public void EndScene ()
    {
        // Make sure the texture is enabled.
		image.enabled = true;
        
        // Start fading towards black.
        FadeToBlack();
        
        // If the screen is almost black...
		if(image.color.a >= 0.95f)
            // ... reload the level.
			//LevelManager.changeToPreviousLvl();
			SceneManager.LoadScene(scenery);
            //Application.LoadLevel(0);
    }
}