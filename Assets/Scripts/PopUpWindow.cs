using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpWindow : MonoBehaviour
{
    public Canvas panelOnCanvas;
    public Text displayHeaderText;
    public Text displayBodyText;
    public Team team;
    // hardcode to true for debugging purposes
    bool infoOpen = false;

    void DisplayMemberInfo()
    {
        if (!infoOpen)
        {
            foreach (TeamMember member in team.memberList)
            {
                if (member.isLead)
                    displayHeaderText.text = member.name;
                displayBodyText.text += ("Member Name: " + member.name + "\n");
            }
        }
        else
        {
            displayBodyText.text = "";
        }
    }

    public void InfoPanel()
    {
        DisplayMemberInfo();
        if (!infoOpen)
        {
            infoOpen = true;
            panelOnCanvas.enabled = true;
        }

        else if (infoOpen)
        {
            infoOpen = false;
            panelOnCanvas.enabled = false;
        }
    }
}