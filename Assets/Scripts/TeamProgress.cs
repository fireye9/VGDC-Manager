using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamProgress : MonoBehaviour {

    public int startingProgress = 0;
    public int currentProgress;
    public Slider progressSlider;
    public Image progressImage;
    public AudioClip progressBop;
    public AudioClip progressComplete;
    public Text valueText;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    GameObject team;
    //Animator anim;
    //AudioSource progressAudio;
    bool isDone;
    bool madeProgress;

    void Awake()
    {
        
        //anim = GetComponent<Animator>();
        //progressAudio = GetComponent<AudioSource>();

        // Set the initial progress of the team.
        currentProgress = startingProgress;

    }
	
	// Update is called once per frame
	void Update ()
    {
        // If the player has made progress...
        if (madeProgress)
        {
            showCurrentProgress();
        }
        madeProgress = false;
		
	}

    public void MakeProgress(int amount)
    {
        if (currentProgress < 100)
        {
            // Set the progress flag so the screen will flash (later do a thing)
            madeProgress = true;

            // Increase the current progress by the progress amount.
            currentProgress += amount;


            // Set the progress bar's value to the current progress
            progressSlider.value = currentProgress;

            // Play the progress sound effect
            //progressAudio.Play();

            Debug.Log(currentProgress);
        }
        // If the player has made full progress...
        if (currentProgress <= 100 && !isDone)
        {
            Complete();
        }
    }

    public void showCurrentProgress()
    {
        valueText.text = currentProgress.ToString();
        // show current progress on GUI
    }

    public void Complete()
    {
        // Set the done flag so this function won't be called again.
        isDone = true;

        // Tell the animator that the progress bar is full
        //anim.SetTrigger("MISSION COMPLETE!");

        // Set the audiosource to play the Mission complete and play it
        //progressAudio.clip = progressComplete;
        //progressAudio.Play();

    }
}
