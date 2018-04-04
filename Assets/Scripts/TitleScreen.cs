using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject introText;
    public GameObject credits;

    public AudioClip buttonsound;

	public void OnStartClick()
    {
        PlayButtonSound();
        mainMenu.SetActive(false);
        introText.SetActive(true);
    }
    public void OnIntroCloseClick()
    {
        PlayButtonSound();
        SceneManager.LoadScene(1);
    }
    public void OnCreditsClick()
    {
        PlayButtonSound();
        mainMenu.SetActive(!mainMenu.activeSelf);
        credits.SetActive(!mainMenu.activeSelf);
    }
    public void OnExitClick()
    {
        PlayButtonSound();
        Application.Quit();
    }
    void PlayButtonSound()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonsound);
    }
}
