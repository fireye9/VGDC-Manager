using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is used to test the progress bar. Once an automatic progress is made, this class will no
// longer be used...
public class ButtonProgress : MonoBehaviour
{
    public int progressAmount = 10;
    public TeamProgress teamProgress;
    public bool isClicked = false;

    GameObject team;
    //bool isClicked;


    void Awake()
    {
        // Setting up the references.
        team = GameObject.FindGameObjectWithTag("Player");
        teamProgress = team.GetComponent<TeamProgress>();
    }


    void Update()
    {
        if (isClicked)
        {
            onButtonPress();
        }
//        else
//        {
//            teamProgress.Complete();
//        }
        isClicked = false;
    }

    void onButtonPress()
    {
        // Make progress.
        teamProgress.MakeProgress(progressAmount);
    }

    public void click()
    {
        isClicked = true;
    }
}
