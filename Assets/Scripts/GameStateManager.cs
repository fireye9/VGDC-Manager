using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour {

    float members = 12f;
    public float memberChanges;
    Text membersField;

    public float satisfaction = 80f;
    Text satisfactionField;

    public float productivity = 0f;
    float prodModifier = 0f;
    Slider productivityField;

    public int week = 1;
    public float day = 1;
    Text calendarField;

    Canvas gameCanvas;
    public GameObject resultsPrefab;
    GameObject newResults;

    public int completedProjects;
    public int attemptedProjects;

    private void Awake()
    {
        gameCanvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
        membersField = gameCanvas.transform.Find("Members").GetComponent<Text>();
        satisfactionField = gameCanvas.transform.Find("Satisfaction").GetComponent<Text>();
        productivityField = gameCanvas.transform.Find("Productivity").GetComponent<Slider>();
        calendarField = gameCanvas.transform.Find("Calendar").GetComponent<Text>();

        membersField.text = members.ToString("F0");
        satisfactionField.text = satisfaction.ToString("F0") + "%";
        productivityField.value = productivity;
    }
    public void SetSatisfaction(float newValue)
    {
        satisfaction = newValue;
        if (satisfaction < 0)
            satisfaction = 0;
        satisfactionField.text = satisfaction.ToString("F0") + "%";
    }
    public void SetMembers(float newValue)
    {
        members += newValue;
        if (members < 1)
            members = 1;
        membersField.text = members.ToString("F0");
    }
    public void SetProductivity(float newValue)
    {
        productivity = newValue;
        if (productivity < 0)
            productivity = 0;
        productivityField.value = productivity;
    }
    public void SetDay(float newValue)
    {
        if (newValue > 7.0f)
        {
            Time.timeScale = 0;
            if (week == 10)
            {
                memberChanges = Mathf.Ceil((satisfaction - 50) / 5);
                if (memberChanges < 0)
                    memberChanges = 0;
                SetMembers(memberChanges);
                newResults = Instantiate(resultsPrefab);
                newResults.transform.SetParent(GameObject.Find("UICanvas").transform, false);
                newResults.transform.Find("Projects").GetComponent<Text>().text = "Projects Completed: "+ completedProjects;
                newResults.transform.Find("ClubMembers").GetComponent<Text>().text = "Members Gained: " + memberChanges.ToString();

                //new quarter bonuses
                float percentComplete = completedProjects / attemptedProjects;
                float satisfactionBonus = ((percentComplete - 0.75f) / 2) * 100;
                newResults.transform.Find("SatisfBonus").GetComponent<Text>().text = "Satisfaction Change: " + satisfactionBonus.ToString("F0") + "%";

                satisfaction += satisfactionBonus;
                prodModifier = (percentComplete - 0.75f) / 10;
                float prodDisplay = prodModifier * 100;
                newResults.transform.Find("ProdBonus").GetComponent<Text>().text = "Productivity Rate Modifier: " + prodDisplay.ToString("F0") + "%" + "\n(for 3 weeks)";

                week = 1;
                day = 1;

                //Make teams progress again
                GameObject[] teams = GameObject.FindGameObjectsWithTag("Team");
                foreach( GameObject i in teams)
                    i.GetComponent<ProjectProgress>().SetTeamIsWorking(true);
            }
            else
            {
                PopUpPrompt();
            }
        }
        else
            day = newValue;
        calendarField.text = "Week " + week.ToString() + " Day " + day.ToString("F0");
        if (week == 4 && prodModifier != 0f)
            prodModifier = 0f;
    }

    void PopUpPrompt()
    {
        GetComponent<TimedPrompt>().CreateNewPrompt();
    }

    private void FixedUpdate()
    {
        if (productivity < 100)
            SetProductivity(productivity + 1 * Time.deltaTime * (1.1f + prodModifier));
        SetDay(day + Time.deltaTime);
    }
}