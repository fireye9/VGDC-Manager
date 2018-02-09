using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour {

    float members = 4f;
    Text membersField;

    float satisfaction = 30f;
    Text satisfactionField;

    float productivity = 20f;
    Slider productivityField;

    int week = 1;
    float day = 1;
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
        satisfactionField.text = satisfaction.ToString("F0");
        productivityField.value = productivity;


    }
    public void SetSatisfaction(float newValue)
    {
        satisfaction = newValue;
        satisfactionField.text = satisfaction.ToString("F0") + "%";
    }
    public void SetMembers(float newValue)
    {
        members = newValue;
        membersField.text = members.ToString("F0");
    }
    public void SetProductivity(float newValue)
    {
        productivity = newValue;
        productivityField.value = productivity;
    }
    public void SetDay(float newValue)
    {
        if (newValue > 7.0f)
        {
            Time.timeScale = 0;
            PopUpPrompt();
            week += 1;
            day = 1f;
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
        //Demo function calls that will only increment the game values over time
        SetSatisfaction(satisfaction + 1 * Time.deltaTime * 1.25f);
        SetMembers(members + 1 * Time.deltaTime * 0.2f);
        if (productivity < 100)
            SetProductivity(productivity + 1 * Time.deltaTime * 1.2f);
        SetDay(day + Time.deltaTime * 0.5f);
    }
}
