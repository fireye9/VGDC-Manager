using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject introText;
    public GameObject credits;
	public void OnStartClick()
    {
        mainMenu.SetActive(false);
        introText.SetActive(true);
    }
    public void OnIntroCloseClick()
    {
        SceneManager.LoadScene(1);
    }
    public void OnCreditsClick()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        credits.SetActive(!mainMenu.activeSelf);
    }
    public void OnExitClick()
    {
        Application.Quit();
    }
}
