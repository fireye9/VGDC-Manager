using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectProgress : MonoBehaviour {

    public float progress = 0f;
    float baseProgressRate = 6.5f;
    float currentProgressRate;
    bool workingOnProject = false;
    GameStateManager gameMgr;

    private void Awake()
    {
        gameMgr = GameObject.Find("GameManager").GetComponent<GameStateManager>();
        
    }
    void MakeProgress()
    {
        currentProgressRate = baseProgressRate * (gameMgr.productivity / 100) * Time.deltaTime;
        progress += currentProgressRate;
    }

    public void SetTeamIsWorking(bool value)
    {
        workingOnProject = value;
        if (value == true)
            gameMgr.attemptedProjects++;
    }
    public float GetProgressRate()
    {
        return currentProgressRate;
    }

    private void FixedUpdate()
    {
        if (progress < 100 && workingOnProject)
            MakeProgress();
        else if (progress >= 100)
        {
            gameMgr.completedProjects++;
            progress = 0;
            workingOnProject = false;
        }
    }
}
