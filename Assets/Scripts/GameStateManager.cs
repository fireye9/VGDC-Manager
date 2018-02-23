using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour {

    public float members = 10f;
    Text membersField;

    public float satisfaction = 30f;
    Text satisfactionField;

    public float productivity = 0f;
    Slider productivityField;

    public int week = 1;
    public float day = 1;
    Text calendarField;

    Canvas gameCanvas;

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
        members = newValue;
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
            if (week == 10)
            {
                Debug.Log("it's a new cycle");
                //Show the cycle results window?
            }
            else
            {
                Time.timeScale = 0;
                PopUpPrompt();
            }
        }
        else
            day = newValue;
        calendarField.text = "Week " + week.ToString() + " Day " + day.ToString("F0");
    }

    void PopUpPrompt()
    {
        GetComponent<TimedPrompt>().CreateNewPrompt();
    }

    private void FixedUpdate()
    {
        if (productivity < 100)
            SetProductivity(productivity + 1 * Time.deltaTime * 0.835f);
        SetDay(day + Time.deltaTime * 0.5f * 5f);
    }
}