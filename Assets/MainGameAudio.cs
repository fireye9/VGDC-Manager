using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameAudio : MonoBehaviour {

    private AudioSource audioS;
    public AudioClip ambient;
    public AudioClip ambientmusic;


	// Use this for initialization
	void Start () {
        audioS = GetComponent<AudioSource>();
        StartCoroutine("playMusic");
        
	}
	IEnumerator playMusic()
    {
        audioS.clip = ambient;
        audioS.Play();
        yield return new WaitForSeconds(audioS.clip.length);
        audioS.clip = ambientmusic;
        audioS.Play();
        yield return new WaitForSeconds(audioS.clip.length);
        StartCoroutine("playMusic");
    }
}
